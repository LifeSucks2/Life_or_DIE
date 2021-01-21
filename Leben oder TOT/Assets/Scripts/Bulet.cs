using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bulet : MonoBehaviour
{
    PlayerVitals pv;
    [SerializeField] AudioClip gettingShootSound;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col){
        if(col.transform.tag == "Player"){
            pv = col.gameObject.GetComponent<PlayerVitals>();
            pv.TakeDamage(10f);
            AudioSource.PlayClipAtPoint(gettingShootSound, Camera.main.transform.position, 5f);
            Destroy(gameObject);
            //print("damage taken");
        }
        
    }
}
