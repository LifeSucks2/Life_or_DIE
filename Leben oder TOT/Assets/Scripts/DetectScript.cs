using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScript : MonoBehaviour
{
    GameObject target;
    public Transform enemy;
    const float seeingDistance = 40;
    const float stopingDistance = 12;
    public GameObject bullet;
    public GameObject shootPoint;
    public float shootSpeed = 10;
    public float timeToShoot = 1.3f;
    float orginaltime;
    public float walkSpeed = 4f;
    float tmp;
    // Start is called before the first frame update
    void Start(){
        orginaltime = timeToShoot;
        target = GameObject.FindGameObjectWithTag("Player");
        print(target.tag);
    }

    // Update is called once per frame
    void Update(){
        tmp = Vector3.Distance(transform.position, target.transform.position);
        //print("Distance außerhalb if" + tmp);
        if(tmp <= seeingDistance && tmp >= stopingDistance){
           //print("Distance innerhalb if" + tmp);
            enemy.LookAt(target.transform);
            enemy.position = Vector3.MoveTowards(enemy.position, target.transform.position, walkSpeed * Time.deltaTime);
            timeToShoot -= Time.deltaTime;
            if(timeToShoot < 0){
                ShootPlayer();
                timeToShoot = orginaltime;   
            }  
        }
        else if(tmp <= stopingDistance){
            timeToShoot -= Time.deltaTime;
            if(timeToShoot < 0){
                ShootPlayer();
                timeToShoot = orginaltime;   
            }  
        }
    }
    private void ShootPlayer(){
        GameObject currentBullet = Instantiate(bullet,shootPoint.transform.position, shootPoint.transform.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }
}
