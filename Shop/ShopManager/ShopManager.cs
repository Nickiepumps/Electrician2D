using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private Dictionary<ElectronicPart, int> shopDictionary = new Dictionary<ElectronicPart, int>(); // Shop Dictionary contain
                                                                                                    // ElectronicPart and Amount
    private int totalPrice = 0; // Total price of added Item

    [Header("Item Display in Shop")]
    public ItemDisplay[] itemAmount; // All Item Amount integer in the menu

    [Header("Player Credit Manager")]
    public PlayerManager playerManager; // Player Credit (To Do: Find Other solution without direct reference)

    [Header("Packages")]
    public GameObject packageBox; // Item Packages GameObject TO DO : Delete this packageBox ref later
    public GameObject purchaseItem; // Purchased Item for Instantiate
    public PackageManager packageManager; // PackageManager slots

    [Header("Text Display")]
    public TMP_Text totalPriceText; // Price text
    public TMP_Text playerCredit; // Player Credit
    private void Start()
    {
        totalPriceText.text = "0";
        playerCredit.text = playerManager.playerCredit.ToString();
    }
    private void Update()
    {
        totalPriceText.text = totalPrice.ToString();
        playerCredit.text = playerManager.playerCredit.ToString();
    }
    public void AddItem(ElectronicPart electronicPart)
    {
        if (shopDictionary.ContainsKey(electronicPart))
        {
            if(shopDictionary[electronicPart] >= 10)
            {
                shopDictionary[electronicPart] = 10;
            }
            else
            {
                shopDictionary[electronicPart]++;
                totalPrice += electronicPart.price;
            }
        }
        else
        {
            shopDictionary.Add(electronicPart, 1);
            totalPrice += electronicPart.price;
        }
        Debug.Log(totalPrice);
    }
    public void DecreaseItem(ElectronicPart electronicPart)
    {
        if (shopDictionary.ContainsKey(electronicPart))
        {
            if(shopDictionary[electronicPart] <= 0)
            {
                shopDictionary.Remove(electronicPart);
            }
            else
            {
                shopDictionary[electronicPart]--;
                totalPrice -= electronicPart.price;
            }
        }
        Debug.Log(totalPrice);
    }
    public void PurchaseItem()
    {
        packageBox.SetActive(true);
        if (totalPrice <= playerManager.playerCredit)
        {
            playerManager.playerCredit -= totalPrice;
            foreach (var electronicPart in shopDictionary.Keys)
            {
                for (int i = 0; i < shopDictionary[electronicPart]; i++)
                {
                    purchaseItem.GetComponent<DragableItem>().part = electronicPart; // Assign Electronic Part Scriptable Object to the prefab
                    GameObject purchasedItem = Instantiate(purchaseItem);
                    PackageSlotCheck(purchasedItem);
                }
            }
        }        
    }
    private bool PackageSlotCheck(GameObject item)
    {
        for (int j = 0; j < packageManager.packageSlots.Length; j++)
        {
            if (packageManager.packageSlots[j].transform.childCount == 0) // Assign GameObject to the Package slot as a child
            {
                item.transform.SetParent(packageManager.packageSlots[j].transform, false);
                return true;
            }
        }
        Debug.Log("Slot Full");
        playerManager.playerCredit += item.GetComponent<DragableItem>().part.price;
        Destroy(item);
        return false;
    }
    public void ClearItem()
    {
        foreach(var amount in itemAmount) // Reset itemAmount value to 0 if value > 0
        {
            if(amount.itemAmount > 0)
            {
                amount.itemAmount = 0;
            }
        }
        totalPrice = 0;
        shopDictionary.Clear();
    }
    public void OpenShop(GameObject shopMenu)
    {
        shopMenu.SetActive(true);
    }
    public void CloseShop(GameObject shopMenu)
    {
        foreach (var amount in itemAmount) // Reset itemAmount value to 0 if value > 0
        {
            if (amount.itemAmount > 0)
            {
                amount.itemAmount = 0;
            }
        }
        totalPrice = 0;
        shopDictionary.Clear();
        shopMenu.SetActive(false);
    }
}
