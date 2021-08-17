using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] private GameObject camp;
    [SerializeField] private GameObject campFirePrefab;
    [SerializeField] private int campLvl = 1;
    private Collider range;
    public List<SpawnPoint> spawnPoints;

    

    public int CampLvl
    {
        get { return campLvl; }
    }

    private void Start()
    {
        range = GetComponent<SphereCollider>();
        Instantiate(campFirePrefab, camp.transform.position, camp.transform.rotation);
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player")
        {
            return;
        }
        if(collider.tag == "Mob")
        {
            EnemyBehaviour enemy = collider.gameObject.GetComponent<EnemyBehaviour>();
            enemy.TurnBackToCamp();
        }
    }
}

