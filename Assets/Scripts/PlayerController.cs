using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    short speed;

    CharacterController controller;
    float moveX;
    float moveY;

    float yVelocity;
    Vector3 movement;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       moveY = Input.GetAxisRaw("Vertical");
        moveX = Input.GetAxisRaw("Horizontal");

       movement= transform.forward * moveY + transform.right * moveX;

        yVelocity -= 9.8f * Time.unscaledDeltaTime;

        movement.y = yVelocity;
    
        controller.Move(movement * speed * Time.unscaledDeltaTime);


        if (controller.isGrounded)
        {
            yVelocity = 0;

        
        }
    }
}
