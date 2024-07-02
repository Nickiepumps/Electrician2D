using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Condition List")]
    public GameObject[] scoreConditionLists;

    [Header("Stars")]
    [SerializeField] private GameObject[] stars;

    [Header("Electronic Slot")]
    [SerializeField] private List<KeyItemSlot> electronicSlots;

    private bool failOnce, oldComp;
    private void Start()
    {
        ShowResult();
    }
    private void CheckComponentScoreCondition()
    {
        foreach (var slot in electronicSlots)
        {
            // Check if slot is failonce and has new component
            if(slot.failOnce == true && slot.oldComponent == false)
            {
                failOnce = true;
            }

            // Check if slot is not fail and has old component
            else if (slot.failOnce == false && slot.oldComponent == true)
            {
                oldComp = true;
            }

            // Check if slot is fail and has old component
            else if (slot.failOnce == true && slot.oldComponent == true)
            {
                failOnce = true;
                oldComp = true; 
            }
        }
    }
    private void ShowResult()
    {
        CheckComponentScoreCondition();

        // Check if slot is failonce and has new component
        if (failOnce == true && oldComp == false)
        {
            scoreConditionLists[1].transform.Find("CheckBox").GetComponentInChildren<Image>().color = Color.green;
            ShowStars(2);
        }
        // Check if slot is not fail and has old component
        else if (failOnce == false && oldComp == true)
        {
            scoreConditionLists[0].transform.Find("CheckBox").GetComponentInChildren<Image>().color = Color.green;
            ShowStars(2);
        }
        // Check if slot is fail and has old component
        else if (failOnce == true && oldComp == true)
        {
            ShowStars(1);
        }
        // Check if slot is not fail and has new component
        else if (failOnce == false && oldComp == false)
        {
            scoreConditionLists[0].transform.Find("CheckBox").GetComponentInChildren<Image>().color = Color.green;
            scoreConditionLists[1].transform.Find("CheckBox").GetComponentInChildren<Image>().color = Color.green;
            ShowStars(3);
        }
    }
    private void ShowStars(int starAmount)
    {
        for(int i = 0; i < starAmount; i++)
        {
            stars[i].GetComponent<Image>().color = Color.green;
        }
    }
}
