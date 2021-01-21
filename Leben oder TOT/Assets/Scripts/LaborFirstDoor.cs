using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaborFirstDoor : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject enemy1, enemy2;
    void Start()
    {
        enemy1 = GameObject.Find("EnemySimple");
        enemy2 = GameObject.Find("EnemySimple (1)");
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy1 == null && enemy2 == null){
            Destroy(gameObject);
        }
    }
}
