using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyItemSlot : MonoBehaviour, IDropHandler
{
    public ElectronicPart type;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        GameObject droppedItem = eventData.pointerDrag; // Create droppedItem GameObject by using Image that being dragged 
        DragableItem draggableItem = droppedItem.GetComponent<DragableItem>(); // To Do: Find other coding pattern solution to de-coupled. Maybe use Observer?
        if(draggableItem.part.partType.partType == type.partType.partType) // Check Electronic part type of draggableItem to see if it has same type as slot's Electronic part type
        {
            draggableItem.parentAfterDrag = transform; // Set Parent after drag to nearest Slot.
        }
        else
        {
            Debug.Log("Type not matched");
        }
    }
}
