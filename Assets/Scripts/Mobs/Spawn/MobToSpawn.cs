using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobToSpawn : MonoBehaviour
{
    public GameObject goblinPrefab;
    public List<GameObject> bugPrefabs;
    public List<GameObject> golemPrefabs;
    public GameObject PrfabToSpawn(int campLvl)
    {
        if(campLvl <= 10)
        {
            return goblinPrefab;
        }
        if (campLvl > 10 && campLvl <= 30)
        {
            int randBug = Random.Range(0, 3);
            return bugPrefabs[randBug];
        }
        else
        {
            int randBug = Random.Range(0, 2);
            return golemPrefabs[randBug];
        }
    }

    public int MobsAmount(int campLvl)
    {   
        if(campLvl <= 10)
        {
            return campLvl;
        }
        if (campLvl > 10 && campLvl <= 30)
        {
            return (campLvl - 10) / 2;
        }
        else
        {
            int amount = 0;
            for (int i = 1; i < campLvl - 30; i+=5)
            {
                amount++;
            }
            if(campLvl % 5 != 0)
            {
                return ++amount;
            }
            return amount;
        }
            
    }
}
