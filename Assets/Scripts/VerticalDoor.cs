using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDoor : MonoBehaviour
{
    Vector3 targetOpenPosition;
    Vector3 targetClosePosition;

    private int openDistance = 3;

    void Start()
    {
        targetClosePosition = transform.position;
        targetOpenPosition = transform.position + transform.up * openDistance;

    }

    void Update()
    {
    }

    IEnumerator OpenDoorCoroutine()
    {
        while(Mathf.Abs(transform.position.y - targetOpenPosition.y)>0.1f)
        {
            transform.Translate(transform.up * openDistance * Time.deltaTime);
            yield return null;

        }
    }

    public void OpenDoor()
    {
        StartCoroutine(nameof(OpenDoorCoroutine));
    }
    public void CloseDoor()
    {
        StartCoroutine(nameof(CloseDoorCoroutine));
    }

    private IEnumerator CloseDoorCoroutine()
    {
        while (Mathf.Abs(transform.position.y - targetClosePosition.y) >0.1f)
        {
            transform.Translate(-transform.up * openDistance * Time.deltaTime);
            yield return null;

        }
    }
}
