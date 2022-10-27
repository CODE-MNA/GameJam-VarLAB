using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField]
    int detectorRange = 10;

    [SerializeField]
    int detectorAngle = 20;
    Transform player;
    Light spotlight;

    // Start is called before the first frame update
    void Start()
    {
        InitializeSpotLight();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerInVision())
        {
            print("Player Hit!");
           
            //TODO: Implement death logic
        }
        else
        {
        }


    }

    //Returns true if enemy can detect player
    bool PlayerInVision()
    {
        if(Time.timeScale != 1) return false;
        Vector3 dirToPlayer = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z);

        if(dirToPlayer.magnitude > detectorRange) return false;

        dirToPlayer.Normalize();

        int mask = 1 << gameObject.layer;
        mask = ~mask;

        if (Physics.Raycast(transform.position, dirToPlayer, out RaycastHit hit, detectorRange,layerMask:mask))
        {
            
            float angleToPlayer = Vector3.Angle(dirToPlayer, transform.forward);

            if (angleToPlayer > detectorAngle/2)
            {
                return false;
            }

            if (hit.transform.CompareTag("Player"))
            {
                //Remove all health
               IHealth playerHealth = hit.transform.GetComponent<IHealth>();
                playerHealth.Damage(playerHealth.Health);

                return true;

            }
           
        }

        return false;
    }


    //Adjusts spotlight properties based on the detector properties
    void InitializeSpotLight()
    {
        spotlight = GetComponentInChildren<Light>();

        spotlight.spotAngle = detectorAngle;
        spotlight.range = detectorRange;
    }


}
