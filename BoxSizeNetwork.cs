using BetterSMT.Enums;
using BetterSMT.Patches;
using HarmonyLib;
using Mirror;
using Mirror.RemoteCalls;
using System;
using System.Linq;
using UnityEngine;

namespace BetterSMT;

public class BoxSizeNetwork : NetworkBehaviour {

    private static readonly string CommandName = $"System.Void {typeof(BoxSizeNetwork).FullName}::{nameof(CmdAddMultipliedProduct)}(System.Int32)";

    public static BoxSizeNetwork Instance;

    private static GameObject NetworkPrefab;

    private static GameObject NetworkObject;

    [SyncVar]
    private float boxSizeValue;

    [SyncVar]
    private BoxSizeType boxSizeType;

    public float BoxSizeValue {
        get => boxSizeValue;
        set => GeneratedSyncVarSetter(value, ref boxSizeValue, 1uL, null);
    }

    public BoxSizeType BoxSizeType {
        get => boxSizeType;
        set => GeneratedSyncVarSetter(value, ref boxSizeType, 2uL, null);
    }

    static BoxSizeNetwork() {
        RemoteProcedureCalls.RegisterCommand(typeof(BoxSizeNetwork), CommandName, CmdAddMultipliedProductExecute__Int32, requiresAuthority: false);
    }

    internal static void AddPrefab() {
        NetworkPrefab = new GameObject("BoxSizeNetworkPrefab");
        NetworkPrefab.SetActive(false);
        NetworkPrefab.AddComponent<BoxSizeNetwork>();
        NetworkPrefab.AddComponent<NetworkIdentity>();
        AccessTools.Field(typeof(NetworkIdentity), "_assetId").SetValue(NetworkPrefab.GetComponent<NetworkIdentity>(), (uint)4658645);
        NetworkObject = Instantiate(NetworkPrefab);

        if (NetworkObject == null) {
            BetterSMT.Logger.LogError("BoxSize NetworkBehaviour is null");
            return;
        }

        NetworkManager.singleton.spawnPrefabs.Add(NetworkObject);
    }

    internal static void Spawn() {
        if (NetworkObject == null) {
            BetterSMT.Logger.LogError("BoxSize NetworkBehaviour is null");
            return;
        }

        NetworkServer.Spawn(NetworkObject);
    }

    public void Awake() {
        Instance = this;
        BoxSizePatch.ProductSpawning.PatchAll();
    }

    public override void OnStartClient() {
        base.OnStartClient();

        foreach (Data_Product product in GameData.Instance.GetComponent<ProductListing>().productPrefabs.Select(p => p.GetComponent<Data_Product>()))
            product.maxItemsPerBox = MultiplyBoxSize(BoxSizePatch.ProductList.DefaultBoxSizes[product]);
    }

    public override void OnStartServer() {
        base.OnStartServer();

        boxSizeValue = BetterSMT.BoxSizeValue.Value;
        boxSizeType = BetterSMT.BoxSizeType.Value;
        foreach (Data_Product product in GameData.Instance.GetComponent<ProductListing>().productPrefabs.Select(p => p.GetComponent<Data_Product>()))
            product.maxItemsPerBox = MultiplyBoxSize(BoxSizePatch.ProductList.DefaultBoxSizes[product]);
    }

    public void OnDestroy() {
        BoxSizePatch.ProductSpawning.UnpatchAll();

        foreach (Data_Product product in GameData.Instance.GetComponent<ProductListing>().productPrefabs.Select(p => p.GetComponent<Data_Product>()))
            product.maxItemsPerBox = BoxSizePatch.ProductList.DefaultBoxSizes[product];

        Instance = null;
    }

    public int MultiplyBoxSize(int originalSize)
        => (int)Mathf.Round(BoxSizeType == BoxSizeType.Multiplier ? originalSize * BoxSizeValue : BoxSizeValue);

    [Command(requiresAuthority = false)]
    public void CmdAddMultipliedProduct(int productIDToAdd) {
        NetworkWriterPooled writer = NetworkWriterPool.Get();
        writer.WriteInt(productIDToAdd);
        SendCommandInternal(CommandName, CommandName.GetStableHashCode(), writer, 0, false);
        NetworkWriterPool.Return(writer);
    }

    protected static void CmdAddMultipliedProductExecute__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection) {
        if (!NetworkServer.active)
            return;

        int productIDToAdd = reader.ReadInt();

        BoxSizePatch.ProductSpawning.ProductsToSpawn.Add(new Tuple<int, bool>(productIDToAdd, true));

        ManagerBlackboard instance = GameData.Instance.GetComponent<ManagerBlackboard>();
        if (instance.isServer && !instance.isSpawning) {
            instance.StartCoroutine(instance.ServerCargoSpawner());
        }
    }

    public override void SerializeSyncVars(NetworkWriter writer, bool forceAll) {
        base.SerializeSyncVars(writer, forceAll);
        if (forceAll) {
            writer.WriteFloat(boxSizeValue);
            writer.WriteByte((byte)boxSizeType);
            return;
        }

        writer.WriteULong(syncVarDirtyBits);

        if ((syncVarDirtyBits & 1L) != 0L)
            writer.WriteFloat(boxSizeValue);

        if ((syncVarDirtyBits & 2L) != 0L)
            writer.WriteByte((byte)boxSizeType);
    }

    public override void DeserializeSyncVars(NetworkReader reader, bool forceAll) {
        base.DeserializeSyncVars(reader, forceAll);
        if (forceAll) {
            GeneratedSyncVarDeserialize(ref boxSizeValue, null, reader.ReadFloat());
            GeneratedSyncVarDeserialize(ref boxSizeType, null, (BoxSizeType)reader.ReadByte());
            return;
        }

        long dirtyBits = (long)reader.ReadULong();

        if ((dirtyBits & 1L) != 0L)
            GeneratedSyncVarDeserialize(ref boxSizeValue, null, reader.ReadFloat());

        if ((dirtyBits & 2L) != 0L)
            GeneratedSyncVarDeserialize(ref boxSizeType, null, (BoxSizeType)reader.ReadByte());
    }
}
