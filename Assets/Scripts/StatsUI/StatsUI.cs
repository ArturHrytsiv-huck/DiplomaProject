using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    
    [SerializeField] private Slider manaBar;

    [SerializeField] private Image mana;

	public void SetMaxMana(int mana)
	{
		manaBar.maxValue = mana;
		manaBar.value = mana;
	}

	public void SetMana(int mana)
	{
		manaBar.value = mana;
	}
}
