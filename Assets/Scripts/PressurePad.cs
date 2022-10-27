using CustomAssetEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{

    [SerializeField]
    VoidEvent onPress;
    [SerializeField]
    VoidEvent onRelease;

    int pressedDistance =1;
    Vector3 pressedPosition ;
    Vector3 notPressedPosition;
    Transform bodyTransform;

    bool isPressed;

    private void Awake()
    {
        bodyTransform = GetComponentInChildren<MeshRenderer>().gameObject.transform;
    }
    void Start()
    {
        notPressedPosition = bodyTransform.position;
        pressedPosition = bodyTransform.position + (-bodyTransform.up * pressedDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            if(bodyTransform.position != pressedPosition)
            {
                bodyTransform.position = Vector3.MoveTowards(bodyTransform.position,pressedPosition, Time.deltaTime * 2);
            }
        }else if( bodyTransform.position != notPressedPosition)
        {
            bodyTransform.position = Vector3.MoveTowards(bodyTransform.position, notPressedPosition, Time.deltaTime);

            if(bodyTransform.position == notPressedPosition)
            {
                onRelease?.Raise();

            }
        }
      

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            onPress?.Raise();
            isPressed = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            isPressed = false;

        }
    }
}
