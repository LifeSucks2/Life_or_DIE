using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickUps : MonoBehaviour
{
    [SerializeField] PlayerVitals pv;
    [SerializeField] AudioClip pickupSound, ammoPickupSound;
    [SerializeField] GameObject player;
    [SerializeField] Text hint;

    private int ammo1, tmp;
    private int magazin = 120;

    void OnTriggerEnter(Collider other){
        //Health Packs
        if(pv.health < pv.maxHealth){
            if(other.tag == "Bottle_Health"){
                if(pv.health > 180f){
                    pv.health = pv.maxHealth;
                }
                else{
                    pv.health += 20f;
                }
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(other.gameObject);
            }
        }
        //Antitoxin Packs
        if(pv.poisen > 0f) {
            if(other.tag == "Bottle_Antitoxin"){
                pv.poisen -= 0.1f;
                AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
                Destroy(other.gameObject);
                if(pv.poisen < 0){
                    pv.poisen = 0;
                }
            }
        }
        //Ammo Packs
        if(other.tag == "ammo_picked_up"){
            //print("ammo pickup");
            ammo1 = player.GetComponent<AutomaticGunScriptLPFP>().ammo;
            ammo1 += 10;
            if(ammo1 > magazin){
                ammo1 = magazin;
            }
            player.GetComponent<AutomaticGunScriptLPFP>().ammo = ammo1;
            player.GetComponent<AutomaticGunScriptLPFP>().totalAmmoText.text = ammo1.ToString();
            AudioSource.PlayClipAtPoint(ammoPickupSound, Camera.main.transform.position);
            Destroy(other.gameObject);
        }
        if(other.tag == "Bottle_Mana"){
            hint.text = "Herzlichen Glückwunsch, du has das Spiel durchgespielt";
            hint.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(other.gameObject);
            StartCoroutine(waitForSeconds());
        }
   }
    IEnumerator waitForSeconds(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
