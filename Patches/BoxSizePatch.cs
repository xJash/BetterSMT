using HarmonyLib;
using Mirror;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System;

namespace BetterSMT.Patches;

public class BoxSizePatch {

    public class AddNetwork {
        internal static void PatchAll() {
            BetterSMT.Harmony.Patch(
                AccessTools.Method(typeof(NetworkManager), nameof(NetworkManager.StartHost)),
                prefix: new HarmonyMethod(typeof(AddNetwork), nameof(HostStarting)),
                postfix: new HarmonyMethod(typeof(AddNetwork), nameof(HostStarted))
            );

            BetterSMT.Harmony.Patch(
                AccessTools.Method(typeof(NetworkManager), nameof(NetworkManager.StartClient)),
                prefix: new HarmonyMethod(typeof(AddNetwork), nameof(ClientStarting))
            );
        }

        private static void HostStarting()
            => BoxSizeNetwork.AddPrefab();

        private static void HostStarted()
            => BoxSizeNetwork.Spawn();

        private static void ClientStarting()
            => BoxSizeNetwork.AddPrefab();
    }

    public class ProductList {
        internal static Dictionary<Data_Product, int> DefaultBoxSizes;

        internal static void PatchAll() {
            BetterSMT.Harmony.Patch(
                AccessTools.Method(typeof(ProductListing), nameof(ProductListing.Awake)),
                postfix: new HarmonyMethod(typeof(ProductList), nameof(CreateList))
            );
        }

        private static void CreateList(ProductListing __instance) {
            DefaultBoxSizes = __instance.productPrefabs
                .Select(p => p.GetComponent<Data_Product>())
                .ToDictionary(product => product, product => product.maxItemsPerBox);
        }
    }

    public class ProductSpawning {
        public static List<Tuple<int, bool>> ProductsToSpawn = [];

        internal static void PatchAll() {
            BetterSMT.Harmony.Patch(
                AccessTools.Method(typeof(ManagerBlackboard), nameof(ManagerBlackboard.UserCode_CmdAddProductToSpawnList__Int32)),
                prefix: new HarmonyMethod(typeof(ProductSpawning), nameof(AddProductToSpawnList))
            );

            BetterSMT.Harmony.Patch(
                AccessTools.Method(typeof(ManagerBlackboard), nameof(ManagerBlackboard.BuyCargo)),
                transpiler: new HarmonyMethod(typeof(ProductSpawning), nameof(BuyCargoTranspiler))
            );

            BetterSMT.Harmony.Patch(
                AccessTools.EnumeratorMoveNext(AccessTools.Method(typeof(ManagerBlackboard), nameof(ManagerBlackboard.ServerCargoSpawner))),
                transpiler: new HarmonyMethod(typeof(ProductSpawning), nameof(SpawnerTranspiler))
            );
        }

        internal static void UnpatchAll() {
            BetterSMT.Harmony.Unpatch(
                AccessTools.Method(typeof(ManagerBlackboard), nameof(ManagerBlackboard.InvokeUserCode_CmdAddProductToSpawnList__Int32)),
                HarmonyPatchType.Prefix,
                PluginInfo.PLUGIN_GUID
            );

            BetterSMT.Harmony.Unpatch(
                AccessTools.Method(typeof(ManagerBlackboard), nameof(ManagerBlackboard.BuyCargo)),
                HarmonyPatchType.Transpiler,
                PluginInfo.PLUGIN_GUID
            );

            BetterSMT.Harmony.Unpatch(
                AccessTools.EnumeratorMoveNext(AccessTools.Method(typeof(ManagerBlackboard), nameof(ManagerBlackboard.ServerCargoSpawner))),
                HarmonyPatchType.Transpiler,
                PluginInfo.PLUGIN_GUID
            );
        }

        private static bool AddProductToSpawnList(int productIDToAdd) {
            ProductsToSpawn.Add(new Tuple<int, bool>(productIDToAdd, false)); // this is the only line being replaced, transpiler would be better

            ManagerBlackboard instance = GameData.Instance.GetComponent<ManagerBlackboard>();

            if (instance.isServer && !instance.isSpawning)
                instance.StartCoroutine(instance.ServerCargoSpawner());

            return false;
        }

