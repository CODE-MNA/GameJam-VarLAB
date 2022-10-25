using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    [SerializeField]
    float cooldownOriginal = 8f;
    float cooldownTimer;

    [SerializeField]
    float abilityOriginal = 3f;
    float abilityTimer;

    bool triggered = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownTimer <= 0)
        {
            cooldownTimer = 0;
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                cooldownTimer = cooldownOriginal;
                triggered = true;
            }
           
        }
        else
        {
            cooldownTimer -= Time.unscaledDeltaTime;
        }

        if (triggered)
        {
            ActivateSlowdown();

            triggered = false;
        }

        if(abilityTimer <= 0)
        {
            abilityTimer = 0;

            if(Time.timeScale != 1)
            {
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1, Time.unscaledDeltaTime);
            }
        }
        else
        {
            abilityTimer -= Time.unscaledDeltaTime;
        }
    }

    private void ActivateSlowdown()
    {
        print("Activating Time");

        Time.timeScale = 0.1f;
        abilityTimer = abilityOriginal;
    }
}
