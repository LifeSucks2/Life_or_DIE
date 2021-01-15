using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField] PlayerVitals pv;
    [SerializeField] AudioClip pickupSound;

    void OnTriggerEnter(Collider other){
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
   }
}
