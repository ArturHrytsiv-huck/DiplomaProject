/*using System.Collections;
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
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public CharacterController controller;
    private Animator dogAnimation;

    public float Speed;

    public Transform Cam;

    void Start()
    {
        dogAnimation = GetComponent<Animator>();

        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isRun = false;
        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
  
        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Movement.y = 0f;

        controller.Move(Movement);

        if (Movement.magnitude != 0f)
        {
            isRun = true;
            dogAnimation.SetBool("Run", isRun);

            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraMovement>().sensivity * Time.deltaTime);
            
            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

        }
        else
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

