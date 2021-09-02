using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image health;

	public void SetMaxHealth(int health)
	{
		healthBar.maxValue = health;
		healthBar.value = health;
	}

	public void SetHealth(int health)
	{
		healthBar.value = health;
	}

}
