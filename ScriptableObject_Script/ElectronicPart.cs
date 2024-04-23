using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Electronic Part/Electronic Part", fileName = "New ElectronicPart")]
public class ElectronicPart : ScriptableObject
{
    public Sprite partSpriteImage;
    public PartType partType;
    public string partName;
    public string partDesc;
    public string serialNumber;
    public float voltage;
    public float ampere;

}
