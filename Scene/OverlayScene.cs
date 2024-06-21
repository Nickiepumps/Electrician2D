using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverlayScene : MonoBehaviour
{
    public void ChangeSceneOverlay(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        gameObject.SetActive(false);
    }
}
