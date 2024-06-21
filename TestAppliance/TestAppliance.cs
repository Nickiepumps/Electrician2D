using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAppliance : MonoBehaviour
{
    private bool turnOn = false;
    [SerializeField] private GameObject turnOnBtn, turnOffBtn, sendToCustomerBtn; // On Off Button and sent to customer Button

    [Header("Appliance Inspection UI")]
    [SerializeField] private GameObject applianceInspectionUI;

    [Header("Player UI")]
    [SerializeField] private GameObject playerUI;

    [Header("ScoreBoard UI")]
    [SerializeField] private GameObject scoreBoardUI;

    [Header("Appliance Normal Condition Anim")]
    [SerializeField] private Animator normAnimator;

    private void Update()
    {
        // To Do: make this button disable automatically when player dissassemle the appliance or when take component off
        if (GetComponent<ApplianceCondition>().isFixed == false) // Disable SentToCustomer button if Appliance is not fixed
        {
            sendToCustomerBtn.SetActive(false);
        } 
    }
    public void TurnOnPower()
    {
        if(GetComponent<ApplianceCondition>().isFixed == true) // Turn on power when Appliance is fixed
        {
            Debug.Log("Fix Successfully");

            // To Do: Start Fixed Appliance Animation

            turnOn = true;
            turnOnBtn.SetActive(false);
            turnOffBtn.SetActive(true);
            sendToCustomerBtn.SetActive(true);
            normAnimator.enabled = true;
        }
        else // Turn on power when Appliance is not fixed
        {
            Debug.Log("Appliace is currently damaged");

            // To Do: Start Broken Appliance Animation

            turnOn = true;
            turnOnBtn.SetActive(false);
            turnOffBtn.SetActive(true);
        }
    }
    public void TurnOffPower()
    {
        if (turnOn == true && GetComponent<ApplianceCondition>().isFixed == true) // Turn off power when Appliance is fixed
        {
            Debug.Log("Turn Off Power");

            // To Do: Stop Fixed Appliance Animation

            turnOn = false;
            turnOnBtn.SetActive(true);
            turnOffBtn.SetActive(false);
            normAnimator.enabled = false;
        }
        else if (turnOn == true && GetComponent<ApplianceCondition>().isFixed == false) // Turn off power when Appliance is not fixed
        {
            Debug.Log("Turn Off Power");

            // To Do: Stop Broken Appliance Animation

            turnOn = false;
            turnOnBtn.SetActive(true);
            turnOffBtn.SetActive(false);
        }
    }
    public void SendToCustomer()
    {
        applianceInspectionUI.SetActive(false);
        playerUI.SetActive(false);
        scoreBoardUI.SetActive(true);
    }
}
