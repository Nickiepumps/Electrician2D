using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplianceCondition : MonoBehaviour
{
    [Header("Electronic Part Slot")]
    public KeyItemSlot[] electronicSlots; // TO DO: Find better solution, Try to Instantiate ApplianceSO with KeyItemSlot next time

    private List<bool> slotConditions = new List<bool>();

    [Header("Appliance Condition")]
    public bool isFixed;
    private void Start()
    {
        for(int i = 0; i < electronicSlots.Length; i++)
        {
            slotConditions.Add(electronicSlots[i].isFixed);
        }
    }
    private void Update()
    {
        for(int i = 0; i < electronicSlots.Length; i++)
        {
            if (electronicSlots[i].isFixed == false)
            {
                slotConditions[i] = false;
            }
            else if (electronicSlots[i].isFixed == true)
            {
                slotConditions[i] = true;
            }       
        }
        CheckAllSlotsCondition();
        if(CheckAllSlotsCondition() == true)
        {
            isFixed = true;
        }
        else
        {
            isFixed = false;
        }
    }
    private bool CheckAllSlotsCondition()
    {
        for (int i = 0; i < slotConditions.Count; i++)
        {
            if (slotConditions[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
