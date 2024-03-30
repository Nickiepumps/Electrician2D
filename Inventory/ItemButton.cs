using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public int buttonID;
    private Items thisItem, thisClickedItem;
    private Items GetThisItem()
    {
        for (int i = 0; i < InventoryManager.instance.items.Count; i++)
        {
            if (buttonID == i)
            {
                thisItem = InventoryManager.instance.items[i];
            }
        }
        return thisItem;
    }
    private Items GetClickedItem()
    {
        for (int i = 0; i < InventoryManager.instance.items.Count; i++)
        {
            if (InventoryManager.instance.isClicked[i] == true)
            {
                thisClickedItem = InventoryManager.instance.items[i];
            }
        }
        return thisClickedItem;
    }
    public void ClickItem()
    {
        InventoryManager.instance.ClickedItem(GetThisItem());
    }
    public void DeleteItem()
    {
        Debug.Log("Test");
        InventoryManager.instance.DeleteItem(GetClickedItem());
    }
}
