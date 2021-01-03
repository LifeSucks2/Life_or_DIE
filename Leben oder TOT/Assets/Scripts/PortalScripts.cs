using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScripts : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.transform.position.x >= 120.5f && player.transform.position.x <= 126f 
            && player.transform.position.z >= 303f && player.transform.position.z <= 307f) // User decided to repeat the tutorial
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
            if (player.transform.position.x >= 154.5f && player.transform.position.x <= 159.56f 
            && player.transform.position.z >= 303.85f && player.transform.position.z <= 307f )
            {
                // Change Scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
