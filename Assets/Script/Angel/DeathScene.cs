using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{

    public void loadToGame()
    {
        SceneManager.LoadScene("Angel");
    }

    public void loadToMenu()
    {
        SceneManager.LoadScene("MainMenuAngel");
    }
}
