using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class thirdperson_controls : MonoBehaviour
{
    //input fields
    private Player_Controls player_assets;
    private InputAction move;

    //movement fields
    private Rigidbody rigid_body;
    [SerializeField]
    private float movement_force = 1f;
    [SerializeField]
    private float jump_force = 5f;
    [SerializeField]
    private float max_speed = 5f;
    private Vector3 force_direction = Vector3.zero;
    [SerializeField]
    private Camera player_camera;

    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody>();
        player_assets = new Player_Controls();
    }

    private void OnEnable()
    {
        player_assets.Playermovement.Jump.started += DoJump;
        move = player_assets.Playermovement.Movement;
        player_assets.Playermovement.Enable();
    }

    private void OnDisable()
    {
        player_assets.Playermovement.Jump.started -= DoJump;
        player_assets.Playermovement.Disable();
    }

    private void FixedUpdate()
    {
        force_direction += move.ReadValue<Vector2>().x * GetCameraRight(player_camera) * movement_force;
        force_direction += move.ReadValue<Vector2>().y * GetCameraForward(player_camera) * movement_force;


        rigid_body.AddForce(force_direction, ForceMode.Impulse);
         force_direction = Vector3.zero;

        if (rigid_body.velocity.y < 0)
         {
            rigid_body.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
         } 

         Vector3 horizontal_velocity = rigid_body.velocity;
         //.y = 0;
         if(horizontal_velocity.sqrMagnitude > max_speed * max_speed)
         {
         rigid_body.velocity = horizontal_velocity.normalized * max_speed + Vector3.up * rigid_body.velocity.y;

        LookAt();
        }

    }

    private void LookAt()
    {
        Vector3 direction = rigid_body.velocity;
        direction.y = 0f; 

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            this.rigid_body.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            rigid_body.angularVelocity = Vector3.zero;
        }
    }

    private Vector3 GetCameraRight(Camera player_camera)
    {
        Vector3 right = player_camera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private Vector3 GetCameraForward(Camera player_camera)
    {
        Vector3 forward = player_camera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private void DoJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            force_direction += Vector3.up * jump_force;
        }
    }

    private bool IsGrounded()
    {
         Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
         if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        return true;
         else
         return false;

         

        
    }


}
