using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{

    public Text myText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myText.text = "Well Done";
        }
    }


    private void OnTriggerExit(Collider other)
    {
        myText.text = "Did you know...";
    }
}
