using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaetselButton : MonoBehaviour
{
    [SerializeField] Text answer, hint;
    [SerializeField] GameObject wrongAnsw;
    [SerializeField] GameObject raetsel;
    [SerializeField] GameObject player;

    [SerializeField] MenuScript ms;
    public void SolveTheQuestion()
    {
        if(answer.text == "M" || answer.text == "m"){
            raetsel.SetActive(false);
            wrongAnsw.SetActive(false);
            Screen.lockCursor = true;
            player.transform.position = new Vector3(-107.38f, 8.5f, 187.02f);
            ms.ResumeGame();
            MenuScript.isGamePaused = false;
        }
        else{
            wrongAnsw.SetActive(true);
        }
    }
    public void HintForTheQuestion(){
        if(hint.gameObject.active == true){
            hint.gameObject.SetActive(false);
        }
        else{
            hint.gameObject.SetActive(true);
        }
    }
}
