﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public static bool isGameStarted = true;
    public static bool isGamePaused = false;
    public static bool GameResumer = false;
    public static bool isBuyMenuOpened = false;

    public GameObject pauseMenu;
    public GameObject buyMenu;

    public Button hpB;
    public Button amB;

    // Tutorial
    public Text headerText;
    public Text myText;
    // Tutorial End

    public AudioMixer audioMixer;

    public PlayerVitals pv;
    public Slider posionLevel;

    public Text points;
    // Update is called once per frame
    //GameObject[] pauseObjects;
    void Start(){
        Time.timeScale = 1;
		//pauseObjects = Object.FindObjectsOfTypeAll;
    }
    void Update()
    {
        if (isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isGamePaused = true;
                Screen.lockCursor = false;

                if (isGamePaused == true)
                {
                    if(GameResumer == true){
                        ResumeGame();
                    }
                    else{
                        PauseGame();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                points.text = pv.points.ToString();
                // Never allow the Buy menu to open if the game is paused
                if (isGamePaused)  return;
                
                else if (!isGamePaused && !isBuyMenuOpened)
                {
                    isBuyMenuOpened = true;
                    buyMenu.SetActive(true);
                    Screen.lockCursor = false;
                }
                else if (!isGamePaused && isBuyMenuOpened)
                {
                    isBuyMenuOpened = false;
                    buyMenu.SetActive(false);
                    Screen.lockCursor = true;
                }
            }

            if (isBuyMenuOpened)
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    // Disable the texts so we can see the market place better!
                    headerText.enabled = false;
                    myText.enabled = false;
                }
                if (pv.points < 500)
                hpB.interactable = false;
                if (pv.points < 300)
                amB.interactable = false;
            }else if ((!isBuyMenuOpened || !isGamePaused) && SceneManager.GetActiveScene().buildIndex == 1)
            {
                headerText.enabled = true;
                myText.enabled = true;
            }
        }
    }

    // Buy Menu START
    public void buyHealthPack()
    {
        if (pv.points >= 500)
        {
           hpB.interactable = true;
           pv.points -= 500;
           points.text = pv.points.ToString();
           posionLevel.value -= 0.5f;
        }
    }

    public void buyAmmo()
    {
        if (pv.points >= 300)
        {
            amB.interactable = true;
            pv.points -= 300;
            points.text = pv.points.ToString();
            AutomaticGunScriptLPFP.currentAmmo += 30;       // Burası yanlış.. Ammo variablesi kullanılacak!
        }
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
        Screen.lockCursor = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        GameResumer = false;  
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = false;
        GameResumer = true;
    //    GetComponent<ParticleSystem>().Pause();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
