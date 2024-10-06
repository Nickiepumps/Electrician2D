using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BillDisplay : MonoBehaviour
{
    [Header("Component Scriptable Object")]
    public ElectronicPart component;

    [SerializeField] private TMP_Text itemAmountText;
    public int itemAmount;

    //[HideInInspector]
    public int itemTotalPrice;

    private void Start()
    {
        DisplayBillItem();   
    }
    public void DisplayBillItem()
    {
        transform.Find("ItemList/Item_Image").GetComponent<Image>().sprite = component.partSpriteImage;

        #region ChangePartName
        if (component.electronicType == ItemType.fanswitch_wire_high)
        {
            transform.Find("ItemList/ItemNameEN").GetComponent<TMP_Text>().text = "High Switch";
            transform.Find("ItemList/ItemNameTH").GetComponent<TMP_Text>().text = component.partNameTH;
        }
        else if (component.electronicType == ItemType.fanswitch_wire_medium)
        {
            transform.Find("ItemList/ItemNameEN").GetComponent<TMP_Text>().text = "Medium Switch";
            transform.Find("ItemList/ItemNameTH").GetComponent<TMP_Text>().text = component.partNameTH;
        }
        else if (component.electronicType == ItemType.fanswitch_wire_low)
        {
            transform.Find("ItemList/ItemNameEN").GetComponent<TMP_Text>().text = "Low Switch";
            transform.Find("ItemList/ItemNameTH").GetComponent<TMP_Text>().text = component.partNameTH;
        }
        else if (component.electronicType == ItemType.fanswitch_wire_neutron)
        {
            transform.Find("ItemList/ItemNameEN").GetComponent<TMP_Text>().text = "Neutron Wire";
            transform.Find("ItemList/ItemNameTH").GetComponent<TMP_Text>().text = component.partNameTH;
        }
        else
        {
            transform.Find("ItemList/ItemNameEN").GetComponent<TMP_Text>().text = component.partName;
            transform.Find("ItemList/ItemNameTH").GetComponent<TMP_Text>().text = component.partNameTH;
        }
        #endregion

        transform.Find("Quantity/QuantityValue").GetComponent<TMP_Text>().text = itemAmount.ToString();
        transform.Find("UnitPrice/UnitPriceValue").GetComponent<TMP_Text>().text = component.price.ToString();
        transform.Find("PriceAmount/PriceAmountValue").GetComponent<TMP_Text>().text = itemTotalPrice.ToString();
    }
}
