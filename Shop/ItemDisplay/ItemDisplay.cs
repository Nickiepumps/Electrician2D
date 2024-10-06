using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    [Header("Component Scriptable Object")]
    public ElectronicPart component;

    [SerializeField] private TMP_Text itemAmountText;
    public int itemAmount;

    [HideInInspector]
    public int itemTotalPrice;

    [SerializeField] private bool forDetail; // boolean use for display item in the shop or in the detail area
    [SerializeField] private bool forCart; // boolean use for display item in cart area
    private void Start()
    {
        if(forDetail == false && forCart == false)
        {
            itemTotalPrice = component.price;
        }
        if(forDetail == false || forCart == true)
        {
            DisplayShopItem();
        }
    }
    private void DisplayShopItem()
    {
        if(forCart == false)
        {
            itemAmountText.text = "0";
            transform.Find("Price/PriceValue").GetComponent<TMP_Text>().text = component.price.ToString();
        }
        transform.Find("BG_ItemDisplay/Image_Item").GetComponent<Image>().sprite = component.partSpriteImage;

        #region ChangePartName
        if (component.electronicType == ItemType.fanswitch_wire_high)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "High Switch";
        }
        else if (component.electronicType == ItemType.fanswitch_wire_medium)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "Medium Switch";
        }
        else if (component.electronicType == ItemType.fanswitch_wire_low)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "Low Switch";
        }
        else if (component.electronicType == ItemType.fanswitch_wire_neutron)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "Neutron Wire";
        }
        else
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = component.partName;
        }
        #endregion
    }
    public void DisplayDetailItem(ElectronicPart component)
    {
        transform.Find("BG_ItemDisplay/Image_Item").GetComponent<Image>().sprite = component.partSpriteImage;
        if (component.electronicType == ItemType.fanswitch_wire_high)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "High Switch";
        }
        else if (component.electronicType == ItemType.fanswitch_wire_medium)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "Medium Switch";
        }
        else if (component.electronicType == ItemType.fanswitch_wire_low)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "Low Switch";
        }
        else if (component.electronicType == ItemType.fanswitch_wire_neutron)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "Neutron Wire";
        }
        else
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = component.partName;
        }
        transform.Find("ItemDescriptionPanel/DetailArea/DetailContent/Text_Description").GetComponent<TMP_Text>().text = component.partDesc;
        transform.Find("Price/PriceValue").GetComponent<TMP_Text>().text = component.price.ToString();
    }
    public void IncreaseAmount()
    {
        if(itemAmount >= 10)
        {
            itemAmount = 10;
            itemAmountText.text = itemAmount.ToString();
        }
        else
        {
            itemAmount++;
            itemAmountText.text = itemAmount.ToString();
        }
    }
    public void DecreaseAmount()
    {
        if(itemAmount <= 0)
        {
            itemAmount = 0;
            itemAmountText.text = itemAmount.ToString();
        }
        else
        {
            itemAmount--;
            itemAmountText.text = itemAmount.ToString();
        }
    }
    public void UpdateComponent(ElectronicPart component)
    {
        transform.Find("BG_ItemDisplay/Image_Item").GetComponent<Image>().sprite = component.partSpriteImage;

        #region ChangePartName
        if (component.electronicType == ItemType.fanswitch_wire_high)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "High Switch";
        }
        else if (component.electronicType == ItemType.fanswitch_wire_medium)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "Medium Switch";
        }
        else if (component.electronicType == ItemType.fanswitch_wire_low)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "Low Switch";
        }
        else if (component.electronicType == ItemType.fanswitch_wire_neutron)
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = "Neutron Wire";
        }
        else
        {
            transform.Find("BG_ItemName/ItemName").GetComponent<TMP_Text>().text = component.partName;
        }
        #endregion
    }
}
