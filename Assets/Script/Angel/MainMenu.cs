using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Add this to use UI components

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionPanel;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject quitPanel;
    public string sceneName;

    //panel buat quitnya sama optionnya diset false dulu
    public void Start()
    {
        optionPanel.SetActive(false);
        quitPanel.SetActive(false);
        loadingScreen.SetActive(false);
    }
    //fungsi buat play game (jadi langsung masuk ke game)
    public void PlayGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(sceneName);
    }
    
    //fungsi buat quit game
    public void QuitGame()
    {
        Debug.Log("Keluar dari Game");
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
