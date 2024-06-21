using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AssemblyDraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    private Image itemImage;

    // Properties for the Attachment Comp
    private float screwingTime;
    private bool isClicked;

    // AssemblyCondition 
    public AssemblyCondition assemblyConditionInstance;

    public AssembleComponentItem assemblyComponentItem; // Assembly Component ScriptableObject

    private void Awake()
    {
        itemImage = GetComponent<Image>();
    }
    private void Update()
    {
        if(isClicked == true)
        {
            screwingTime -= Time.deltaTime;
            if(screwingTime <= 0)
            {
                Debug.Log("Finished Screw");
                isClicked = false;
            }
        }     
    }

    // Casing Type can be Dragged
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(assemblyComponentItem.assemblyComponentType == AssemblyComponentType.casing)
        {
            if(assemblyConditionInstance.allAttachmentDisassembled == true)
            {
                parentAfterDrag = transform.parent; // Set parent to current GameObject Parent when Begin Drag
                transform.SetParent(transform.root); // Set parent to the first child of the parent (Root)
                transform.SetAsLastSibling();
                itemImage.raycastTarget = false;
            }
            else
            {
                Debug.Log("Unscrew First");
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (assemblyComponentItem.assemblyComponentType == AssemblyComponentType.casing)
        {
            if(assemblyConditionInstance.allAttachmentDisassembled == true)
            {
                Vector3 anchoredPos;
                RectTransformUtility.ScreenPointToWorldPointInRectangle
                    (transform.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out anchoredPos); // Move along Mouse position
                transform.GetComponent<RectTransform>().position = anchoredPos;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (assemblyComponentItem.assemblyComponentType == AssemblyComponentType.casing)
        {
            if(assemblyConditionInstance.allAttachmentDisassembled == true)
            {
                transform.SetParent(parentAfterDrag); // Set Parent to the default parent before dragging
                itemImage.raycastTarget = true;
            }
        }
    }

    // Attachment Type can be Clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if(assemblyComponentItem.assemblyComponentType == AssemblyComponentType.attachment)
        {
            if (isClicked == false)
            {
                isClicked = true;
            }
        }
    }
}
