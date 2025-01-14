using HarmonyLib;
using Mirror;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(ManagerBlackboard))]
public class RemoveBoxSpawnTimePatch {

    [HarmonyPatch("ServerCargoSpawner"), HarmonyPrefix]
    private static bool InstantCargoSpawner(ManagerBlackboard __instance, ref IEnumerator __result) {
        __result = CustomCargoSpawner(__instance);
        return false;
    }

    private static IEnumerator CustomCargoSpawner(ManagerBlackboard instance) {
        instance.isSpawning = true;
        _ = new Vector3(0.3f, 0.3f, 0.45f);

        WaitForSeconds waitTime1;
        WaitForSeconds waitTime2;


        if (BetterSMT.FastBoxSpawns.Value == true) {
            waitTime1 = new WaitForSeconds(0.01f);
            waitTime2 = new WaitForSeconds(0.01f);
        } else {
            waitTime1 = new WaitForSeconds(0.5f);
            waitTime2 = new WaitForSeconds(0.2f);
        }
        while (instance.idsToSpawn.Count > 0) {
            Vector3 spawnPosition = instance.merchandiseSpawnpoint.transform.position + new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
            yield return waitTime1;
            int num = instance.idsToSpawn[0];
            GameObject gameObject = Object.Instantiate(instance.boxPrefab, spawnPosition, Quaternion.identity);
            gameObject.GetComponent<BoxData>().NetworkproductID = num;
            int maxItemsPerBox = instance.GetComponent<ProductListing>().productPrefabs[num].GetComponent<Data_Product>().maxItemsPerBox;
            gameObject.GetComponent<BoxData>().NetworknumberOfProducts = maxItemsPerBox;
            Sprite sprite = instance.GetComponent<ProductListing>().productSprites[num];
            gameObject.transform.Find("Canvas/Image1").GetComponent<Image>().sprite = sprite;
            gameObject.transform.Find("Canvas/Image2").GetComponent<Image>().sprite = sprite;
            gameObject.transform.SetParent(instance.boxParent);
            NetworkServer.Spawn(gameObject);
            instance.RpcParentBoxOnClient(gameObject);
            instance.idsToSpawn.RemoveAt(0);
        }
        yield return waitTime2;
        instance.isSpawning = false;
    }
}
