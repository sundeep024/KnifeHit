using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManagerUI : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadScene("FirstScene");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exit...");
    }
}
