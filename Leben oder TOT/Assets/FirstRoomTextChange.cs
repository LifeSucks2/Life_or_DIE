using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FirstRoomTextChange : MonoBehaviour
{
    public Text myText;
    private bool w = true, a = true, s = true, d = true, space = true;

    // Start is called before the first frame update
    void Start()
    {
        //welcome Screen
        myText.text = "Press W to Move Foreward";
    }

    // Update is called once per frame
    void Update()
    {
        //Press A to change the Text
        if (w == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                myText.text = "Press S to Backwards";
                w = false;
            }
        }
        //Press W to change the Text
        if (s == true)
        {
            if (Input.GetKey(KeyCode.S))
            {
                myText.text = "Press A to Left";
                s = false;
            }
        }
        //Press A to change the Text
        if (a == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                myText.text = "Press D to Right";
                a = false;
            }
        }
        //Press A to change the Text
        if (d == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                myText.text = "Press Space to Jump";
                d = false;
            }
        }

        //Press A to change the Text
        if (space == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                myText.text = "Good Job";
                space = false;
            }
        }
    }
}