        private static IEnumerable<CodeInstruction> BuyCargoTranspiler(IEnumerable<CodeInstruction> instructions) {
            return new CodeMatcher(instructions)
                .Start()
                .MatchForward(false, new CodeMatch(OpCodes.Call, AccessTools.Method(typeof(ManagerBlackboard), nameof(ManagerBlackboard.CmdAddProductToSpawnList))))
                .Set(OpCodes.Call, AccessTools.Method(typeof(BoxSizeNetwork), nameof(BoxSizeNetwork.CmdAddMultipliedProduct)))
                .Advance(-2)
                .Set(OpCodes.Ldsfld, AccessTools.Field(typeof(BoxSizeNetwork), nameof(BoxSizeNetwork.Instance)))

                .InstructionEnumeration();
        }

        private static IEnumerable<CodeInstruction> SpawnerTranspiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator) {
            LocalBuilder multiply = generator.DeclareLocal(typeof(bool));
            LocalBuilder dataProduct = generator.DeclareLocal(typeof(Data_Product));
            Label jump = generator.DefineLabel();

            return new CodeMatcher(instructions)
                /*
                 *  Replace:
                 *          idsToSpawn.Count
                 *  With:
                 *          ProductSpawning.ProductsToSpawn.Count
                 */
                .Start()
                .MatchForward(false, new CodeMatch(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(List<int>), nameof(List<int>.Count))))
                .Advance(-2)
                .SetAndAdvance(OpCodes.Ldsfld, AccessTools.Field(typeof(ProductSpawning), nameof(ProductsToSpawn)))
                .RemoveInstruction()
                .SetOperandAndAdvance(AccessTools.PropertyGetter(typeof(List<Tuple<int, bool>>), "Count"))

                /*
                *  Replace:
                *          int num = idsToSpawn[0];
                *  With:
                *          var product = ProductsToSpawn[0];       // "product" is only on the stack and is not saved in a real variable
                *          bool multiply = product.Value;
                *          int num = product.Key;
                */
                .Start()
                .MatchForward(false, new CodeMatch(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(List<int>), "Item")))
                .Advance(-3)
                .RemoveInstructions(2)
                .InsertAndAdvance(new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(ProductSpawning), nameof(ProductsToSpawn))))
                .Advance(1)
                .SetAndAdvance(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(List<Tuple<int, bool>>), "Item"))
                .Insert(
                [
                    new(OpCodes.Dup),
                    new(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(Tuple<int, bool>), nameof(Tuple<int, bool>.Item2))),
                    new(OpCodes.Stloc_S, multiply.LocalIndex),
                    new(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(Tuple<int, bool>), nameof(Tuple<int, bool>.Item1)))
                ])

                /*
                 *  4 is the index of "maxItemsPerBox", this index can change if the method updates
                 *  
                 *  Save dataProduct
                 *  Add:
                 *          if (multiply)
                 *              skip;
                 *          
                 *          maxItemsPerBox = ProductList.BoxSizes[dataProduct];
                 */
                .Start()
                .MatchForward(false, new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(Data_Product), nameof(Data_Product.maxItemsPerBox))))
                .Insert([
                    new(OpCodes.Dup),
                    new(OpCodes.Stloc_S, dataProduct.LocalIndex)
                ])
                .Advance(2)
                .Insert(
                [
                    new(OpCodes.Ldloc_S, multiply.LocalIndex),
                    new(OpCodes.Brtrue_S, jump),

                    new(OpCodes.Ldsfld, AccessTools.Field(typeof(ProductList), nameof(ProductList.DefaultBoxSizes))),
                    new(OpCodes.Ldloc_S, dataProduct),
                    new(OpCodes.Callvirt, AccessTools.Method(typeof(Dictionary<Data_Product, int>), "get_Item")),
                    new(OpCodes.Stloc_S, 4),

                    new CodeInstruction(OpCodes.Nop).WithLabels(jump)
                ])

                /*
                 *  Replace
                 *          idsToSpawn.RemoveAt
                 *  With
                 *          ProductSpawning.ProductsToSpawn.RemoveAt
                 */
                .Start()
                .MatchForward(false, new CodeMatch(OpCodes.Callvirt, AccessTools.Method(typeof(List<int>), nameof(List<int>.RemoveAt))))
                .Advance(-3)
                .RemoveInstructions(2)
                .InsertAndAdvance(new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(ProductSpawning), nameof(ProductsToSpawn))))
                .Advance(1)
                .SetOperandAndAdvance(AccessTools.Method(typeof(List<Tuple<int, bool>>), "RemoveAt"))

                .InstructionEnumeration();
        }
    }
}