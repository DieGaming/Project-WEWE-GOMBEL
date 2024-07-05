using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Add this to use UI components

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject quitPanel;

    //panel buat quitnya diset false dulu
    public void Start()
    {
        quitPanel.SetActive(false);
    }
    //fungsi buat play game (jadi langsung masuk ke game)
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    
    //fungsi buat quit game
    public void QuitGame()
    {
        Application.Quit();
    }

    //quitgame tapi muncul panel dulu
    public void OpenAreYouSure()
    {
        quitPanel.SetActive(true);
    }

    public void CloseAreYouSure()
    {
        quitPanel.SetActive(false);
    }
}
