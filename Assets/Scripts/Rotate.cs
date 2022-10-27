using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Light objectLight;
    private void Start()
    {
        objectLight = GetComponent<Light>();
        objectLight.color = GetComponent<MeshRenderer>().material.color;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
