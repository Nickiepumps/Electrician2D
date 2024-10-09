using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour, IDataPersistance, ISlotDataPersistance
{
    //private List<GameObject> createdPackageList = new List<GameObject>();
    //public List<ElectronicPart> componentsList; 

    public List<GameObject> packageSlots; // Package Slots
    public GameObject packageBox; // PackageBox

    [Header("Package Item Prefab for Save System")]
    public GameObject loadPackageItemPrefeb; // Package Item Prefab for Save System

    public void OpenPackage(GameObject package)
    {
        package.SetActive(true);
    }
    public void ClosePackage(GameObject package)
    {
        CheckAllPackageSlot();
        if(CheckAllPackageSlot() == false)
        {
            packageBox.SetActive(false);
            package.SetActive(false);
        }
        package.SetActive(false);
    }
    private bool CheckAllPackageSlot()
    {
        for(int i = 0; i < packageSlots.Count; i++)
        {
            if(packageSlots[i].transform.childCount != 0)
            {
                return true;
            }
        }
        return false;
    }

    public void SaveData(GameData data)
    {
    }

    public void LoadData(GameData data)
    {
    }

    public void SaveItemSlotData(AllItemSlotData itemData)
    {
        itemData.packageItemsData.Clear();
        itemData.packageItemsIDData.Clear();
        itemData.packageItemComponentData.Clear();
        foreach (GameObject item in packageSlots)
        {
            if (item.transform.childCount != 0)
            {
                itemData.packageItemsData.Add(item.transform.GetChild(0).gameObject);
                itemData.packageItemsIDData.Add(item.GetComponent<NormalPlayerSlot>().packageSlotID);
                itemData.packageItemComponentData.Add(item.GetComponentInChildren<DragableItem>().part);
            }
        }
    }

    public void LoadItemSlotData(AllItemSlotData itemData)
    {
        // Check both Package Slot ID and Package Slot ID Data from the file. If it has the same ID, Assign the Item to that slot.
        for (int i = 0; i < packageSlots.Count; i++)
        {
            for (int j = 0; j < itemData.packageItemsIDData.Count; j++)
            {
                if (packageSlots[i].GetComponent<NormalPlayerSlot>().packageSlotID == itemData.packageItemsIDData[j])
                {
                    GameObject loadedPackageItem = Instantiate(loadPackageItemPrefeb);
                    loadedPackageItem.GetComponent<DragableItem>().part = itemData.packageItemComponentData[j];
                    loadedPackageItem.transform.SetParent(packageSlots[itemData.packageItemsIDData[j]].transform, false);
                }
            }
        }
    }
}
