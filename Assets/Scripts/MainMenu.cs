using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     void Start()
    {
        Time.timeScale = 1;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);

    }

    public void returnMenu()
        {
        SceneManager.LoadScene(0);
        }

    public void settings() {

        SceneManager.LoadScene(5);
    }

    public void Exit() {

        Application.Quit();
    }
    public void levelWood() {

        SceneManager.LoadScene(3);
    }
    public void levelCave() {

        SceneManager.LoadScene(4);
    }
}