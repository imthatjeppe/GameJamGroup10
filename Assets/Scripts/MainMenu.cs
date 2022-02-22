using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Startgame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
        Debug.Log("next scene loads");
    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quits Game");
    }
}
