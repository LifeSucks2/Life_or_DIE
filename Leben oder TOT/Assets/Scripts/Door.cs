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
   // [SerializeField] PlayerVitals pv; 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LaborDoor3")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.tag == "LaborDoor1)")
        {
            ms.callME();
        }
        if (other.tag == "LaborDoor2")
        {
            ms.callME();
        }
        if (other.tag == "HintFuerLaborDoor")
        {
            if (key == false)
            {
                hint.gameObject.SetActive(true);
            }
            else
            {
                hint.gameObject.SetActive(false);
            }
        }
        if (other.tag == "LaborDoor4")
        {
            if (key == false)
            {
                hint.text = "Du musst noch den Schlüssel finden";
                hint.gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.position = new Vector3(-113.8f, 9f, 53.9f);
            }
        }
        if (other.tag == "LaborKey")
        {
            key = true;
            hint.text = "Nun kannst du die Türe öffnen";
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(other.gameObject);
            hint.gameObject.SetActive(false);
        }
        if (other.tag == "GetTheAntitoxinDoor")
        {
            if (key == false)
            {
                hint.text = "Du musst noch den Schlüssel finden";
                hint.gameObject.SetActive(true);
            }
            else
            {
                /* Bossfight */
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (other.tag == "DeactivateText")
        {
            hint.gameObject.SetActive(false);
        }
        if (other.tag == "KeyRoomExit")
        {
            gameObject.transform.position = new Vector3(38.62f, 8.44f, 299.7f);
        }
        if(other.tag == "FlurExitDoor"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}