using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickOnOption : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject OnPausePanel, karaPanel, TutorialPanel;
    public bool isit = false;
    public static bool GameIsPaused = false;
    public static bool again;
    public int loadIndex = 0; //geliştirme bittiğinde private yap

    public void Start()
    {
        if (PlayerPrefs.HasKey("loadIndex"))
        {
            loadIndex = PlayerPrefs.GetInt("loadIndex");
        }
        /*if (SceneManager.GetActiveScene().buildIndex == 0) {
            loadIndex = 0;
        }
        else
        {    //denemek icin
            loadIndex = 1;
        } */  
        AskTutorial();
    }
    public void Update()
    {
        if(GameIsPaused)
        {
            karaPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            karaPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ClickToPause()
    {
        GameIsPaused = true;
        OnPausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        OnPausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        OnPausePanel.SetActive(true);
    }

    public void OptionsOpenClose()
    {
        if (OptionsPanel != null && isit == false)
        {
            GameIsPaused = true;
            OptionsPanel.SetActive(true);
            isit = true;
        }
        else
        {
            OptionsPanel.SetActive(false);
            isit = false;
            GameIsPaused = false;
        }
    }

    public void OptionBack()
    {
        OptionsPanel.SetActive(false);
        GameIsPaused = false;
    }

    public void AskTutorial()
    {
        if (loadIndex == 0)
        {
            TutorialPanel.SetActive(true);
            GameIsPaused = true;
            loadIndex++;
        }
    }
    public void yesToTutorial()
    {
        GameIsPaused = false;
        PlayerPrefs.SetInt("loadIndex", loadIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void noToTutorial()
    {
        TutorialPanel.SetActive(false);
        GameIsPaused = false;
        PlayerPrefs.SetInt("loadIndex", loadIndex);
    }

    public void openMenu()
    {
        again = false;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void try_again()
    {
        again = true;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        oyun_başlatma.start = true;
    }
    public void gotoTutorial()
    {
        ClickOnOption.GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void openMyUrl(string url)
    {
        Application.OpenURL(url);
    }
}
