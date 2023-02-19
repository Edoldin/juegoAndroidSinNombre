using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private int   life        = 100;

    [SerializeField] private float bulletspeed     = 10f;
    [SerializeField] private int   damage          = 20;
    [SerializeField] private float bulletDelay     = 0.2f;
                     private float auxBulletDelay  = 0f;

    private CharacterController controller; 
    private PlayerInputs        input;
    private PlayerInput         playerInput;

    private Vector2             movement;
    private Vector2             aim;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = new PlayerInputs();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        Input_Control();
        Movement();
        Rotation();
        Shoot();
    }

    void Input_Control()
    {
        movement = input.Input.Movement.ReadValue<Vector2>();
        aim = input.Input.Aim.ReadValue<Vector2>();
    }

    void Movement()
    {
        Vector3 move = new Vector3(movement.x, 0f,movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
        
    }

    void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(aim);
        Plane grounPlane = new Plane(Vector3.up, Vector3.zero);
        float distance;

        if(grounPlane.Raycast(ray, out distance))
        {
            aim.x = ray.GetPoint(distance).x;
            aim.y = ray.GetPoint(distance).z;
            transform.LookAt(new Vector3(aim.x, transform.position.y, aim.y));
        }
    }


    void Shoot()
    {
        if (input.Input.Shoot.ReadValue<float>() > 0 && auxBulletDelay <= 0)
        {
            auxBulletDelay = bulletDelay;
            GameObject newBullet = BulletPool.instance.GetPooledBullet();
            if (newBullet == null)
                return;
            newBullet.transform.position = transform.position;
            newBullet.transform.LookAt(new Vector3(aim.x, transform.GetChild(1).transform.position.y, aim.y));
            newBullet.transform.position = transform.GetChild(1).transform.position;
            newBullet.SetActive(true);
            newBullet.GetComponent<Bullet>().speed = bulletspeed;
            newBullet.GetComponent<Bullet>().damage = damage;
        }
        auxBulletDelay -= Time.deltaTime;
    }

    public void GetDamage(int damage)
    {
        if (life - damage > 0)
            life -= damage;
        else
        {
            life = 0;
            Dead();
        }
    }

    private void Dead()
    {
        Debug.Log("You are dead");
    }
}
