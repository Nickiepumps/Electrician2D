using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateObject : MonoBehaviour
{
    public GameObject Front, Side, Back;
    public GameObject inspectNext,inspectPrev;
    public void StartInpect()
    {
        inspectNext.SetActive(true);
        inspectPrev.SetActive(true);
        Front.SetActive(true);
    }
    public void StopInspect()
    {
        Front.SetActive(false);
        Side.SetActive(false);
        Back.SetActive(false);
        inspectNext.SetActive(false);
        inspectPrev.SetActive(false);
    }
    public void NextView()
    {
        if (Front.activeSelf)
        {
            Side.SetActive(true);
            Front.SetActive(false);
        }
        else if (Side.activeSelf)
        {
            Back.SetActive(true);
            Front.SetActive(false);
            Side.SetActive(false);
        }
        else if (Back.activeSelf)
        {
            Front.SetActive(true);
            Side.SetActive(false);
            Back.SetActive(false);
        }
    }
    public void Previous()
    {
        if (Front.activeSelf)
        {
            Front.SetActive(false);
            Side.SetActive(false);
            Back.SetActive(true);
        }
        else if (Back.activeSelf)
        {
            Front.SetActive(false);
            Side.SetActive(true);
            Back.SetActive(false);
        }
        else if (Side.activeSelf)
        {
            Front.SetActive(true);
            Side.SetActive(false);
            Back.SetActive(false);
        }
    }
}
