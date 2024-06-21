using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveNoteManager : MonoBehaviour, IDataPersistance
{
    [Header("Objective Prefab")]
    [SerializeField]
    private GameObject objectivePrefab;

    private Dictionary<int, GameObject> objectiveDictionary = new Dictionary<int, GameObject>(); // Objective dictionary for updating appliance condition
    private List<GameObject> objectiveList = new List<GameObject>(); // Objective List with same data as dictionary one. Use for Save System
    private void Start()
    {
        objectivePrefab.GetComponentInChildren<TMP_Text>().text = "";
    }
    public void DisplayObjective(GameObject inspectSlot)
    {
        if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType == ItemType.capacitor)
        {
            if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.Broken)
            {
                // Check if there any objective matched the current slot 
                // Instantiate Objective GameObject Only Once 
                if(CheckObjective(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID) == false)
                {
                    GameObject brkCap = Instantiate(objectivePrefab, transform);
                    brkCap.GetComponentInChildren<TMP_Text>().text = inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType.ToString() + " Is Broken";
                    objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, brkCap);
                    objectiveList.Add(brkCap);
                }
            }
            else if(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.NearlyBroke)
            {
                GameObject nearCap = Instantiate(objectivePrefab, transform);
                nearCap.GetComponentInChildren<TMP_Text>().text = inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType.ToString() + " Is Nearly Broken";
                objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, nearCap);
            }
        }
        else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType == ItemType.thermostat)
        {
            if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.Broken)
            {
                GameObject brkThrmst = Instantiate(objectivePrefab, transform);
                brkThrmst.GetComponentInChildren<TMP_Text>().text = inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType.ToString() + " Is Broken";
                objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, brkThrmst);
                
            }
            else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.NearlyBroke)
            {
                GameObject nearThrmst = Instantiate(objectivePrefab, transform);
                nearThrmst.GetComponentInChildren<TMP_Text>().text = inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType.ToString() + " Is Nearly Broken";
                objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, nearThrmst);
                
            }
        }
    }

    // Update Objective using fixing status in the Component slot that assigned into
    public void UpdateObjective(GameObject inspectSlot)
    {
        if (inspectSlot.GetComponentInChildren<KeyItemSlot>().isFixed == true)
        {
            if (objectiveDictionary.ContainsKey(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID))
            {
                objectiveDictionary[inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().isFixed == false)
        {
            if (objectiveDictionary.ContainsKey(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID))
            {
                objectiveDictionary[inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    // Check Objective in objectiveDictionary to prevent any infinite instantiation
    private bool CheckObjective(int component)
    {
        if (objectiveDictionary.ContainsKey(component))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveData(GameData data)
    {
        data.objectivesData.Clear();
        foreach(GameObject obj in objectiveList)
        {
            data.objectivesData.Add(obj);
        }
    }

    public void LoadData(GameData data)
    {
        
    }
}
