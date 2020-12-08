using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public static bool isGameStarted = false;
    public static bool isGamePaused = false;

    public GameObject pauseMenu;

    public AudioMixer audioMixer;

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            ResumeGame();
            else 
            PauseGame();
        }

    }

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
