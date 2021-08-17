using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBackMob : MonoBehaviour
{
    private CampFire camp;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Enemy left Camp!");
        }
    }
}
