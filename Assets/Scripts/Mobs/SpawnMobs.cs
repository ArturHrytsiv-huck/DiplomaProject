using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{
    private CampFire camp;
    private int mobsAmount;
    public MobToSpawn mobToSpawn;

    private void Start()
    {
        
        camp = GetComponent<CampFire>();
        mobsAmount = mobToSpawn.MobsAmount(camp.CampLvl);
        SpawnMob();
    }
    
    private void SpawnMob()
    {
        for (int i = 0; i < mobsAmount; i++)
        {
            int randSpawnPoint = Random.Range(0, camp.spawnPoints.Count);
            while (camp.spawnPoints[randSpawnPoint].IsActive)
            {
                randSpawnPoint = Random.Range(0, camp.spawnPoints.Count);
            }
            camp.spawnPoints[randSpawnPoint].IsActive = true;
            camp.spawnPoints[randSpawnPoint].spawnedMob = Instantiate(mobToSpawn.PrfabToSpawn(camp.CampLvl), camp.spawnPoints[randSpawnPoint].transform.position, camp.spawnPoints[randSpawnPoint].transform.rotation);
            camp.spawnPoints[randSpawnPoint].spawnedMob.transform.rotation = LockOnCamp(camp.spawnPoints[randSpawnPoint].spawnedMob.transform);
            camp.spawnPoints[randSpawnPoint].tag = "Mob";
        }
    }

    private Quaternion LockOnCamp(Transform rotate)
    {
        Vector3 dir = camp.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotate.transform.rotation, lookRotation, 10 * Time.deltaTime).eulerAngles;
        rotate.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        return rotate.transform.rotation;
    }

}
