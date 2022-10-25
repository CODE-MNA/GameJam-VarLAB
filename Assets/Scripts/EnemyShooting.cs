using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    float timeBetweenShots = 4f;
    float shotTimer = 4f;

    [SerializeField]
    Transform shotPoint;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    private float bulletSpeed = 15f;

    void Start()
    {
        shotTimer = timeBetweenShots;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shotTimer <= 0)
        {
            print("shotting");
            Shoot();
            shotTimer = timeBetweenShots;

        }
        else
        {
            print("cutting");

            shotTimer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(projectile, shotPoint.position,shotPoint.rotation,shotPoint) ;
        Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();

        rbBullet.AddForce(shotPoint.up * bulletSpeed, ForceMode.Impulse);



    }
}
