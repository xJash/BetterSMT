﻿using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(ManagerBlackboard))]
public class RemoveBoxSpawnTimePatch {

    [HarmonyPatch("ServerCargoSpawner", MethodType.Enumerator), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> InstantCargoSpawner(IEnumerable<CodeInstruction> instructions) {
        return BetterSMT.FastBoxSpawns.Value ?
            new CodeMatcher(instructions)

                // Replace new WaitForSeconds(x) with new WaitForSeconds(0.01f)
                .Start()
                .MatchForward(false, new CodeMatch(OpCodes.Newobj, AccessTools.Constructor(typeof(WaitForSeconds), [typeof(float)])))
                .Repeat(matcher => {
                    matcher.Advance(-1);
                    matcher.SetOperandAndAdvance(0.01f);
                    matcher.Advance(1);
                })
                .InstructionEnumeration() :

            instructions;
    }
}
