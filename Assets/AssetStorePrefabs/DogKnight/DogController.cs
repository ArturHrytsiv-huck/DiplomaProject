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
        Movement.y = -10f;
        Vector2 vector2 = new Vector2(Movement.x, Movement.z);
        controller.Move(Movement);

        if (vector2.magnitude != 0f)
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

