using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveNoteManager : MonoBehaviour
{
    [Header("Objective Prefab")]
    [SerializeField]
    private GameObject objectivePrefab;

    private Dictionary<int, GameObject> objectiveDictionary = new Dictionary<int, GameObject>();
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
                GameObject brkCap = Instantiate(objectivePrefab, transform);
                brkCap.GetComponentInChildren<TMP_Text>().text = inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType.ToString() + " Is Broken";
                objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, brkCap);
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
}
