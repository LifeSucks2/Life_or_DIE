using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaborTileSystem : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Update(){
        CheckWhereUserIsAt();
    }
    void CheckWhereUserIsAt(){
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;

        if (x >= -50f && x <= -46f){
            print("erste IF");
            if(y >= 0.5f && y <= 8f){
                print("zweite IF");
                if(z >= 43.21f && z <= 53.21f){
                    print("dritte IF");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                } 
            }
        }

    }
}
