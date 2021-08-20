using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject playerFollow;
    private Animator animator;

    private bool followHero = false;
    private bool turnToCamp = false;
    private bool takeAttack = false;
    private bool takeDamageHero = true;
    public bool FollowHero
    {
        get { return followHero; }
        set { followHero = value; }
    }

    private Vector3 enemyPosition;
    private Vector3 wayPointPos;
    private Quaternion enemyStartRotation;

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float rangeAttack;
    [SerializeField] private float speedAttack;
    [SerializeField] private int costOfHead;

    private HealthComponent healthComponent;
    private AttackComponent attackComponent;
    private bool deathMoney = true;
    
    private void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
        attackComponent = GetComponent<AttackComponent>();
        enemyStartRotation = transform.rotation;
        animator = GetComponent<Animator>();
        enemyPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !turnToCamp)
        {
            wayPointPos = other.transform.position;
            playerFollow = other.gameObject;
            FollowHero = true;
            animator.SetBool("isRun", true);
            animator.SetBool("isIdle", false);
        }
        
    }
    private void Update()
    {
        if (healthComponent.IsDead)
        {
            Death();
        }
        if (FollowHero && !turnToCamp && !takeAttack)
        {
            MoveToHero();
        }
        else if(!FollowHero && turnToCamp && !takeAttack)
        {
            MoveBack();
        }
        if(transform.position == enemyPosition && turnToCamp)
        {
           transform.rotation = enemyStartRotation;
           turnToCamp = false;
           animator.SetBool("isRun", false);
           animator.SetBool("isIdle", true);           
        }
        if (followHero && playerFollow != null && (Vector3.Distance(transform.position, playerFollow.transform.position) <= rangeAttack))
        {
            takeAttack = true;
            LockOnPlayer();
            StartCoroutine("AttackPlayer");

        }
        else if (followHero && playerFollow != null && (Vector3.Distance(transform.position, playerFollow.transform.position) > rangeAttack))
        {
            takeAttack = false;
            animator.SetBool("isRun", true);
        }
        
    }
    private IEnumerator AttackPlayer()
    {
        
        if(takeDamageHero)
        {
            animator.SetBool("isRun", false);
            animator.SetTrigger("Attack");
            if (Vector3.Distance(playerFollow.transform.position, transform.position) <= rangeAttack && takeDamageHero)
            {
                takeDamageHero = false;
            }
            yield return new WaitForSeconds(speedAttack);
            if (Vector3.Distance(playerFollow.transform.position, transform.position) <= rangeAttack)
            {
                HealthComponent playerHealth = playerFollow.GetComponent<HealthComponent>();
                playerHealth.TakeDamage(attackComponent);
            }
            takeDamageHero = true;
        }
        
    }
    private void LockOnPlayer()
    {
        Vector3 dir = playerFollow.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    public void TurnBackToCamp()
    {
        FollowHero = false;
        turnToCamp = true;
        LockOnCamp();
        wayPointPos = enemyPosition;
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }
    private void LockOnCamp()
    {
        Vector3 dir = enemyPosition - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    private void MoveBack()
    {
        LockOnCamp();
        wayPointPos = enemyPosition;
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }
    private void MoveToHero()
    {
        LockOnPlayer();
        wayPointPos = new Vector3(playerFollow.transform.position.x, transform.position.y, playerFollow.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }
    private void Death()
    {
        followHero = false;
        turnToCamp = false;
        speed = 0;
        animator.SetBool("isRun", false);
        animator.SetBool("isIdle", false);
        animator.SetBool("Death", true);
        Destroy(gameObject, 3f);
        if (deathMoney)
        {
            ResourceManager resource = playerFollow.GetComponentInChildren<ResourceManager>();
            resource.Coins += costOfHead;
            deathMoney = false;
        }

    }

   
}
