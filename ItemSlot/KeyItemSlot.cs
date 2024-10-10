using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyItemSlot : MonoBehaviour, IDropHandler
{
    public ElectronicSlot slotType; // Electronic Slot for inspection system
    public bool isFixed; // Electronic Slot Condition
    private void Start()
    {
        InvokeRepeating("UpdateCondition", 2f, 0.5f); // Repeat "UpdateCondition" method every 0.5 secs
    }
    private void UpdateCondition() // Update Current Slot Condition
    {
        if (transform.childCount == 0 || isFixed == false) // Slot Condition is not fixed if there is no Electronic part in the slot
                                                           // Or it is set to false by default
        {
            isFixed = false;
        }
        else
        {
            isFixed = true;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag; // Create droppedItem GameObject by using Image that being dragged 
        DragableItem draggableItem = droppedItem.GetComponent<DragableItem>(); // To Do: Find other Design pattern solution to de-coupled. Maybe use Observer?
        
        if (draggableItem.part.electronicType == slotType.electronicPart.electronicType
            && transform.childCount == 0 && draggableItem.part.condition != PartCondition.Broken) // Check Electronic part type of draggableItem. If it has same type as slot's Electronic part type and not broken 
        {
            if (slotType.electronicPart.electronicType == ItemType.capacitor)
            {
                if (draggableItem.part.farad < slotType.electronicPart.farad || draggableItem.part.farad > slotType.electronicPart.farad) // If dragged Electronic part has lower or higher value
                                                                                                                                          // Assign into the slot but not get a perfect score
                {
                    draggableItem.parentAfterDrag = transform; // Set Parent after drag to nearest Slot.
                    isFixed = true; // Change Slot Condition to Fixed
                    Debug.Log("Work but not Perfect 8/10");
                }
                else // If dragged Electronic part has same value
                     // Assign into the slot and get a perfect score
                {
                    draggableItem.parentAfterDrag = transform; // Set Parent after drag to nearest Slot.
                    isFixed = true;
                    Debug.Log("Work Perfectly! 10/10");
                }
            }
            else if (slotType.electronicPart.electronicType == ItemType.resistor)
            {
                if (draggableItem.part.ohm < slotType.electronicPart.ohm || draggableItem.part.ohm > slotType.electronicPart.ohm) // If dragged Electronic part has lower or higher value
                                                                                                                                  // Assign into the slot but not get a perfect score
                {
                    draggableItem.parentAfterDrag = transform; // Set Parent after drag to nearest Slot.
                    isFixed = true;
                    Debug.Log("Work but not Perfect 8/10");
                }
                else // If dragged Electronic part has same value
                     // Assign into the slot and get a perfect score
                {
                    draggableItem.parentAfterDrag = transform; // Set Parent after drag to nearest Slot.
                    isFixed = true;
                    Debug.Log("Work Perfectly! 10/10");
                }
            }
        }
        else
        {
            Debug.Log("Type not matched");
        }
    }
}
