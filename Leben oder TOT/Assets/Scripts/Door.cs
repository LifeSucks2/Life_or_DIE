using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    bool key = false;
    [SerializeField] MenuScript ms;
    [SerializeField] Text hint;
    [SerializeField] AudioClip pickupSound;
    void  OnTriggerEnter(Collider other){
        if(other.tag == "LaborDoor3"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(other.tag == "LaborDoor1)"){
            ms.callME();
        }
        if(other.tag == "LaborDoor2"){
            ms.callME();
        }
        if(other.tag == "HintFuerLaborDoor"){
            if(key == false){
                hint.gameObject.SetActive(true);
            }
            else{
                hint.gameObject.SetActive(false);
            }
        }
        if(other.tag == "LaborDoor4"){
            if(key == false){
                hint.text = "Du musst noch den schlüssel finden";
                hint.gameObject.SetActive(true);
            }
            else{
                gameObject.transform.position = new Vector3(-113.8f, 9f, 53.9f);
            }
        }
        if(other.tag == "LaborKey"){
            key = true;
            hint.text = "Nun kannst du die Türe öffnen";
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(other.gameObject);
            waitForHumanToRead();

        }
           
    }
    IEnumerator waitForHumanToRead(){
        yield return new WaitForSeconds(10);
        hint.gameObject.SetActive(false);
    }
}
