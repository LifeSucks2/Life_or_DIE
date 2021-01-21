using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelDoor : MonoBehaviour
{
    [SerializeField] GameObject raetsel;
    [SerializeField] MenuScript ms; 
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            raetsel.SetActive(true);
            Screen.lockCursor = false;
            ms.PauseGame();
            ms.pauseMenu.SetActive(false);
            MenuScript.isGamePaused = true;
        }
    }
}
