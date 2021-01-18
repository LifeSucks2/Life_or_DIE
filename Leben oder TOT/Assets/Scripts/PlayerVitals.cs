using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerVitals : MonoBehaviour
{
    public int points = 0;
    public float poisen = 0;
    public float health = 200;
    public float maxHealth = 200;
    public Slider playerHealth;
    public Slider Toxin;
    public MenuScript ms;
    bool pauseMenu = false;
    bool pauseisPressed = false;
    void start()
    {
        playerHealth.minValue = 0f;
        playerHealth.maxValue = health;
        playerHealth.value = health;

        Toxin.minValue = 0f;
        Toxin.maxValue = 1f;
        Toxin.value = poisen;
    }

    void Update()
    {
       /*  PauseMenu();
        ResumeGame();
        print(ms.gamePause); */
        if (!(MenuScript.isGamePaused || MenuScript.isBuyMenuOpened))
        {
            poisen += 0.0001f;
            //Debug.Log("Can");
            if (health <= maxHealth)
            {
                playerHealth.value = health;
            }
            if (poisen <= 1f)
            {
                Toxin.value = poisen;
                if (poisen <= 1f)
                    health -= 0.01f;
                else if (poisen > 0 && poisen < 0.05f)
                    health -= 0.1f;
                else if (poisen > 0.05f && poisen < 0.09f)
                    health -= 0.6f;
                else if (poisen > 0.09f && poisen < 0.14f)
                    health -= 0.8f;
                else
                    health -= 1f;
            }
            else
            {
                ms.callME();
            }

        }
        else{
            Debug.Log("ali");
        }




    }
    private void PauseMenu(){
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu = true;
            pauseisPressed = true;
        }
    }

    private void ResumeGame(){
        if(pauseisPressed == true){
            pauseisPressed = false;
            pauseMenu = false;
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (playerHealth.value == 0f)
        {
            // Our player died !
            ms.callME();
        }
        else
        {
            playerHealth.value -= amount;
        }
    }
}
