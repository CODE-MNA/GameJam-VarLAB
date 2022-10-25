using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    float mouseSens;

    float mouseX;
    float mouseY;

    CharacterController characterController;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = (mouseY + Input.GetAxis("Mouse Y") * mouseSens) % 360;


        transform.Rotate(0, mouseX * mouseSens , 0);

        mouseY = Mathf.Clamp(mouseY, -80f, 70f);

        cam.transform.localEulerAngles = new Vector3(-mouseY, 0, 0);


    }
}
