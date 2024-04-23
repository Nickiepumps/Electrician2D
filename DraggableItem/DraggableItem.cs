using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    private Image itemImage;
    public ElectronicPart part;
    private void Awake()
    {
        itemImage = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        parentAfterDrag = transform.parent; // Set parent to current GameObject Parent when Begin Drag
        transform.SetParent(transform.root); // Set parent to the first child of the parent (Root)
        transform.SetAsLastSibling();
        itemImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; // Move along Mouse position
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        transform.SetParent(parentAfterDrag); // Set Parent to the default parent before dragging
        itemImage.raycastTarget = true;
    }
}
