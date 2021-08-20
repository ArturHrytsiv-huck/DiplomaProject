using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderComponent : MonoBehaviour
{
    [SerializeField] private Collider attackCollider;
    [SerializeField] private List<HealthComponent> collidersInRadius;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mob" && !collidersInRadius.Contains(other.GetComponentInParent<HealthComponent>()))
        {
            collidersInRadius.Add(other.GetComponentInParent<HealthComponent>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Mob")
        {
            collidersInRadius.Remove(other.GetComponentInParent<HealthComponent>());
        }
    }

    public List<HealthComponent> GetAllColliders()
    {
        return collidersInRadius;
    }
}
