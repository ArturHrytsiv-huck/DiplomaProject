using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject playerFollow;
    private Animator animator;

    private bool heroIsFind = false;
    private bool turnToCamp = false;
    public bool HeroIsFind
    {
        get { return heroIsFind; }
        set { heroIsFind = value; }
    }


    private Vector3 enemyPosition;
    private Vector3 wayPointPos;
    
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 10f;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !turnToCamp)
        {
            wayPointPos = other.transform.position;
            playerFollow = other.gameObject;
            HeroIsFind = true;
            animator.SetBool("isRun", HeroIsFind);
        }
        
    }
    private void Update()
    {
        if (heroIsFind && !turnToCamp)
        {
            LockOnPlayer();
            wayPointPos = new Vector3(playerFollow.transform.position.x, transform.position.y, playerFollow.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        }
        else if(!HeroIsFind && turnToCamp)
        {
            LockOnCamp();
            wayPointPos = enemyPosition;
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        }
        if(transform.position == enemyPosition && turnToCamp)
        {
           turnToCamp = false;
           animator.SetBool("isRun", false);

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
        HeroIsFind = false;
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
}
