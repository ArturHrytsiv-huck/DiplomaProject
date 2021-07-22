using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] float turnSmoothtime = 0.1f;

    public CharacterController controller;
    public Transform cam;

    private float turnsmoothVelocity;
    private Animator dogAnimation;
    private Rigidbody dogBody;
    // Start is called before the first frame update
    void Start()
    {
        dogAnimation = GetComponent<Animator>();
        dogBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isRun = false;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            isRun = true;
            dogAnimation.SetBool("Run", isRun);
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnsmoothVelocity, turnSmoothtime);
            transform.rotation = Quaternion.Euler(0f, TargetAngle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
        else //if(!(Input.GetKeyDown(KeyCode.W)) || !(Input.GetKeyDown(KeyCode.S)) || !(Input.GetKeyDown(KeyCode.A)) || !(Input.GetKeyDown(KeyCode.D)))
        {
            isRun = false;
            dogAnimation.SetBool("Run", isRun);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            dogAnimation.SetTrigger("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            dogAnimation.SetTrigger("Defend");
        }


    }
}
