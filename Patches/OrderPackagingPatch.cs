using HarmonyLib;
using HighlightPlus; 
using System.Collections.Generic;
using UnityEngine;

namespace BetterSMT.Patches {
    [HarmonyPatch(typeof(OrderPackaging))]
    public static class OrderPackagingPatch {
        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        public static bool UpdatePrefix(OrderPackaging __instance) {
            if(!BetterSMT.OrderPackaging.Value) {
                return true;
            }
            float newMaxNumberofDailyOrders = BetterSMT.OrderIncreasedMax.Value != 0 ? BetterSMT.OrderIncreasedMax.Value : __instance.maxNumberOfDailyOrders;
            if(__instance.isServer
                && __instance.isOrderDepartmentActivated
                && GameData.Instance.isSupermarketOpen
                && GameData.Instance.timeOfDay > __instance.nextOrderTime
                && __instance.numberOfAssignedOrders < newMaxNumberofDailyOrders) {
                if(BetterSMT.OrderSpeedUp.Value != 0) {
                    float interval = __instance.orderGenerationInterval + UnityEngine.Random.Range(-0.25f,0.25f);
                    interval /= BetterSMT.OrderSpeedUp.Value;
                    __instance.nextOrderTime = GameData.Instance.timeOfDay + interval;
                } else {
                    __instance.nextOrderTime = GameData.Instance.timeOfDay + (__instance.orderGenerationInterval + UnityEngine.Random.Range(-0.25f,0.25f));
                }

                __instance.GenerateTodayListOfOrders();
            }

            if(!__instance.controllingOrderPackaging || __instance.currentTableIndex < 0) {
                if(__instance.dummyProductOBJ != null) {
                    __instance.DestroyDummyOBJ();
                }
                return false;
            }

            bool button = __instance.MainPlayer.GetButton("Main Action");
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hitInfo,100f,__instance.lMask)) {
                if(!__instance.boxLimitOBJ.activeSelf) {
                    return false;
                }
                if(hitInfo.transform.GetComponent<Data_Product>() != null) {
                    if(hitInfo.transform.parent.CompareTag("AuxiliarOrderTag") && hitInfo.transform.parent.GetSiblingIndex() != __instance.currentTableIndex) {
                        return false;
                    }
                    if(button && __instance.dummyProductOBJ == null) {
                        int productID = hitInfo.transform.GetComponent<Data_Product>().productID;
                        GameObject original = ProductListing.Instance.productPrefabs[productID];
                        __instance.dummyProductOBJ = __instance.currentTableIndex > 1
                            ? Object.Instantiate(original,hitInfo.point,Quaternion.identity)
                            : Object.Instantiate(original,hitInfo.point,Quaternion.Euler(new Vector3(0f,180f,0f)));

                        __instance.dummyHEffect = __instance.dummyProductOBJ.AddComponent<HighlightEffect>();
                        __instance.dummyHEffect.outline = 1f;
                        __instance.dummyHEffect.outlineQuality = HighlightPlus.QualityLevel.Highest;
                        __instance.dummyHEffect.outlineColor = Color.red;

                        __instance.overlappingFSM.FsmVariables.GetFsmGameObject("ProductOBJ").Value = __instance.dummyProductOBJ;
                        __instance.overlappingFSM.enabled = true;

                        BoxCollider component = __instance.dummyProductOBJ.GetComponent<BoxCollider>();
                        component.center += new Vector3(0f,0.005f,0f);
                        if(__instance.dummyProductOBJ.GetComponent<Data_Product>().hasTrueCollider) {
                            component.size = __instance.dummyProductOBJ.GetComponent<Data_Product>().trueCollider - new Vector3(0f,0.01f,0f);
                        } else {
                            component.size -= new Vector3(0f,0.01f,0f);
                        }

                        component.isTrigger = true;
                        component.enabled = true;
                        __instance.dummyProductOBJ.layer = LayerMask.NameToLayer("Water");

                        __instance.productYOffset = component.size.y;
                        __instance.productOffsetArray[0] = new Vector3(component.size.x * 0.75f / 2f,0f,component.size.z * 0.75f / 2f);
                        __instance.productOffsetArray[1] = new Vector3((0f - component.size.x) * 0.75f / 2f,0f,component.size.z * 0.75f / 2f);
                        __instance.productOffsetArray[2] = new Vector3(component.size.x * 0.75f / 2f,0f,(0f - component.size.z) * 0.75f / 2f);
                        __instance.productOffsetArray[3] = new Vector3((0f - component.size.x) * 0.75f / 2f,0f,(0f - component.size.z) * 0.75f / 2f);

                        __instance.dummyProductOBJ.AddComponent<Rigidbody>().isKinematic = true;
                        __instance.dummyHEffect.highlighted = true;
                        __instance.canPlaceItem = false;

                        GameData.Instance.PlayPop2Sound();

                        if(hitInfo.transform.CompareTag("Untagged")) {
                            __instance.PickingItemFromTable(__instance.currentTableIndex,productID);
                        } else {
                            Object.Destroy(hitInfo.transform.gameObject);
                            List<int> list = [];
                            switch(__instance.currentTableIndex) {
                                case 0:
                                    list = __instance.itemsInCurrentBox0;
                                    break;
                                case 1:
                                    list = __instance.itemsInCurrentBox1;
                                    break;
                                case 2:
                                    list = __instance.itemsInCurrentBox2;
                                    break;
                                case 3:
                                    list = __instance.itemsInCurrentBox3;
                                    break;
                            }
                            for(int i = 0; i < list.Count; i++) {
                                if(list[i] == productID) {
                                    list.RemoveAt(i);
                                    break;
                                }
                            }
                            switch(__instance.currentTableIndex) {
                                case 0:
                                    __instance.itemsInCurrentBox0 = list;
                                    break;
                                case 1:
                                    __instance.itemsInCurrentBox1 = list;
                                    break;
                                case 2:
                                    __instance.itemsInCurrentBox2 = list;
                                    break;
                                case 3:
                                    __instance.itemsInCurrentBox3 = list;
                                    break;
                            }
                        }
                    }
                }
                if(__instance.dummyProductOBJ != null) {
                    __instance.dummyProductOBJ.transform.position = hitInfo.point;
                }
            }

