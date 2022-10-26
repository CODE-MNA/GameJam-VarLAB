using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<IHealth>().Damage(1);
        }

        DestroyBullet();
    }

    void DestroyBullet()
    {
        //to do spawn particles

        Destroy(gameObject);
    }
}
