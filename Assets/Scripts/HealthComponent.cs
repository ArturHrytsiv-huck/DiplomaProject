using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get
        {
            return health;
        }
        private set => health = value;
    }
    [SerializeField] private bool isDead;
    public bool IsDead { get => isDead; }

    public Action<int> OnHealthChanged { get; set; }
    public Action OnDead { get; }
    /*public void ProcessDamage(AttackComponent attackComponent)
    {
        //if(attackComponent.type != hollyAttack) return;
        health -= attackComponent.Damage;

        if (health <= 0)
        {
            isDead = true;
            health = 0;
            OnDead?.Invoke();
        }

        OnHealthChanged?.Invoke(health);
    }*/
}
