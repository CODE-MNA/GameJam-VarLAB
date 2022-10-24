using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    short speed;

    CharacterController controller;
    Vector3 _input;

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
       _input.z = Input.GetAxisRaw("Vertical");
        _input.x = Input.GetAxisRaw("Horizontal");

        controller.Move(_input.normalized * speed * Time.deltaTime);
    }
}
