using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamreaMovement : MonoBehaviour
{
    public float mouseSensivity = 100f;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
      transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity, 0, 0);
      Player.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity, 0);
    }
}
