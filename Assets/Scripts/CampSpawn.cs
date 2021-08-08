using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSpawn : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private GameObject campFire;
    [SerializeField] private int campLvl;
    [SerializeField] private Transform spawnPoint;
    
    private int goblinsAlive;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(spawnPoint.position);
        Vector3 goblinReplace = spawnPoint.position;
        goblinReplace.z += 3;
        goblinReplace.x += 1;
        Instantiate(campFire, spawnPoint.position, spawnPoint.rotation);
        Instantiate(monsterPrefab, goblinReplace, spawnPoint.rotation);
    }


}
