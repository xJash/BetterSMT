using HarmonyLib;
using HutongGames.PlayMaker;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace BetterSMT.Patches
{
    [HarmonyPatch(typeof(NPC_Manager))]
    public class PillarPatch
    {
        [HarmonyPatch("SpawnEmployee"), HarmonyPostfix]
        static void PillarRemovalPatch()    
        {
                if (BetterSMT.RemovePillars.Value == true)
                {
                    HashSet<string> pillarSuffixes = new HashSet<string> { " (6)", " (4)", " (7)" };
                    HashSet<string> beamSuffixes = new HashSet<string> {
                        " (4)", " (13)", " (21)", " (24)", " (26)", " (12)", " (11)", " (2)", " (4)",
                        " (29)", " (33)", " (1)", " (3)", " (5)", " (30)", " (34)"};

                    UnityEngine.Object[] allObjects = Object.FindObjectsOfType<UnityEngine.Object>();

                    var allPillars = allObjects.Where(pillar => pillar.name.StartsWith("Pillar_BeamCross") && pillarSuffixes.Any(suffix => pillar.name.EndsWith(suffix))).ToArray();
                    var allBeams = allObjects.Where(pillar => pillar.name.StartsWith("Beam") && beamSuffixes.Any(suffix => pillar.name.EndsWith(suffix))).ToArray();
                    var extraBeam = allObjects.Where(pillar => pillar.name.Equals("Beam")).ToArray();

                    foreach (var obj in allPillars.Concat(allBeams).Concat(extraBeam))
                    {
                        Object.Destroy(obj);
                    }
                
            }
        }
    }
}