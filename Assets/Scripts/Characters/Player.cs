using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    // Member varibles
    public float jumpHeight = 5f;
    public float climbSpeed = 10f;
    public float moveSpeed = 10f;

    private CharacterController2D controller;

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        /*
        * --- Unity Tip ---
        * Input.GetAxis - 
        * Input.GetAxisRaw - 
        */

        // Temp variables
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isJuping = Input.GetButtonDown("Jump");

        if (isJuping)
        {
            controller.Jump(jumpHeight);
        }

        controller.Climb(vertical * climbSpeed);

        controller.Move(horizontal * moveSpeed);
    }
}
