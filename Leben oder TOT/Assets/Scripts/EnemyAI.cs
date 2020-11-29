using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float speed = 10f;
    public float seeingDistance;
    public float shootingDistance;
    public float timeBtwShots;
    public float startTimeBtwShots;
    private Transform player;

    // Start is called before the first frame update
    void Start() {
        //player = GameObject.FindGameObjectWithTag("Player").transform;    
        player = GameObject.FindWithTag("Player").transform; //Fand ich nur schöner
    }

    // Update is called once per frame
    void Update() {

        

        if(Vector3.Distance(transform.position, player.position) >= seeingDistance) {
            transform.position = this.transform.position;
            print(Vector3.Distance(transform.position, player.position));
        }
        else if(Vector3.Distance(transform.position, player.position) > shootingDistance && Vector3.Distance(transform.position, player.position) <= seeingDistance) {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.LookAt(player); //Rotate to Player
        } 
        else if(Vector3.Distance(transform.position, player.position) == shootingDistance) {
            transform.position = this.transform.position;
            transform.LookAt(player); //Rotate to Player
        }
        else if(Vector3.Distance(transform.position, player.position) < shootingDistance) {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            transform.LookAt(player); //Rotate to Player
        }
    }
}
