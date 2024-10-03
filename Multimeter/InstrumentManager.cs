using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InstrumentManager : MonoBehaviour
{
    [Header("Component Probe Slot")]
    public GameObject[] compPositivePorts, compNegativePorts; // Components +/- Ports

    [Header("Component Slot")]
    public GameObject[] componentSlots; // Component GameObject slots

    [Header("Instrument Ports")]
    public GameObject positivePort, negativePort; // Multimeter +/- Ports

    [Header("Component Probe Status")]
    public bool positiveSlotProbed, negativeSlotProbed; // When Clicked on the "Probe slot" on the Electrical comp slot

    [Header("Instrument Probe Status")]
    public bool positivePortClicked, negativePortClicked; // When Clicked +/- from the instrument

    [Header("Objective Note")]
    [SerializeField] private GameObject objectiveNote;

    //[HideInInspector]
    private bool checkSuccess;
    private int pID = 0;
    private int nID = 0;
    public bool secondTime = false;
    public bool isProbing;

    public bool positiveChecked, negativeChecked; // When both Comp and Instrument probed correctly
    private void Update()
    {
        if (positiveChecked == true && negativeChecked == true)
        {
            secondTime = false;
            if (checkSuccess == false)
            {
                ApplianceCheck();
                checkSuccess = true;
            }
        }
        else
        {
            checkSuccess = false;
        }
    }
    public void CancleComponentProbe()
    {
        if (positivePortClicked == false)
        {
            for (int i = 0; i < compPositivePorts.Length; i++)
            {
                compPositivePorts[i].GetComponent<Probe>().compPositiveProbed = false;
                pID = 0;
            }
        }
        if (negativePortClicked == false)
        {
            for (int i = 0; i < compNegativePorts.Length; i++)
            {
                compNegativePorts[i].GetComponent<Probe>().compNegativeProbed = false;
                nID = 0;
            }
        }
    }
    public void CompPositivePortSlotGet()
    {
        foreach (GameObject positive in compPositivePorts)
        {
            if (positive.GetComponent<Probe>().compPositiveProbed == true)
            {
                pID = positive.GetComponent<Probe>().portID;
            }
        }
    }
    public void CompNegativePortSlotGet()
    {
        foreach (GameObject negative in compNegativePorts)
        {
            if (negative.GetComponent<Probe>().compNegativeProbed == true)
            {
                nID = negative.GetComponent<Probe>().portID;
            }
        }
    }
    public bool CompCheckSlot()
    {
        // To Do: Fix Component can probe on different component probe slot issue
        if (pID == nID || secondTime == false) // User Probe the correct slot if PositiveIDSlot and NegativeIDSlot has the same ID
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ApplianceCheck()
    {
        foreach (GameObject inspectSlot in componentSlots)
        {
            if (inspectSlot.GetComponentInChildren<KeyItemSlot>().slotID == pID)
            {
                // To Do: Uncomment this if new objective display is not working
                //objectiveNote.GetComponent<ObjectiveNoteManager>().CheckObjectiveStatus(inspectSlot);
            }
        }
    }
}