            if(__instance.dummyProductOBJ != null) {
                float axisRaw = __instance.MainPlayer.GetAxisRaw("MoveV");
                float axisRaw2 = __instance.MainPlayer.GetAxisRaw("MoveH");
                if(axisRaw2 > 0.1f && !__instance.pressingDirectionalInput) {
                    __instance.dummyProductOBJ.transform.Rotate(0f,90f,0f,Space.World);
                    __instance.pressingDirectionalInput = true;
                } else if(axisRaw2 < -0.1f && !__instance.pressingDirectionalInput) {
                    __instance.dummyProductOBJ.transform.Rotate(0f,-90f,0f,Space.World);
                    __instance.pressingDirectionalInput = true;
                }
                if(__instance.pressingDirectionalInput && axisRaw == 0f && axisRaw2 == 0f) {
                    __instance.pressingDirectionalInput = false;
                }

                Vector3 vector = __instance.boxLimitOBJ.transform.InverseTransformPoint(__instance.dummyProductOBJ.transform.position + new Vector3(0f,0.01f,0f));
                bool flag = false;
                for(int j = 0; j < __instance.productOffsetArray.Length; j++) {
                    if(!Physics.Raycast(__instance.dummyProductOBJ.transform.TransformPoint(__instance.productOffsetArray[j]) + new Vector3(0f,0.01f,0f),Vector3.down,out RaycastHit _,0.02f,__instance.lMask)) {
                        flag = true;
                        break;
                    }
                }

                if(vector.x > -0.33f && vector.x < 0.33f && vector.y > -0.23f && vector.z > -0.49f && vector.z < 0.49f && vector.y + __instance.productYOffset < 0.2f && !__instance.overlappingFSM.FsmVariables.GetFsmBool("Overlapping").Value && !flag) {
                    if(!__instance.canPlaceItem) {
                        __instance.canPlaceItem = true;
                        __instance.dummyHEffect.outlineColor = Color.green;
                    }
                } else if(__instance.canPlaceItem) {
                    __instance.canPlaceItem = false;
                    __instance.dummyHEffect.outlineColor = Color.red;
                }
            }

            if(button || __instance.dummyProductOBJ == null) {
                return false;
            }

            int productID2 = __instance.dummyProductOBJ.GetComponent<Data_Product>().productID;
            if(__instance.canPlaceItem && __instance.currentBoxItemsParentOBJ != null) {
                GameObject gameObject = Object.Instantiate(ProductListing.Instance.productPrefabs[productID2],__instance.currentBoxItemsParentOBJ.transform);
                gameObject.transform.position = __instance.dummyProductOBJ.transform.position;
                gameObject.transform.rotation = __instance.dummyProductOBJ.transform.rotation;
                gameObject.GetComponent<BoxCollider>().enabled = true;
                if(gameObject.GetComponent<Data_Product>().hasTrueCollider) {
                    gameObject.GetComponent<BoxCollider>().size = __instance.dummyProductOBJ.GetComponent<Data_Product>().trueCollider;
                }
                gameObject.tag = "Plant";
                switch(__instance.currentTableIndex) {
                    case 0:
                        __instance.itemsInCurrentBox0.Add(productID2);
                        break;
                    case 1:
                        __instance.itemsInCurrentBox1.Add(productID2);
                        break;
                    case 2:
                        __instance.itemsInCurrentBox2.Add(productID2);
                        break;
                    case 3:
                        __instance.itemsInCurrentBox3.Add(productID2);
                        break;
                }
            } else {
                __instance.RestoreItemToTable(productID2,__instance.currentTableIndex);
            }

            GameData.Instance.PlayPopSound();
            __instance.DestroyDummyOBJ();

            return false;
        }
    }
}
