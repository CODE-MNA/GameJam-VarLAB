using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEffect : MonoBehaviour
{
    [SerializeField]
    Animation timeEffect;

    [SerializeField]
    Animation switchOffOldEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTimeEffect()
    {
        timeEffect.Play();
        switchOffOldEffect.Play();
    }
}
