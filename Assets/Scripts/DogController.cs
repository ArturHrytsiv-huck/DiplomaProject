using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    private CharacterController controller;
    private Animator dogAnimation;

    [SerializeField] private float Speed;
    [SerializeField] private ColliderComponent collidersInRadius;
    [SerializeField] private AttackComponent attackComponent;
    [SerializeField] private PlayerStats healthComponent;
    
    public Transform Cam;

   
    void Start()
    {
        //healthComponent = GetComponent<PlayerStats>();
        dogAnimation = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        attackComponent = GetComponent<AttackComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthComponent.IsDead)
        {
            dogAnimation.SetBool("Death", true);
           
        }
        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Movement.y = -10f;
        Vector2 vector2 = new Vector2(Movement.x, Movement.z);
        controller.Move(Movement);

        if (vector2.magnitude != 0f && !healthComponent.IsDead)
        {

            dogAnimation.SetBool("Run", true);

            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraMovement>().sensivity * Time.deltaTime);

            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

        }
        else
        {
            dogAnimation.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !healthComponent.IsDead)
        {
            dogAnimation.SetTrigger("Attack1");
            //StartCoroutine("TakeDamage");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !healthComponent.IsDead)
        {
            dogAnimation.SetTrigger("Defend");
        }

    }
    
    private void AplyDamageForAll()
    {
        List<HealthComponent> healthComponents = GetAllHealthComponents();
        for (int i = 0; i < healthComponents.Count; i++)
        {
            healthComponents[i].TakeDamage(attackComponent);
        }
    }
    private List<HealthComponent> GetAllHealthComponents()
    {
        List<HealthComponent> list = collidersInRadius.GetAllColliders();
        return list;
    }

}

