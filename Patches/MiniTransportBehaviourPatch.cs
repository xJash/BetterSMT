using HarmonyLib;
using Mirror;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch]
public static class VehicleBoxManagerPatch
{
    private static readonly Dictionary<GameObject,
    float> recentlyDropped = [];
    private static readonly List<GameObject> loadedBoxes = [];

    private static class BoxLayout
    {
        public const int Columns = 2;
        public const int Rows = 2;
        public const float XSpacing = 0.6f;
        public const float YSpacing = 0.4f;
        public const float ZSpacing = 0.6f;
        public const float BaseY = 0.8f;
        public const float BackOffsetZ = -1.3f;
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(MiniTransportBehaviour), nameof(MiniTransportBehaviour.Update))]
    public static void VehicleUpdatePostfix(MiniTransportBehaviour __instance)
    {
        if (!BetterSMT.EnableMTV.Value)
        {
            return;
        }

        if (!__instance.isActiveAndEnabled)
        {
            return;
        }

        TryPickupNearbyBoxes(__instance);

        if (Input.GetKeyDown(BetterSMT.MTVHotkey.Value.MainKey))
        {
            _ = DropBoxesSequentially(__instance);
        }
    }

    private static void TryPickupNearbyBoxes(MiniTransportBehaviour vehicle)
    {
        int currentCount = loadedBoxes.Count;
        if (currentCount >= BetterSMT.MaxBoxes.Value)
        {
            return;
        }

        Collider[] nearby = Physics.OverlapSphere(vehicle.transform.position, BetterSMT.AutoPickupRange.Value);
        float currentTime = Time.time;

        foreach (Collider col in nearby)
        {
            if (!col.TryGetComponent(out BoxData box) || loadedBoxes.Contains(box.gameObject))
            {
                continue;
            }

            if (!box.TryGetComponent(out NetworkIdentity _))
            {
                continue;
            }

            if (recentlyDropped.TryGetValue(box.gameObject, out float dropTime) && (currentTime - dropTime < BetterSMT.DropCooldown.Value))
            {
                continue;
            }

            _ = recentlyDropped.Remove(box.gameObject);

            if (loadedBoxes.Count >= BetterSMT.MaxBoxes.Value)
            {
                break;
            }

            box.transform.SetParent(vehicle.transform);
            box.transform.localPosition = GetNextLoadPosition(loadedBoxes.Count);

            Rigidbody rb = box.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            bool isBackRow = (loadedBoxes.Count % 4) >= 2;
            box.transform.localRotation = isBackRow ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity;

            loadedBoxes.Add(box.gameObject);
        }
    }

    private static Vector3 GetNextLoadPosition(int index)
    {
        int layer = index / (BoxLayout.Columns * BoxLayout.Rows);
        int layerIndex = index % (BoxLayout.Columns * BoxLayout.Rows);

        int column = layerIndex % BoxLayout.Columns;
        int row = layerIndex / BoxLayout.Columns;

        float x = (column * BoxLayout.XSpacing) - (BoxLayout.XSpacing / 2);
        float y = BoxLayout.BaseY + (layer * BoxLayout.YSpacing);
        float z = BoxLayout.BackOffsetZ - (row * BoxLayout.ZSpacing);

        return new Vector3(x, y, z);
    }

    private static async Task DropBoxesSequentially(MiniTransportBehaviour vehicle)
    {
        if (loadedBoxes.Count == 0)
        {
            return;
        }

        const float spacing = 0.4f;
        const int boxesPerRow = 3;
        const float dropDelay = 0.15f;

        Vector3 dropOrigin = vehicle.transform.position + (vehicle.transform.up * 1.0f);

        for (int i = 0; i < loadedBoxes.Count; i++)
        {
            GameObject box = loadedBoxes[i];
            if (box == null)
            {
                continue;
            }

            int row = i / boxesPerRow;
            int col = i % boxesPerRow;

            Vector3 offset = (vehicle.transform.right * ((col * spacing) - spacing)) + (vehicle.transform.forward * (row * spacing)) + (vehicle.transform.up * (row * spacing * 0.5f));

            Vector3 finalPos = dropOrigin + offset;

            box.transform.SetParent(null);
            box.transform.position = finalPos;
            box.transform.rotation = Quaternion.LookRotation(vehicle.transform.forward, Vector3.up);

            Rigidbody rb = box.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            DelayedUnfreeze(box, 0.3f);

            await Task.Delay((int)(dropDelay * 1000));
        }

        loadedBoxes.Clear();
        BetterSMT.CreateImportantNotification("Boxes emptied from vehicle.");
    }

    private static async void DelayedUnfreeze(GameObject box, float delay)
    {
        await Task.Delay((int)(delay * 1000));

        if (box != null)
        {
            Rigidbody rb = box.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            recentlyDropped[box] = Time.time;
        }
    }
}