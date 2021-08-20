using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
   [SerializeField] private int coins;
   [SerializeField] private Text coinsAmount;
    
    public int Coins
    {
        get { return coins; }
        set => coins = value;
    }
    private void Update()
    {
        coinsAmount.text = coins.ToString();
    }
}
