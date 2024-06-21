using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum AssemblySlotType
{
    casing,
    attachment
}
public class CaseComponentSlot : MonoBehaviour, IDropHandler
{
    [Header("Assembly Component Type")]
    public AssemblySlotType assemblySlotType;

    public bool isAssembled = true; // Hide from inspector later
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0) // If there is no item in that slot, drop item into the slot
        {
            Debug.Log("Dropped");
            GameObject droppedItem = eventData.pointerDrag; // Create droppedItem GameObject by using Image that being dragged 
            AssemblyDraggableItem draggableItem = droppedItem.GetComponent<AssemblyDraggableItem>(); // To Do: Find other coding pattern solution to de-coupled. Maybe use Observer?
            draggableItem.parentAfterDrag = transform; // Set Parent after drag to nearest Slot.
        }
    }

   
}
