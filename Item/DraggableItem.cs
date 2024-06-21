using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    private Image itemImage; // Item Image
    public ElectronicPart part; // Electronic Part Scriptable Object

    //[SerializeField] private string itemID; // Item ID for Save and Load Data
    private void Awake()
    {
        itemImage = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent; // Set parent to current GameObject Parent when Begin Drag
        transform.SetParent(transform.root); // Set parent to the first child of the parent (Root)
        transform.SetAsLastSibling();
        itemImage.raycastTarget = false;
        
        if(transform.parent.GetComponent<KeyItemSlot>() != null && part.condition != PartCondition.Broken && transform.parent.childCount == 0)
        {
            transform.parent.GetComponent<KeyItemSlot>().slotType.electronicPart.electronicType = part.electronicType;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Use this when set canvas to Screen Space Mode
        Vector3 anchoredPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle
            (transform.GetComponent<RectTransform>(),Input.mousePosition,Camera.main,out anchoredPos); // Move along Mouse position
        transform.GetComponent<RectTransform>().position = anchoredPos;

        // Use this when set canvas to Overlay mode
        //transform.position = Input.mousePosition; // Move along Mouse position
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag); // Set Parent to the default parent before dragging
        itemImage.raycastTarget = true;
    }
}
