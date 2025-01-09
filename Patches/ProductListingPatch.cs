using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(ProductListing))]
public class ProductListingPatch {

    [HarmonyPatch(typeof(ProductListing))]
    public class PillarPatch {
        [HarmonyPatch("OnStartClient"), HarmonyPostfix]
        private static void PillarRemovalPatch() {
            if (BetterSMT.RemovePillars.Value == true) {
                HashSet<string> pillarSuffixes = [" (6)", " (4)", " (7)"];
                HashSet<string> beamSuffixes = [ " (4)", " (13)", " (21)", " (24)", " (26)", " (12)", " (11)", " (2)", " (4)",
                        " (29)", " (33)", " (1)", " (3)", " (5)", " (30)", " (34)"];

                UnityEngine.Object[] allObjects = Object.FindObjectsOfType<UnityEngine.Object>();

                Object[] allPillars = allObjects.Where(pillar => pillar.name.StartsWith("Pillar_BeamCross") && pillarSuffixes.Any(suffix => pillar.name.EndsWith(suffix))).ToArray();
                Object[] allBeams = allObjects.Where(pillar => pillar.name.StartsWith("Beam") && beamSuffixes.Any(suffix => pillar.name.EndsWith(suffix))).ToArray();
                Object[] extraBeam = allObjects.Where(pillar => pillar.name.Equals("Beam")).ToArray();

                foreach (Object obj in allPillars.Concat(allBeams).Concat(extraBeam)) {
                    Object.Destroy(obj);
                }

            }
        }
    }
}