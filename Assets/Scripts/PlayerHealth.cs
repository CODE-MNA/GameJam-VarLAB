using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IHealth
{
    [SerializeField]
    private int maxHealth = 3;
    public Action OnDeath { get; set; }

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
        }
        
    }


    public void Damage(int damage)
    {
        if(damage > 0)
        {
            Health -= damage;
        }

        if(Health <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
