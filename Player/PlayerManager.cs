using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerCredit = 500;
    public void ClosePlayerSlot(GameObject playerSlot)
    {
        playerSlot.SetActive(false);
    }
    public void OpenPlayerSlot(GameObject playerSlot)
    {
        playerSlot.SetActive(true);
    }
}
