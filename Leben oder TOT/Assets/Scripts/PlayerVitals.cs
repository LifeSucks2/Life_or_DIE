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

    void start()
    {
        playerHealth.minValue = 0f;
        playerHealth.maxValue = health;
        playerHealth.value = health;

        Toxin.minValue = 0f;
        Toxin.maxValue = 1f;
        Toxin.value = poisen;
    }

    void Update(){
        poisen += 0.0001f;
        /*if(poisen == 0.1f){
            print("hurra");
            health -= 15f;
        }*/
        

        if(health <= maxHealth){
            playerHealth.value = health;
        }
        if(poisen <= 1f){
            Toxin.value = poisen;
        }
        else{
            ms.callME();
        }

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
