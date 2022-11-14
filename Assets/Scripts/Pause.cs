using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject MenuPause;
    private bool keyPause=false;

    public void PauseGame()
    {
        keyPause = true;
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
        MenuPause.SetActive(true);

    }

    public void resume()
    {
        keyPause = false;
        Time.timeScale = 1f;
        PauseButton.SetActive(true);
        MenuPause.SetActive(false);
    }

    public void exitGame() {

        Debug.Log("El juego se ha cerrado");
        Application.Quit();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (keyPause)
            {
                resume();
            }
            else {

                PauseGame();
            }
        }
    }
}
