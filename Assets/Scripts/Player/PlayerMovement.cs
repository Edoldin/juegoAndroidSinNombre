using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    private CharacterController controller; 
    private PlayerInputs      input;
    private PlayerInput       playerInput;

    private Vector2           movement;
    private Vector2           aim;

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
            Vector3 point = ray.GetPoint(distance);
            transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
        }
    }
}
