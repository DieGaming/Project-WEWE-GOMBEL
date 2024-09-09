using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public string sceneName;
    public bool toggle;
    public PlayerMovement playerScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
            if(toggle == false)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                playerScript.enabled = true;
            }
            if(toggle == true)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                playerScript.enabled = false;
            }
        }
    }

    public void resumeGame()
    {
        toggle = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        playerScript.enabled = true;
    }

    public void quitToMainMenu()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
