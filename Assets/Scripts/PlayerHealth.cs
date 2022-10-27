using CustomAssetEvents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IHealth
{
    [SerializeField]
    private int maxHealth = 3;


    public VoidEvent OnDeath;

    private int _health;
    public int Health 
    {
        get
        {
            return _health;
        }
         set
        {
            if(value > maxHealth)
            {
                _health = maxHealth;
            }else if(value > 0)
            {
                _health=value;
            }
            else
            {
                _health=0;
            }

            if (_health <= 0)
            {
                OnDeath?.Raise();
            }
        }
        
    }


    public void Damage(int damage)
    {
        if(damage > 0)
        {
            Health -= damage;
        }

        if(_health <= 0)
        {
            OnDeath?.Raise();
            Destroy(this);
        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
