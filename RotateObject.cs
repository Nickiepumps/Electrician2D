using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject[] insideView; // Inside View Empty GameObject that contain image and slot
    public GameObject[] outsideView; // Outside View Empty GameObject
    private int insideCurrent = 0; // Inside Current View Number
    private int outsideCurrent = 0; // Outide Current View Number

    [Header("Multimeter GameObject")]
    [SerializeField] private GameObject multimeter; // Multimeter GameObject
    public void StartInpect(GameObject inspectButton)
    {
        inspectButton.SetActive(true);
    }
    public void StopInspect(GameObject inspectButton)
    {
        inspectButton.SetActive(false);
    }
    public void InsideNextView()
    {
        insideCurrent++; // Add current view number by 1
        if (insideCurrent < insideView.Length)
        {   
            // Change to next View
            insideView[insideCurrent - 1].gameObject.SetActive(false);
            insideView[insideCurrent].gameObject.SetActive(true);

            // Reset Wire Probing when changing the angle view
            multimeter.GetComponent<InstrumentManager>().positiveSlotProbed = false;
            multimeter.GetComponent<InstrumentManager>().negativeSlotProbed = false;
            multimeter.GetComponent<InstrumentManager>().positivePortClicked = false;
            multimeter.GetComponent<InstrumentManager>().negativePortClicked = false;
            multimeter.GetComponent<InstrumentManager>().positiveChecked = false;
            multimeter.GetComponent<InstrumentManager>().negativeChecked = false;
            multimeter.GetComponent<InstrumentManager>().secondTime = false;
        }
        if(insideCurrent == insideView.Length)
        {
            // Switch to the first view in the first element of the array when the current view reaches the last element
            insideCurrent = 0;
            insideView[insideView.Length - 1].gameObject.SetActive(false);
            insideView[insideCurrent].gameObject.SetActive(true);
        }
    }
    public void InsidePreviousView()
    {
        insideCurrent--; // Decrease current view number by 1 
        if (insideCurrent < 0)
        {
            // Change view angle to the last element by set insideCurrent value to last element value
            insideCurrent = insideView.Length - 1;
            insideView[0].gameObject.SetActive(false);
            insideView[insideCurrent].gameObject.SetActive(true);
        }
        else
        {
            //  Change to previous view by decrease insideCurrent value by 1 if current insideCurrent is not lesser than 0 
            insideView[insideCurrent + 1].gameObject.SetActive(false);
            insideView[insideCurrent].gameObject.SetActive(true);

            // Reset Wire Probing when changing the angle view
            multimeter.GetComponent<InstrumentManager>().positiveSlotProbed = false;
            multimeter.GetComponent<InstrumentManager>().negativeSlotProbed = false;
            multimeter.GetComponent<InstrumentManager>().positivePortClicked = false;
            multimeter.GetComponent<InstrumentManager>().negativePortClicked = false;
            multimeter.GetComponent<InstrumentManager>().positiveChecked = false;
            multimeter.GetComponent<InstrumentManager>().negativeChecked = false;
            multimeter.GetComponent<InstrumentManager>().secondTime = false;
        }
    }
    public void OutsidePreviousView()
    {
        outsideCurrent--;
        if (outsideCurrent < 0)
        {
            // Change View
            outsideCurrent = outsideView.Length - 1;
            outsideView[0].gameObject.SetActive(false);
            outsideView[outsideCurrent].gameObject.SetActive(true);
        }
        else
        {
            outsideView[outsideCurrent + 1].gameObject.SetActive(false);
            outsideView[outsideCurrent].gameObject.SetActive(true);
        }
    }
    public void OutsidesideNextView()
    {
        outsideCurrent++;
        if (outsideCurrent < outsideView.Length)
        {
            outsideView[outsideCurrent - 1].gameObject.SetActive(false);
            outsideView[outsideCurrent].gameObject.SetActive(true);
        }
        if (outsideCurrent == outsideView.Length)
        {
            outsideCurrent = 0;
            outsideView[outsideView.Length - 1].gameObject.SetActive(false);
            outsideView[outsideCurrent].gameObject.SetActive(true);
        }
    }
}
