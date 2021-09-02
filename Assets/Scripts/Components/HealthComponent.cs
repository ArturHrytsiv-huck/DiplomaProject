using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        set => health = value;
    }
    [SerializeField] private bool isDead = false;
    public bool IsDead
    {
        get { return isDead; }
    }
    public Action OnDamageDone;


    public void TakeDamage(AttackComponent attack)
   {
        if (IsDead)
        {
            return;
        }
        
        health -= attack.GiveDamage();
        if (health <= 0)
        {
            isDead = true;
        }
        if ((attack.tag) != "Player")
        {
            OnDamageDone.Invoke();
        }
        

    }
}
