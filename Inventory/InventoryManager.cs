using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public List<Items> items = new List<Items>(); // ItemData
    public List<int> itemNumbers = new List<int> (); // ItemAmount
    public List<bool> isClicked = new List<bool> (); // Checks for player click on Item
    public GameObject[] itemSlots; // ItemSlots

    public GameObject deleteItemButton; // DeleteItemButton

    public static InventoryManager instance; // for Singleton
    
    // SingleTon Start
    private void Awake()
    {
        instance = this;
    }
    // Singleton End

    private void Start()
    {
        DisplayItem();
    }
    public void DisplayItem()
    {
        for(int i = 0; i < items.Count; i++)
        {
            itemSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;
            itemSlots[i].transform.GetChild(1).GetComponent<TMP_Text>().color = new Color(0, 0, 0, 1);
            itemSlots[i].transform.GetChild(1).GetComponent<TMP_Text>().text = itemNumbers[i].ToString();
        }
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < items.Count)
            {
                itemSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;
                itemSlots[i].transform.GetChild(1).GetComponent<TMP_Text>().color = new Color(0, 0, 0, 1);
                itemSlots[i].transform.GetChild(1).GetComponent<TMP_Text>().text = itemNumbers[i].ToString();
            }
            else
            {
                itemSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                itemSlots[i].transform.GetChild(1).GetComponent<TMP_Text>().color = new Color(0, 0, 0, 0);
                itemSlots[i].transform.GetChild(1).GetComponent<TMP_Text>().text = null;
            }
        }
    }
    public void AddItem(Items item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            itemNumbers.Add(1);
            isClicked.Add(false);
        }
        else
        {
            Debug.Log("You already have this Item");
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i] == item)
                {
                    itemNumbers[i]++;
                }
            }
        }
        DisplayItem();
    }
    public void ClickedItem(Items item)
    {
        if (items.Contains(item))
        {
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i] == item)
                {
                    deleteItemButton.SetActive(true);
                    isClicked[i] = true;
                    Debug.Log(isClicked[i]);
                }
                else
                {
                    isClicked[i] = false;
                    Debug.Log(isClicked[i]);
                }
            }
        }
    }
    public void DeleteItem(Items item)
    {
        if (items.Contains(item))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (item == items[i])
                {
                    itemNumbers[i]--;
                    if(itemNumbers[i] == 0)
                    {
                        Debug.Log("Item Deleted");
                        items.Remove(item);
                        itemNumbers.Remove(itemNumbers[i]);
                        isClicked.Remove(isClicked[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("It's not here");
        }
        DisplayItem();
    }
}
