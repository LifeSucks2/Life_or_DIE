using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScript : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;
    public float seeingDistance = 16.44314f;
    public GameObject bullet;
    public GameObject shootPoint;
    public float shootSpeed = 10;
    public float timeToShoot = 1.3f;
    float orginaltime;
    public float walkSpeed = 4f;
    // Start is called before the first frame update
    void Start(){
        orginaltime = timeToShoot;
    }

    // Update is called once per frame
    void Update(){
        if(detected){
            enemy.LookAt(target.transform);
            if(Vector3.Distance(enemy.position, target.transform.position) <= seeingDistance){
                enemy.position = Vector3.MoveTowards(enemy.position, target.transform.position, walkSpeed * Time.deltaTime);
                timeToShoot -= Time.deltaTime;
                if(timeToShoot < 0){
                    ShootPlayer();
                    timeToShoot = orginaltime;
                }
            }  
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
            //print(Vector3.Distance(transform.position, target.transform.position));
        }
    }
    //PlayerVitals pv = new PlayerVitals();
    private void ShootPlayer(){
        GameObject currentBullet = Instantiate(bullet,shootPoint.transform.position, shootPoint.transform.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }
}
