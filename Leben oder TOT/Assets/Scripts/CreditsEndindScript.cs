using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsEndindScript : MonoBehaviour
{
   [SerializeField] private float delayBeforeLoad = 100f; // Length of our Video + 1 second 
    
    private float timeElapsed;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= delayBeforeLoad)
        {
            SceneManager.LoadScene(0);
        }
    }
}
