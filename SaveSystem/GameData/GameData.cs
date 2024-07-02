using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector2 playerPos; // Player Position
    public int playerCredit; // Player Credit

    public List<bool> slotCondition; // Slot Condition Status List

    public List<GameObject> electronicComponentItemData; // Electronic Component data
    public List<int> electronicComponentSlotItemIDData; // Electronic Component Slot data
    public List<int> electronicComponentSlotIDData;

    public List<GameObject> inventoryItemsData; // Locker Inventory Item data
    public List<int> inventorySlotIDsData; // Locker Inventory Slot ID data
    public List<GameObject> packageItemsData; // Package Item data
    public List<int> packageItemsIDData; // Package Item ID data
    public List<GameObject> playerItemsData; // Player Inventory Item data
    public List<int> playerSlotIDsData; // Player Inventory Slot ID data

    public List<GameObject> objectivesData; // Objective data

    public int levelIndex;
    public GameData()
    {
        this.playerPos = new Vector2(5.57f,0.8f);
        this.playerCredit = 500;
        this.slotCondition = new List<bool>();
        this.inventoryItemsData = new List<GameObject>();
        this.inventorySlotIDsData = new List<int>();
        this.packageItemsData = new List<GameObject>();
        this.packageItemsIDData = new List<int>();
        this.playerItemsData = new List<GameObject>();
        this.playerSlotIDsData = new List<int>();
        this.electronicComponentItemData = new List<GameObject>();
        this.electronicComponentSlotItemIDData = new List<int>();
        this.electronicComponentSlotIDData = new List<int>();
        this.objectivesData = new List<GameObject>();
        this.levelIndex = 1;
    }
}
