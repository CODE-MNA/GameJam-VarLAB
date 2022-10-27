using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignShooters : MonoBehaviour
{
    [SerializeField]
    int maxRot;

    [SerializeField]
    int minRot;

    Vector3 initEulers;
    List<float> rotations = new List<float>();

    void Start()
    {
        

        for (int i = 0; i < transform.childCount; i++)
        {
            rotations.Add( GenerateRotation(i));
        }
        

    }

    // Update is called once per frame
    void Update()
    {

       
    }


    float GenerateRotation(int index)
    {

        float rotation = minRot;

        float step = (maxRot - minRot)/transform.childCount;

        rotation += step * index;
        return rotation;
    }


    void RotateChildren()
    {
        Transform nextChild;
        for (int i = 0; i < transform.childCount; i++)
        {
            nextChild = transform.GetChild(i);
          
        }
    }


    IEnumerator SmoothRotate(Transform objectToRotate,Vector3 finalEuler)
    {
        Vector3 currentEuler = objectToRotate.rotation.eulerAngles;
        while(finalEuler != objectToRotate.rotation.eulerAngles)
        {
          
            yield return null;
        }
    }
}
