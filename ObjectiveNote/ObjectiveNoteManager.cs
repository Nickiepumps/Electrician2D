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

    [Header("Component Slots List")]
    [SerializeField] private List<KeyItemSlot> componentSlotsList; // Component slots list
    [SerializeField] private GameObject objectiveScrollContent; // Objective scroll content gameOject

    private Dictionary<int, GameObject> objectiveDictionary = new Dictionary<int, GameObject>(); // Objective dictionary for updating appliance condition
    //public List<GameObject> objectiveList = new List<GameObject>(); // Objective List with same data as dictionary one. Use for Save System

    [SerializeField] private GameObject multimeter;
    private void Start()
    {
        DisplayObjective();
    }
    public void DisplayObjective()
    {
        foreach(var slot in componentSlotsList)
        {
            #region Capacitor
            if (slot.slotType.electronicPart.electronicType == ItemType.capacitor)
            {
                GameObject brkCap = Instantiate(objectivePrefab, objectiveScrollContent.transform);
                brkCap.GetComponentInChildren<TMP_Text>().text = "คาปาซิเตอร์";
                brkCap.GetComponentInChildren<Image>().color = Color.gray;
                objectiveDictionary.Add(slot.slotID, brkCap);
            }
            #endregion
            #region Thermostat
            else if (slot.slotType.electronicPart.electronicType == ItemType.thermostat)
            {
                GameObject brkThrmst = Instantiate(objectivePrefab, objectiveScrollContent.transform);
                brkThrmst.GetComponentInChildren<TMP_Text>().text = "เทอร์โมสตัท";
                brkThrmst.GetComponentInChildren<Image>().color = Color.gray;
                objectiveDictionary.Add(slot.slotID, brkThrmst);
            }
            #endregion
            #region FanSwitch
            else if (slot.slotType.electronicPart.electronicType == ItemType.fanswitch_wire_high)
            {
                GameObject RS_Fanswitch_H = Instantiate(objectivePrefab, objectiveScrollContent.transform);
                RS_Fanswitch_H.GetComponentInChildren<TMP_Text>().text = "High Switch";
                RS_Fanswitch_H.GetComponentInChildren<Image>().color = Color.gray;
                objectiveDictionary.Add(slot.slotID, RS_Fanswitch_H);
            }
            else if (slot.slotType.electronicPart.electronicType == ItemType.fanswitch_wire_medium)
            {
                GameObject RS_Fanswitch_M = Instantiate(objectivePrefab, objectiveScrollContent.transform);
                RS_Fanswitch_M.GetComponentInChildren<TMP_Text>().text = "Medium Switch";
                RS_Fanswitch_M.GetComponentInChildren<Image>().color = Color.gray;
                objectiveDictionary.Add(slot.slotID, RS_Fanswitch_M);
            }
            else if (slot.slotType.electronicPart.electronicType == ItemType.fanswitch_wire_low)
            {
                GameObject RS_Fanswitch_L = Instantiate(objectivePrefab, objectiveScrollContent.transform);
                RS_Fanswitch_L.GetComponentInChildren<TMP_Text>().text = "Low Switch";
                RS_Fanswitch_L.GetComponentInChildren<Image>().color = Color.gray;
                objectiveDictionary.Add(slot.slotID, RS_Fanswitch_L);
            }
            else if (slot.slotType.electronicPart.electronicType == ItemType.fanswitch_wire_neutron)
            {
                GameObject RS_Fanswitch_N = Instantiate(objectivePrefab, objectiveScrollContent.transform);
                RS_Fanswitch_N.GetComponentInChildren<TMP_Text>().text = "Neutron Wire";
                RS_Fanswitch_N.GetComponentInChildren<Image>().color = Color.gray;
                objectiveDictionary.Add(slot.slotID, RS_Fanswitch_N);
            }
            #endregion
        }
    }

    public void CheckObjectiveStatus(GameObject inspectSlot)
    {
        #region Capacitor
        if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType == ItemType.capacitor)
        {
            if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.Broken)
            {
                // Check if there any objective matched the current slot 
                // Update Objective Color Status
                foreach (GameObject obj in objectiveDictionary.Values)
                {
                    if (objectiveDictionary.ContainsKey(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID)
                        && multimeter.GetComponent<InstrumentManager>().positiveChecked == true
                        && multimeter.GetComponent<InstrumentManager>().negativeChecked == true)
                    {
                        Debug.Log("Test");
                        obj.GetComponentInChildren<Image>().color = Color.red;
                    }
                }
            }
            else if(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.NearlyBroke)
            {
                if(CheckObjective(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID) == false)
                {
                    //nearCap.GetComponentInChildren<Image>().color = new Color(224, 152, 0, 255);
                }
            }
        }
        #endregion
        #region Thermostat
        else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType == ItemType.thermostat)
        {
            if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.Broken)
            {
                if(CheckObjective(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID) == false)
                {
                    GameObject brkThrmst = Instantiate(objectivePrefab, transform);
                    brkThrmst.GetComponentInChildren<TMP_Text>().text = inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType.ToString();
                    brkThrmst.GetComponentInChildren<Image>().color = Color.red;
                    objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, brkThrmst);
                } 
            }
            else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.NearlyBroke)
            {
                if(CheckObjective(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID) == false)
                {
                    GameObject nearThrmst = Instantiate(objectivePrefab, transform);
                    nearThrmst.GetComponentInChildren<TMP_Text>().text = inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType.ToString();
                    nearThrmst.GetComponentInChildren<Image>().color = new Color(224, 152, 0, 255);
                    objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, nearThrmst);
                }
            }
        }
        #endregion
        #region FanSwitch
        else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType == ItemType.fanswitch_wire_high)
        {
            if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.NeedResoldering)
            {
                if(CheckObjective(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID) == false)
                {
                    GameObject RS_Fanswitch_H = Instantiate(objectivePrefab, transform);
                    RS_Fanswitch_H.GetComponentInChildren<TMP_Text>().text = "High Switch";
                    RS_Fanswitch_H.GetComponentInChildren<Image>().color = Color.red;
                    objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, RS_Fanswitch_H);
                }
            }
        }
        else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType == ItemType.fanswitch_wire_medium)
        {
            if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.NeedResoldering)
            {
                if(CheckObjective(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID) == false)
                {
                    GameObject RS_Fanswitch_M = Instantiate(objectivePrefab, transform);
                    RS_Fanswitch_M.GetComponentInChildren<TMP_Text>().text = "Medium Switch";
                    RS_Fanswitch_M.GetComponentInChildren<Image>().color = Color.red;
                    objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, RS_Fanswitch_M);
                }
            }
        }
        else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType == ItemType.fanswitch_wire_low)
        {
            if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.NeedResoldering)
            {
                if(CheckObjective(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID) == false)
                {
                    GameObject RS_Fanswitch_L = Instantiate(objectivePrefab, transform);
                    RS_Fanswitch_L.GetComponentInChildren<TMP_Text>().text = "Low Switch";
                    RS_Fanswitch_L.GetComponentInChildren<Image>().color = Color.red;
                    objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, RS_Fanswitch_L);
                }
            }
        }
        else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.electronicType == ItemType.fanswitch_wire_neutron)
        {
            if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotType.electronicPart.condition == PartCondition.NeedResoldering)
            {
                if(CheckObjective(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID) == false)
                {
                    GameObject RS_Fanswitch_N = Instantiate(objectivePrefab, transform);
                    RS_Fanswitch_N.GetComponentInChildren<TMP_Text>().text = "Neutron Wire";
                    RS_Fanswitch_N.GetComponentInChildren<Image>().color = Color.red;
                    objectiveDictionary.Add(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID, RS_Fanswitch_N);
                }
            }
        }
        #endregion
    }

    // Update Objective using fixing status in the Component slot that assigned into
    public void UpdateObjective(GameObject inspectSlot)
    {
        if (inspectSlot.GetComponentInChildren<KeyItemSlot>().isFixed == true)
        {
            if (objectiveDictionary.ContainsKey(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID))
            {
                objectiveDictionary[inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
            }
        }
        else if (inspectSlot.GetComponentInChildren<KeyItemSlot>().isFixed == false)
        {
            if (objectiveDictionary.ContainsKey(inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID))
            {
                objectiveDictionary[inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.red;
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
}
