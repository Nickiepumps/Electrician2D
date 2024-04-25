using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PartCondition
{
    Broken,
    NearlyBroke,
    Normal
}
public enum ItemType
{
    capacitor,
    resistor
}

[CreateAssetMenu(menuName = "Electronic Part/Electronic Part", fileName = "New ElectronicPart")]
public class ElectronicPart : ScriptableObject
{
    [Header("General Detail")]
    public Sprite partSpriteImage;    
    public string partName;
    public string partDesc;
    public string serialNumber;

    [Header("Electronic Type")]
    public ItemType electronicType;

    [Header("Condition")]
    public PartCondition condition;

    [Header("Electronic General Value")]
    public float voltage;
    public float ampere;

    [Header("Electronic Type Specific Value")]
    public float ohm;
    public float farad;
    public float hertz;

}
