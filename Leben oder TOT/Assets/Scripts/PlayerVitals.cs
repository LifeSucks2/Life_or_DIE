using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerVitals : MonoBehaviour
{
    public int points = 0;
    public float health = 50f;
    public Slider playerHealth;
    public MenuScript ms;

    void start()
    {
        playerHealth.minValue = 0f;
        playerHealth.maxValue = health;
        playerHealth.value = health;
    }

   
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (playerHealth.value == 0f)
        {
            // Our player died !
            ms.callME();
        }else
        {
            playerHealth.value -= amount;
        } 
    }
}
