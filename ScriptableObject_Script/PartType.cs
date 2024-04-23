using UnityEngine;

public enum ItemType
{
    capacitor,
    resistor
}

[CreateAssetMenu(menuName = "Electronic Part/Type", fileName = "New Type")]
public class PartType : ScriptableObject
{
    public ItemType partType;
}
