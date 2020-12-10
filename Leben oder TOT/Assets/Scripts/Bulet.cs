using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    PlayerVitals pv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col){
        if(col.transform.tag == "Player"){
            pv = col.gameObject.GetComponent<PlayerVitals>();
            pv.TakeDamage(10f);
            //print("damage taken");
        }
    }
}
