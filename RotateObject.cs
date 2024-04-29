using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject[] insideView; // Inside View Empty GameObject that contain image and slot
    public GameObject[] outsideView; // Outside View Empty GameObject
    private int insideCurrent = 0; // Inside Current Page Number
    private int outsideCurrent = 0; // Outide Current Page Number
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
        insideCurrent++;
        if (insideCurrent < insideView.Length)
        {   
            insideView[insideCurrent - 1].gameObject.SetActive(false);
            insideView[insideCurrent].gameObject.SetActive(true);
        }
        if(insideCurrent == insideView.Length)
        {
            insideCurrent = 0;
            insideView[insideView.Length - 1].gameObject.SetActive(false);
            insideView[insideCurrent].gameObject.SetActive(true);
        }
    }
    public void InsidePreviousView()
    {
        insideCurrent--;
        if (insideCurrent < 0)
        {
            insideCurrent = insideView.Length - 1;
            insideView[0].gameObject.SetActive(false);
            insideView[insideCurrent].gameObject.SetActive(true);
        }
        else
        {
            insideView[insideCurrent + 1].gameObject.SetActive(false);
            insideView[insideCurrent].gameObject.SetActive(true);
        }
    }
    public void OutsidePreviousView()
    {
        outsideCurrent--;
        if (outsideCurrent < 0)
        {
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
