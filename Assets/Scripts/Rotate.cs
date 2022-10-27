using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate : MonoBehaviour
{
    [SerializeField] Light objectLight;
    MeshRenderer meshRenderer;
    TextMesh textIndicator;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        objectLight = GetComponent<Light>();
        objectLight.color = meshRenderer.material.color;

    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
    
}
