using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomAssetEvents;

public class TimeControl : MonoBehaviour
{
    [SerializeField]
    float cooldownOriginal = 8f;
    float cooldownTimer;

    [SerializeField]
    float abilityOriginal = 3f;
    float abilityTimer;

    bool triggered = false;

    [SerializeField]
    VoidEvent onAbilityActivate;

    [SerializeField]
    VoidEvent onAbilityDeactivate;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownTimer <= 0)
        {
            cooldownTimer = 0;
            if (Input.GetKeyDown(KeyCode.LeftShift))
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

            onAbilityActivate?.Raise();
        }

        if(abilityTimer <= 0 &&  Time.timeScale != 1)
        {
            ResetTime(Time.unscaledDeltaTime);
        }
        else if(Time.timeScale != 1)
        {

            abilityTimer -= Time.unscaledDeltaTime;

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //reset faster
                ResetTime(Time.unscaledDeltaTime * 40);
            }
        }
    }

    private void ActivateSlowdown()
    {

        Time.timeScale = 0.05f;
        abilityTimer = abilityOriginal;
    }

    private void ResetTime(float resetSpeed)
    {
        abilityTimer = 0;

        if (Time.timeScale != 1)
        {
            
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1, resetSpeed);
        }

        //Completed resetted on this frame
        if(Time.timeScale == 1)
        {
            onAbilityDeactivate?.Raise();
        }
        

    }

    IEnumerator ResetCamColour()
    {
        yield return null;  
    }
}
