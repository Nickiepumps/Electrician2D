using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text itemAmountText;
    public int itemAmount = 0;
    public UnityEvent shopEvent;
    private void Start()
    {
        itemAmountText.text = "0";
    }
    private void Update()
    {
        itemAmountText.text = itemAmount.ToString();
    }
    public void IncreaseAmount()
    {
        if(itemAmount >= 10)
        {
            itemAmount = 10;
        }
        else
        {
            itemAmount++;
        }
    }
    public void DecreaseAmount()
    {
        if(itemAmount <= 0)
        {
            itemAmount = 0;
        }
        else
        {
            itemAmount--;
        }
    }
}
