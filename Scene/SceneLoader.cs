using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Loadscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void NextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void MainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Retry(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
