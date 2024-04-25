using UnityEngine;

[CreateAssetMenu(menuName = "Appliance", fileName = "New Appliance")]

public class ApplianceSO : ScriptableObject
{
    [Header("General Detail")]
    public string applinceName;
    public string applianceDesc;

    [Header("Outside View")]
    public Sprite out_frontView;
    public Sprite out_sideView;
    public Sprite out_backView;
    public Sprite out_topView;
    public Sprite out_bottomView;

    [Header("Inside View")]
    public Sprite in_frontView;
    public Sprite in_sideView;
    public Sprite in_backView;
    public Sprite in_topView;
    public Sprite in_bottomView;

}
