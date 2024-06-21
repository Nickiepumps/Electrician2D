using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemDetailBox : MonoBehaviour, IPointerExitHandler, IPointerMoveHandler
{
    [Header("Item Detail Box Prefab")]
    [SerializeField] private GameObject detailBoxPrefab;
    private Vector3 offset = new Vector3(2.5f, 2, 0); // Detail Box Position offset

    public void OnPointerExit(PointerEventData eventData)
    {
        detailBoxPrefab.SetActive(false);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        GameObject item = eventData.pointerEnter;
        if(item.GetComponent<DragableItem>() != null)
        {
            detailBoxPrefab.SetActive(true);

            Vector3 anchoredPos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle
                (detailBoxPrefab.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out anchoredPos); // Move along Mouse position
            detailBoxPrefab.transform.GetComponent<RectTransform>().position = anchoredPos + offset;

            // Display Component Details
            detailBoxPrefab.transform.Find("ImagePanel/ItemImage").GetComponent<Image>().sprite = item.GetComponentInChildren<DragableItem>().part.partSpriteImage;
            detailBoxPrefab.transform.Find("ItemNamePanel/CompName").GetComponent<TMP_Text>().text = item.GetComponentInChildren<DragableItem>().part.partName;
            detailBoxPrefab.transform.Find("ConditionDetailPanel/CurrentConditionText").GetComponent<TMP_Text>().text = item.GetComponentInChildren<DragableItem>().part.condition.ToString();
            detailBoxPrefab.transform.Find("SerialNoPanel/SerialNumberText").GetComponent<TMP_Text>().text = item.GetComponentInChildren<DragableItem>().part.serialNumber;
            detailBoxPrefab.transform.Find("VoltagePanel/VoltageValueText").GetComponent<TMP_Text>().text = item.GetComponentInChildren<DragableItem>().part.voltage.ToString();
            if(item.GetComponent<DragableItem>().part.electronicType == ItemType.capacitor)
            {
                detailBoxPrefab.transform.Find("SpecificDetailPanel/SpecificValueText").GetComponent<TMP_Text>().text = item.GetComponentInChildren<DragableItem>().part.farad.ToString() + " Farad";
            }
            else if(item.GetComponent<DragableItem>().part.electronicType == ItemType.thermostat)
            {
                detailBoxPrefab.transform.Find("SpecificDetailPanel/SpecificValueText").GetComponent<TMP_Text>().text = item.GetComponentInChildren<DragableItem>().part.operatingTemperature.ToString();
            }
            detailBoxPrefab.transform.Find("DescriptionPanel/Description").GetComponent<TMP_Text>().text = item.GetComponentInChildren<DragableItem>().part.partDesc;
        }
        else if(item.transform.childCount == 0)
        {
            detailBoxPrefab.SetActive(false);
        }
    }
}
