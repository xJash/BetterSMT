using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BetterSMT.Patches {
    [HarmonyPatch(typeof(Builder_Main))]
    public static class BuilderInjector {
        [HarmonyPatch("Update"), HarmonyPostfix]
        public static void GameStartSetPerksPatch() {
            if (Input.GetKeyDown(KeyCode.F1)) {
                _ = BetterSMT.Instance.StartCoroutine(AddCustomBuildablesCoroutine());
            }
        }

        private static IEnumerator AddCustomBuildablesCoroutine() {
            yield return new WaitForSeconds(1f);
            Builder_Main builder = GameCanvas.Instance?.GetComponent<Builder_Main>();
            FieldInfo field = typeof(Builder_Main).GetField("buildablesArray", BindingFlags.NonPublic | BindingFlags.Instance);
            object rawValue = field.GetValue(builder);
            if (rawValue is not GameObject[] existingBuildables) yield break;
            List<GameObject> newBuildables = [.. existingBuildables];

            foreach (BuildableDefinition def in BuildableRegistry.CustomBuildables) {
                GameObject clone = CreateTemplateBasedBuildable(def);
                clone.SetActive(false);
                newBuildables.Add(clone);
            }

            field.SetValue(builder, newBuildables.ToArray());
            _ = typeof(Builder_Main).GetMethod("ReassignBuildablesData", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            builder.gameObject.SetActive(false);
            yield return null;
            builder.gameObject.SetActive(true);

            MethodInfo retrieveMethod = typeof(Builder_Main).GetMethod("RetrieveInitialBehaviours", BindingFlags.NonPublic | BindingFlags.Instance);
            if (retrieveMethod != null)  _ = builder.StartCoroutine((IEnumerator)retrieveMethod.Invoke(builder, null));
        }

        private static GameObject CreateTemplateBasedBuildable(BuildableDefinition def) {
            GameObject template = GameObject.Find("Level_SupermarketProps/DecorationProps/2_PottedPlant1");
            GameObject clone = Object.Instantiate(template);
            clone.name = $"Builder_{def.DisplayName}";
            foreach (Transform child in clone.transform) Object.Destroy(child.gameObject);
            GameObject main = GameObject.Find(def.MainPath);
            GameObject mainVisual = Object.Instantiate(main, clone.transform, false);
            mainVisual.name = "Visual";

            if (def.DependentPaths != null) {
                foreach (string path in def.DependentPaths) {
                    GameObject dep = GameObject.Find(path);
                    GameObject depClone = Object.Instantiate(dep, clone.transform, false);
                    depClone.name = $"Dep_{dep.name}";
                }
            }

            clone.tag = "Buildable";
            clone.layer = LayerMask.NameToLayer("Interactable");
            _ = clone.AddComponent<BetterSMTCustomBuildable>();
            return clone;
        }
    }

    public class BuildableDefinition {
        public string MainPath;
        public string[] DependentPaths;
        public string DisplayName;
        public Sprite Icon;

        public BuildableDefinition(string mainPath, string displayName, Sprite icon = null) {
            MainPath = mainPath;
            DisplayName = displayName;
            Icon = icon;
        }

        public BuildableDefinition(string mainPath, string[] dependentPaths, string displayName, Sprite icon = null) {
            MainPath = mainPath;
            DependentPaths = dependentPaths;
            DisplayName = displayName;
            Icon = icon;
        }
    }

    public static class BuildableRegistry {
        public static List<BuildableDefinition> CustomBuildables =
        [
            new BuildableDefinition("Level_Supermarket/Furniture/WetFloor_fxi69q", "Wet Floor Sign"),
            new BuildableDefinition("Interactables/ESwitch", "Emergency Switch"),
            new BuildableDefinition("GachaPlace", "Gacha Machine"),
            new BuildableDefinition("Level_Supermarket/Neon_Open", "Open Sign"),
            new BuildableDefinition("Furniture/Slate_t3iqt", new[] { "Interactables/Canvas_Manager" }, "Slate with Manager Canvas"),
            new BuildableDefinition("Level_Supermarket/Furniture/Whiteboard", new[] { "Interactables/Canvas_Upgrades" }, "Whiteboard with Upgrades"),
            new BuildableDefinition("Furniture/Board", new[] { "Interactables/Canvas_Expansions" }, "Expansion Board"),
            new BuildableDefinition("Level_Exterior/Trash_Normal/Dumpster Lid 01", new[] { "Level_Exterior/Trash_Normal/Dumpster Lid 02" }, "Dual Dumpster Lids"),
        ];
    }

    public class BetterSMTCustomBuildable : MonoBehaviour {
        // maybefuturedecoration
    }
}
