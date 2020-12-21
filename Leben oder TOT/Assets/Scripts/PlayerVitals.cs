using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerVitals : MonoBehaviour
{
    public int points = 1000;
    public float health = 50f;
    public Slider playerHealth;

    void start()
    {
        playerHealth.maxValue = health;
        playerHealth.value = health;
    }

   
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Debug.Log("Dead");
        }

        playerHealth.value -= amount;

    }



}
