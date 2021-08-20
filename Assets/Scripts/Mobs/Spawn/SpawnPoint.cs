using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameObject spawPoint;
    public GameObject spawnedMob;
    private bool isActive = false;

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
    public Action<GameObject> mobBeh;
    private void Awake()
    {
        spawPoint = this.gameObject;
    }

    //On mob death 
}
