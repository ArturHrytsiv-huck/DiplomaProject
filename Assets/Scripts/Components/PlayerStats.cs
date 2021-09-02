using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : HealthComponent
{
    [SerializeField] private int mana;
    [SerializeField] private int manaRegenSpeed;
    [SerializeField] private StatsUI manaUI;
    [SerializeField] private HealthUI healthUI;

    private int startMana;

    public Action OnManaChange;
    private void Start()
    {
        OnDamageDone += ChangeHealthBar;
        startMana = mana;
        //OnManaChange += ManaRegen;
        healthUI.SetMaxHealth(Health);
        manaUI.SetMaxMana(startMana);
        CastSpell(50);
    }

    private void ChangeHealthBar()
    {
        healthUI.SetHealth(Health);
    }
    private IEnumerator ManaRegen()
    {
        while(mana != startMana)
        {
           
            mana += manaRegenSpeed;
            manaUI.SetMana(mana);
            yield return new WaitForSeconds(1f);
        }
        
    }

    private void CastSpell(int spellManaCost)
    {
        if(spellManaCost > mana)
        {
            Debug.Log("Not enought mana"!);
            return;
        }
        else
        {
            mana -= spellManaCost;
            manaUI.SetMana(mana);
            //OnManaChange.Invoke();
            StartCoroutine( ManaRegen());
        }
    }
}
