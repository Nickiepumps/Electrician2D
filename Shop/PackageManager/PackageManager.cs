using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public GameObject[] packageSlots; // Package Slots
    public GameObject packageBox; // PackageBox
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
        for(int i = 0; i < packageSlots.Length; i++)
        {
            if(packageSlots[i].transform.childCount != 0)
            {
                return true;
            }
        }
        return false;
    }
}
