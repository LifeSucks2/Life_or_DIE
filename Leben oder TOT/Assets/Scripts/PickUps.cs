using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField] PlayerVitals pv;
    [SerializeField] AudioClip pickupSound;
    [SerializeField] GameObject player;
    private int ammo1, tmp;
    private int magazin = 120;

    void OnTriggerEnter(Collider other){
        //Health Packs
        if(pv.health < pv.maxHealth){
            if(other.tag == "Bottle_Health"){
                if(pv.health > 190f){
                    pv.health = pv.maxHealth;
                }
                else{
                    pv.health += 10f;
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
        if(other.tag == "ammo_pick_up"){
            ammo1 = player.GetComponent<AutomaticGunScriptLPFP>().ammo;
            ammo1 += 30;
            if(ammo1 > 120){
                ammo1 = 120;
            }
            player.GetComponent<AutomaticGunScriptLPFP>().ammo = ammo1;
            player.GetComponent<AutomaticGunScriptLPFP>().totalAmmoText.text = ammo1.ToString();
            Destroy(other.gameObject);
        }
        
   }
}
