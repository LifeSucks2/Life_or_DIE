using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public static bool isGameStarted = true;
    public static bool isGamePaused = false;
    public static bool isBuyMenuOpened = false;

    public GameObject pauseMenu;
    public GameObject buyMenu;

    public AudioMixer audioMixer;

    public PlayerVitals pv;
    public Slider posionLevel;
    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
              /*  if (isBuyMenuOpened) return;
               
                if (isGamePaused)
                ResumeGame();
                else 
                PauseGame();
                */
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                // Never allow the Buy menu to open if the game is paused
                if (isGamePaused)  return;
                
                else if (!isGamePaused && !isBuyMenuOpened)
                {
                    isBuyMenuOpened = true;
                    buyMenu.SetActive(true);
                }
                else if (!isGamePaused && isBuyMenuOpened)
                {
                    isBuyMenuOpened = false;
                    buyMenu.SetActive(false);
                }
            }
        }
    }

    // Buy Menu START
    public void buyHealthPack()
    {
        if (pv.points >= 500)
        {
           pv.points -= 500;
           posionLevel.value -= 0.5f; 
        }
        else
        Debug.Log("Not enough Money"); // SHow the user!
    }

    public void buyAmmo()
    {
        if (pv.points >= 300)
        {
            pv.points -= 300;
            AutomaticGunScriptLPFP.currentAmmo += 30;       // Burası yanlış.. Ammo variablesi kullanılacak!
        }
        else
        Debug.Log("Not enough Money"); // SHow the user!    
    }
    // Buy Menu END

    public void StartGame()
    {
        isGameStarted = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

    public void SetVolume(float Volume)
    {
        audioMixer.SetFloat("Volume", Volume);
    }

    public void SetQuality(int index)
    {
        /*  0 --> Low
            1 --> Medium
            2 --> High
        */
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void ResumeGame()
    {
        Debug.Log("Res");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
