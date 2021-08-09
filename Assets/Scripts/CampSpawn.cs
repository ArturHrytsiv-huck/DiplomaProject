using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSpawn : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private GameObject campFire;
    [SerializeField] private int campLvl;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] spawnPointSpawn;
    

    void Start()
    {
       

        Instantiate(campFire, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Spawn();
    }

    private void Spawn()
    {
        int spawnAmount = returnCountOfMonsters();
        for (int i = 0; i < spawnAmount; i++)
        {
            int randNum = Random.Range(0, spawnPointSpawn.Length);
            while (spawnPointSpawn[randNum].layer != 0)
            {
                randNum = Random.Range(0, spawnPointSpawn.Length);
            }
            spawnPointSpawn[randNum] = (GameObject)Instantiate(monsterPrefab, spawnPointSpawn[randNum].transform.position, spawnPointSpawn[randNum].transform.rotation);
            spawnPointSpawn[randNum].layer = LayerMask.NameToLayer("Enemy");
        }

    }

    private int returnCountOfMonsters()
    {
        return campLvl / 2;
    }


}
