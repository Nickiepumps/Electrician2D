using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private Dictionary<ElectronicPart, int> shopDictionary = new Dictionary<ElectronicPart, int>(); // Shop Dictionary contain
                                                                                                    // ElectronicPart and Amount

    private int totalPrice = 0; // Total price of added Item

    [Header("Windows")]
    public GameObject shopWindow;
    public GameObject cartWindow;
    public GameObject billWindow;
    public GameObject detailWindow;

    [Header("Item Display in Shop")]
    public ItemDisplay[] itemAmount; // All Item Amount integer in the menu
    [SerializeField] GameObject goToCartButton; // GotoCart Button

    [Header("Item Display in Cart")]
    [SerializeField] private GameObject cartItemDisplaySlotPrefab; // Cart item display slot prefab
    [SerializeField] private GameObject cartItemDisplayContent; // Scroll Panel for cartItemDisplayPrefab parent ref
    public List<GameObject> cartItemDisplaysList; // cartItemDisplay list use when same item add/decrease into the cart

    [Header("Bill Display Item")]
    [SerializeField] private GameObject billItemDisplayPrefab; // Bill item display prefab
    [SerializeField] private GameObject billItemDisplayContent; // Scroll panel for billItemDisplay

    [Header("Player Credit Manager")]
    public PlayerManager playerManager; // Player Credit (To Do: Find Other solution without direct reference)

    [Header("Packages")]
    public GameObject packageBox; // Item Packages GameObject TO DO : Delete this packageBox ref later
    public GameObject purchaseItem; // Purchased Item for Instantiate
    public PackageManager packageManager; // PackageManager slots

    [Header("Text And Button Display")]
    public TMP_Text totalPriceText; // Price text
    [SerializeField] private GameObject totalPricePanel; // Total Price Panel
    [SerializeField] private GameObject clearListButton; // Clear item list button
    public TMP_Text playerCredit; // Player Credit

    [Header("Audio")]
    [SerializeField] private AudioSource purchaseSound;

    private ElectronicPart currentDetailComponentItem; // Current Component in detail window

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
            if (shopDictionary[electronicPart] >= 10)
            {
                shopDictionary[electronicPart] = 10;
            }
            else
            {
                // Same item added
                shopDictionary[electronicPart]++;
                totalPrice += electronicPart.price;

                foreach(GameObject cartItem in cartItemDisplaysList)
                {
                    if(cartItem.GetComponent<ItemDisplay>().component == electronicPart 
                        && cartItem.GetComponent<ItemDisplay>().component.serialNumber == electronicPart.serialNumber)
                    {
                        cartItem.GetComponent<ItemDisplay>().itemAmount++;
                        cartItem.GetComponent<ItemDisplay>().itemTotalPrice += electronicPart.price;
                        cartItem.transform.Find("BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = cartItem.GetComponent<ItemDisplay>().itemAmount.ToString();
                        cartItem.transform.Find("Price/PriceValue").GetComponent<TMP_Text>().text = cartItem.GetComponent<ItemDisplay>().itemTotalPrice.ToString();
                    }
                }
            }
        }
        else
        {
            // New item added
            shopDictionary.Add(electronicPart, 1);
            totalPrice += electronicPart.price;

            // Create Display Item Slot to the cart
            CreateItemDisplay(electronicPart);
        }
        Debug.Log(totalPrice);
    }
    public void DecreaseItem(ElectronicPart electronicPart)
    {
        if (shopDictionary.ContainsKey(electronicPart))
        {
            if (shopDictionary[electronicPart] <= 1)
            {
                foreach (GameObject cartItem in cartItemDisplaysList)
                {
                    GameObject destroyedItem;
                    if (cartItem.GetComponent<ItemDisplay>().component == electronicPart
                        && cartItem.GetComponent<ItemDisplay>().component.serialNumber == electronicPart.serialNumber)
                    {
                        destroyedItem = cartItem;
                        totalPrice -= electronicPart.price;
                        cartItemDisplaysList.Remove(cartItem);
                        Destroy(destroyedItem);
                        shopDictionary.Remove(electronicPart);
                        return;
                    }
                }
            }
            else
            {
                foreach (GameObject cartItem in cartItemDisplaysList)
                {
                    if (cartItem.GetComponent<ItemDisplay>().component == electronicPart
                        && cartItem.GetComponent<ItemDisplay>().component.serialNumber == electronicPart.serialNumber)
                    {
                        cartItem.GetComponent<ItemDisplay>().itemAmount--;
                        cartItem.GetComponent<ItemDisplay>().itemTotalPrice -= electronicPart.price;
                        cartItem.transform.Find("BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = cartItem.GetComponent<ItemDisplay>().itemAmount.ToString();
                        cartItem.transform.Find("Price/PriceValue").GetComponent<TMP_Text>().text = cartItem.GetComponent<ItemDisplay>().itemTotalPrice.ToString();
                    }
                }
                shopDictionary[electronicPart]--;
                totalPrice -= electronicPart.price;
            }
        }
        Debug.Log(totalPrice);
    }
    public void AddItem_DetailWindow()
    {
        if (shopDictionary.ContainsKey(currentDetailComponentItem))
        {
            if (shopDictionary[currentDetailComponentItem] >= 10)
            {
                shopDictionary[currentDetailComponentItem] = 10;
            }
            else
            {
                foreach (var shopItem in itemAmount)
                {
                    if (shopItem.component == currentDetailComponentItem
                        && shopItem.component.serialNumber == currentDetailComponentItem.serialNumber)
                    {
                        shopItem.itemAmount++;
                        shopItem.gameObject.transform.Find("BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = shopItem.itemAmount.ToString();
                    }
                }
                foreach (GameObject cartItem in cartItemDisplaysList)
                {
                    if (cartItem.GetComponent<ItemDisplay>().component == currentDetailComponentItem
                        && cartItem.GetComponent<ItemDisplay>().component.serialNumber == currentDetailComponentItem.serialNumber)
                    {
                        cartItem.GetComponent<ItemDisplay>().itemAmount++;
                        cartItem.GetComponent<ItemDisplay>().itemTotalPrice += currentDetailComponentItem.price;
                        cartItem.transform.Find("BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = cartItem.GetComponent<ItemDisplay>().itemAmount.ToString();
                        cartItem.transform.Find("Price/PriceValue").GetComponent<TMP_Text>().text = cartItem.GetComponent<ItemDisplay>().itemTotalPrice.ToString();
                    }
                }
                shopDictionary[currentDetailComponentItem]++;
                totalPrice += currentDetailComponentItem.price;
            }
        }
        else
        {
            shopDictionary.Add(currentDetailComponentItem, 1);
            totalPrice += currentDetailComponentItem.price;

            // Create Display Item Slot to the cart
            CreateItemDisplay(currentDetailComponentItem);
            foreach(var shopItem in itemAmount)
            {
                if(shopItem.component == currentDetailComponentItem 
                    && shopItem.component.serialNumber == currentDetailComponentItem.serialNumber)
                {
                    shopItem.itemAmount++;
                    shopItem.gameObject.transform.Find("BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = shopItem.itemAmount.ToString();
                }
            } 
        }
        Debug.Log(totalPrice);
    }
    public void DecreaseItem_DetailWindow()
    {
        if (shopDictionary.ContainsKey(currentDetailComponentItem))
        {
            if (shopDictionary[currentDetailComponentItem] <= 1)
            {
                foreach (GameObject cartItem in cartItemDisplaysList)
                {
                    GameObject destroyedItem;
                    if (cartItem.GetComponent<ItemDisplay>().component == currentDetailComponentItem
                        && cartItem.GetComponent<ItemDisplay>().component.serialNumber == currentDetailComponentItem.serialNumber)
                    {
                        destroyedItem = cartItem;
                        totalPrice -= currentDetailComponentItem.price;
                        cartItemDisplaysList.Remove(cartItem);
                        Destroy(destroyedItem);
                        shopDictionary.Remove(currentDetailComponentItem);
                        return;
                    }
                }
            }
            else
            {
                foreach (GameObject cartItem in cartItemDisplaysList)
                {
                    if (cartItem.GetComponent<ItemDisplay>().component == currentDetailComponentItem
                        && cartItem.GetComponent<ItemDisplay>().component.serialNumber == currentDetailComponentItem.serialNumber)
                    {
                        cartItem.GetComponent<ItemDisplay>().itemAmount--;
                        cartItem.GetComponent<ItemDisplay>().itemTotalPrice -= currentDetailComponentItem.price;
                        cartItem.transform.Find("BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = cartItem.GetComponent<ItemDisplay>().itemAmount.ToString();
                        cartItem.transform.Find("Price/PriceValue").GetComponent<TMP_Text>().text = cartItem.GetComponent<ItemDisplay>().itemTotalPrice.ToString();
                    }
                }
                shopDictionary[currentDetailComponentItem]--;
                totalPrice -= currentDetailComponentItem.price;
            }
        }
        Debug.Log(totalPrice);
    }
    public void PurchaseItem()
    {
        packageBox.SetActive(true);
        if (totalPrice <= playerManager.playerCredit && shopDictionary.Count != 0)
        {
            purchaseSound.Play();
            playerManager.playerCredit -= totalPrice;

            // Add purchased item to the package
            foreach (var electronicPart in shopDictionary.Keys)
            {
                for (int i = 0; i < shopDictionary[electronicPart]; i++)
                {
                    purchaseItem.GetComponent<DragableItem>().part = electronicPart; // Assign Electronic Part Scriptable Object to the prefab
                    GameObject purchasedItem = Instantiate(purchaseItem);
                    PackageSlotCheck(purchasedItem);
                }
            }
            // Create bill display item in billDisplay, clear cart display slot, shopDictionary, and cartItemDisplayList
            foreach(GameObject cartItem in cartItemDisplaysList)
            {
                GameObject billItem = Instantiate(billItemDisplayPrefab); // Create billItemDisplay gameObject 
                billItem.transform.SetParent(billItemDisplayContent.transform); // set gameObject to billItemDisplayContent as child
                billItem.transform.localScale = new Vector3(1, 1, 1); // scale gameObject to 1, original size is 128 for some reasons

                billItem.GetComponent<BillDisplay>().component = cartItem.GetComponent<ItemDisplay>().component;
                billItem.GetComponent<BillDisplay>().itemAmount = cartItem.GetComponent<ItemDisplay>().itemAmount;
                billItem.GetComponent<BillDisplay>().itemTotalPrice = cartItem.GetComponent<ItemDisplay>().itemTotalPrice;
                Destroy(cartItem);
            }

            cartItemDisplaysList.Clear();
            shopDictionary.Clear();

            billWindow.SetActive(true);
            billWindow.transform.Find("BG_Bill/TotalCredit/TotalCreditValue").GetComponent<TMP_Text>().text = totalPrice.ToString();
            billWindow.transform.Find("BG_Bill/TotalCredit/TotalCreditValue2").GetComponent<TMP_Text>().text = totalPrice.ToString();
        }
    }
    private bool PackageSlotCheck(GameObject item)
    {
        for (int j = 0; j < packageManager.packageSlots.Count; j++)
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
        foreach (var amount in itemAmount) // Reset itemAmount value to 0 if value > 0
        {
            if (amount.itemAmount > 0)
            {
                amount.itemAmount = 0;
                amount.gameObject.transform.Find("BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = "0";
            }
        }
        if(cartItemDisplaysList != null) // Clear all CartItem gameObjects in cartItemDisplayList
        {
            foreach (GameObject cartItem in cartItemDisplaysList)
            {
                Destroy(cartItem);
            }
        }
        totalPrice = 0;
        cartItemDisplaysList.Clear();
        shopDictionary.Clear();
    }
    public void OpenShopArea(GameObject shopMenu) // Open Shop Menu
    {
        shopMenu.SetActive(true);
        OpenShopWindow();
        cartWindow.SetActive(false);
    }
    public void CloseShopArea(GameObject shopMenu)
    {
        foreach (var amount in itemAmount) // Reset itemAmount value to 0 if value > 0
        {
            if (amount.itemAmount > 0)
            {
                amount.itemAmount = 0;
                amount.gameObject.transform.Find("BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = amount.itemAmount.ToString();
            }
        }
        if (cartItemDisplaysList != null) // Clear all CartItem gameObjects in cartItemDisplayList
        {
            foreach (GameObject cartItem in cartItemDisplaysList)
            {
                Destroy(cartItem);
            }
        }
        totalPrice = 0;
        cartItemDisplaysList.Clear();
        shopDictionary.Clear();
        cartWindow.SetActive(false);
        detailWindow.SetActive(false);

        for(int i = 0; i < billWindow.transform.Find("BG_Bill/BillScrollArea/BillContent").transform.childCount; i++)
        {
            Destroy(billWindow.transform.Find("BG_Bill/BillScrollArea/BillContent").transform.GetChild(i).gameObject);
        }
        billWindow.SetActive(false);
        shopMenu.SetActive(false);
    }
    public void OpenShopWindow() // When Player already in shop
    {
        detailWindow.GetComponentInChildren<ItemDisplay>().enabled = false;
        detailWindow.SetActive(false);
        cartWindow.SetActive(false);
        shopWindow.SetActive(true);
        totalPricePanel.transform.localPosition = new Vector3(151.9f, -457.4999f, 0); // Move Total price display panel
        clearListButton.transform.localPosition = new Vector3(429.2f, -458.4999f, 0); // Move Clear item list button
    }
    public void OpenCart()
    {
        detailWindow.SetActive(false);
        shopWindow.SetActive(false);
        cartWindow.SetActive(true);
        totalPricePanel.transform.localPosition = new Vector3(13, -457.4999f, 0); // Move Total price display panel
        clearListButton.transform.localPosition = new Vector3(290.3f, -458.4999f, 0); // Move Clear item list button

        if (shopDictionary.Count == 0)
        {
            cartWindow.transform.Find("BG_CartPanel/Contents").gameObject.SetActive(false);
            cartWindow.transform.Find("BG_CartPanel/Text_NoItem").gameObject.SetActive(true);
        }
        else
        {
            cartWindow.transform.Find("BG_CartPanel/Contents").gameObject.SetActive(true);
            cartWindow.transform.Find("BG_CartPanel/Text_NoItem").gameObject.SetActive(false);
        }
    }
    public void OpenItemDetail(ElectronicPart component)
    {
        shopWindow.SetActive(false);
        cartWindow.SetActive(false);
        detailWindow.SetActive(true);
        totalPricePanel.transform.localPosition = new Vector3(151.9f, -461, 0);
        detailWindow.GetComponentInChildren<ItemDisplay>().enabled = true;
        foreach (var item in itemAmount)
        {
            if (item.component.electronicType == component.electronicType
                && item.component.serialNumber == component.serialNumber)
            {
                currentDetailComponentItem = component;
                detailWindow.transform.Find("ItemDetailDisplay/BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = item.itemAmount.ToString();
                detailWindow.GetComponentInChildren<ItemDisplay>().itemAmount = item.itemAmount;
            }
        }
        detailWindow.GetComponentInChildren<ItemDisplay>().DisplayDetailItem(component);
    }
    private void CreateItemDisplay(ElectronicPart electronicPart)
    {
        // Create Display Item Slot to the cart
        GameObject cartItemDisplayClone = Instantiate(cartItemDisplaySlotPrefab); // Create a cartItemDisplay using prefab

        cartItemDisplaysList.Add(cartItemDisplayClone.gameObject); // Add to the cartItemDisplaysList

        cartItemDisplayClone.transform.SetParent(cartItemDisplayContent.transform); // Set the gameObject to be the child of cartItemDisplayContent
        cartItemDisplayClone.transform.localScale = new Vector3(1, 1, 1); // scale the gameObject to 1, original size is 128 for some reasons

        cartItemDisplayClone.GetComponent<ItemDisplay>().component = electronicPart; // assign electricalPart ScriptableObject to the gameObject
        cartItemDisplayClone.GetComponent<ItemDisplay>().itemAmount = 1; // Set ItemAmount to 1
        cartItemDisplayClone.GetComponent<ItemDisplay>().itemTotalPrice = electronicPart.price; // Set Item total pricr to electronicPart's price
        cartItemDisplayClone.transform.Find("BG_ItemAmount/ItemAmount").GetComponent<TMP_Text>().text = "1"; // Display itemAmount text to 1
        cartItemDisplayClone.transform.Find("Price/PriceValue").GetComponent<TMP_Text>().text = electronicPart.price.ToString(); // Display price text to electricalPart's price
    }
}
