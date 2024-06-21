using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum ProbeType
{
    componentProbe,
    instrumentProbe
}
public class Probe : MonoBehaviour, IPointerClickHandler
{
    private GameObject multimeter; // Instrument Manager
    [Header("Probe Type")]
    public ProbeType probetype;

    [Header("Port Type")]
    public bool isPositivePort;

    [Header("Port ID")]
    public int portID;

    // Component Port Probe Condition
    public bool compPositiveProbed;
    public bool compNegativeProbed;
    private void Awake()
    {
        multimeter = GameObject.FindGameObjectWithTag("Multimeter");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (probetype == ProbeType.instrumentProbe)
        {
            InstrumentPortClicking();
        }
        if (probetype == ProbeType.componentProbe)
        {
            ComponentPortClicking();
        }
    }
    private void InstrumentPortClicking()
    {
        // Positive Port Clicking
        if (isPositivePort == true)
        {
            // When Click Negative Port to Positive Port For the First time, Prevent User from Clicking Positive Port
            if (multimeter.GetComponent<InstrumentManager>().isProbing == true
                && multimeter.GetComponent<InstrumentManager>().negativePortClicked == true)
            {
                if (multimeter.GetComponent<InstrumentManager>().isProbing == true
                && multimeter.GetComponent<InstrumentManager>().positivePortClicked == true)
                {
                    multimeter.GetComponent<InstrumentManager>().isProbing = false;
                    multimeter.GetComponent<InstrumentManager>().positiveSlotProbed = false;
                    multimeter.GetComponent<InstrumentManager>().positivePortClicked = false;
                    multimeter.GetComponent<InstrumentManager>().positiveChecked = false;
                    multimeter.GetComponent<InstrumentManager>().CancleComponentProbe();
                    Debug.Log("Cancle Second Positive Probing");
                }
                // When Click Negative Port to Positive Port for the Second time, Prevent User Clicking Positive Port
                else if (multimeter.GetComponent<InstrumentManager>().positivePortClicked == true)
                {
                    Debug.Log("Incorrect Port");
                    multimeter.GetComponent<InstrumentManager>().isProbing = true;
                    multimeter.GetComponent<InstrumentManager>().positivePortClicked = true;
                }
                else
                {
                    multimeter.GetComponent<InstrumentManager>().isProbing = true;
                    multimeter.GetComponent<InstrumentManager>().positivePortClicked = false;
                    Debug.Log("Incorrect Port");
                }
            }
            // When User want to Cancle Probing in the Positive Port For the Second Time
            else if (multimeter.GetComponent<InstrumentManager>().isProbing == false 
                && multimeter.GetComponent<InstrumentManager>().positivePortClicked == true)
            {
                multimeter.GetComponent<InstrumentManager>().secondTime = false;
                multimeter.GetComponent<InstrumentManager>().isProbing = false;
                multimeter.GetComponent<InstrumentManager>().positiveSlotProbed = false;
                multimeter.GetComponent<InstrumentManager>().positivePortClicked = false;
                multimeter.GetComponent<InstrumentManager>().positiveChecked = false;
                multimeter.GetComponent<InstrumentManager>().CancleComponentProbe();
                Debug.Log("Cancle Positive Probing");
            }
            else if(multimeter.GetComponent<InstrumentManager>().isProbing == true)
            {
                multimeter.GetComponent<InstrumentManager>().isProbing = false;
                multimeter.GetComponent<InstrumentManager>().positivePortClicked = false;
            }
            // When Component is not Probed in both Positive or Negative Port
            else
            {
                multimeter.GetComponent<InstrumentManager>().isProbing = true;
                multimeter.GetComponent<InstrumentManager>().positivePortClicked = true;
            }
        }

        // Negative Port Clicking
        if (isPositivePort == false)
        {
            // When Click Negative Port to Positive Port For the First time, Prevent User from Clicking Positive Port
            if (multimeter.GetComponent<InstrumentManager>().isProbing == true
                && multimeter.GetComponent<InstrumentManager>().positivePortClicked == true)
            {
                if (multimeter.GetComponent<InstrumentManager>().isProbing == true
                && multimeter.GetComponent<InstrumentManager>().negativePortClicked == true)
                {
                    multimeter.GetComponent<InstrumentManager>().isProbing = false;
                    multimeter.GetComponent<InstrumentManager>().negativeSlotProbed = false;
                    multimeter.GetComponent<InstrumentManager>().negativePortClicked = false;
                    multimeter.GetComponent<InstrumentManager>().negativeChecked = false;
                    multimeter.GetComponent<InstrumentManager>().CancleComponentProbe();
                    Debug.Log("Cancle Second Positive Probing");
                }
                // When Click Positive Port to Negative Port for the Second time, Prevent User Clicking Negative Port
                else if (multimeter.GetComponent<InstrumentManager>().negativePortClicked == true)
                {
                    Debug.Log("Incorrect Port");
                    multimeter.GetComponent<InstrumentManager>().isProbing = true;
                    multimeter.GetComponent<InstrumentManager>().negativePortClicked = true;
                }
                else
                {
                    multimeter.GetComponent<InstrumentManager>().isProbing = true;
                    multimeter.GetComponent<InstrumentManager>().negativePortClicked = false;
                    Debug.Log("Incorrect Port");
                }
            }
            // When User want to Cancle Probing in the Positive Port For the First Time
            else if (multimeter.GetComponent<InstrumentManager>().isProbing == true)
            {
                multimeter.GetComponent<InstrumentManager>().isProbing = false;
                multimeter.GetComponent<InstrumentManager>().negativePortClicked = false;
            }
            // When User want to Cancle Probing in the Negative Port For the Second Time
            else if (multimeter.GetComponent<InstrumentManager>().isProbing == false
                && multimeter.GetComponent<InstrumentManager>().negativePortClicked == true)
            {
                multimeter.GetComponent<InstrumentManager>().secondTime = false;
                multimeter.GetComponent<InstrumentManager>().isProbing = false;
                multimeter.GetComponent<InstrumentManager>().negativeSlotProbed = false;
                multimeter.GetComponent<InstrumentManager>().negativePortClicked = false;
                multimeter.GetComponent<InstrumentManager>().negativeChecked = false;
                multimeter.GetComponent<InstrumentManager>().CancleComponentProbe();
                Debug.Log("Cancle Negative Probing");
            }
            // When Component is not Probed in both Positive or Negative Port
            else
            {
                multimeter.GetComponent<InstrumentManager>().isProbing = true;
                multimeter.GetComponent<InstrumentManager>().negativePortClicked = true;
            }
        }
    }
    private void ComponentPortClicking()
    {
        // Check Component Port When Instrument is Clicking
        if (multimeter.GetComponent<InstrumentManager>().isProbing == true)
        {
            // Component Positive Port And Check user to prevent clicking Component Negative Port 
            if (multimeter.GetComponent<InstrumentManager>().positivePortClicked == true && isPositivePort == true
                && multimeter.GetComponent<InstrumentManager>().positiveChecked == false)
            {
                compPositiveProbed = true;
                multimeter.GetComponent<InstrumentManager>().positiveSlotProbed = true;
                multimeter.GetComponent<InstrumentManager>().positiveChecked = true;
                multimeter.GetComponent<InstrumentManager>().isProbing = false;
                multimeter.GetComponent<InstrumentManager>().CompPositivePortSlotGet();
                if(multimeter.GetComponent<InstrumentManager>().CompCheckSlot() == false)
                {
                    compPositiveProbed = false;
                    multimeter.GetComponent<InstrumentManager>().isProbing = true;
                    multimeter.GetComponent<InstrumentManager>().positiveSlotProbed = false;
                    multimeter.GetComponent<InstrumentManager>().positiveChecked = false;
                    Debug.Log("Wrong Slot");
                }
                multimeter.GetComponent<InstrumentManager>().secondTime = true;
            }
            // Component Negative Port And Check user to prevent clicking Component Positive Port
            else if (multimeter.GetComponent<InstrumentManager>().negativePortClicked == true && isPositivePort == false
                && multimeter.GetComponent<InstrumentManager>().negativeChecked == false)
            {
                compNegativeProbed = true;
                multimeter.GetComponent<InstrumentManager>().negativeSlotProbed = true;
                multimeter.GetComponent<InstrumentManager>().negativeChecked = true;
                multimeter.GetComponent<InstrumentManager>().isProbing = false;
                multimeter.GetComponent<InstrumentManager>().CompNegativePortSlotGet();
                if (multimeter.GetComponent<InstrumentManager>().CompCheckSlot() == false)
                {
                    compNegativeProbed = false;
                    multimeter.GetComponent<InstrumentManager>().isProbing = true;
                    multimeter.GetComponent<InstrumentManager>().negativeSlotProbed = false;
                    multimeter.GetComponent<InstrumentManager>().negativeChecked = false;
                    Debug.Log("Wrong Slot");
                }
                multimeter.GetComponent<InstrumentManager>().secondTime = true;
            }
            else
            {
                Debug.Log("Incorrect Port");
            }

        }
        else
        {
            Debug.Log("Click Instrument Port to Begin Checking");
        }
    }
}
