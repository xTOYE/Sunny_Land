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
        * Input.GetAxis - builds up speed
        * Input.GetAxisRaw - instant speed
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        //detect hitting items
        if(col.gameObject.tag == "Item")
        {
            //add 1 to score - gamemanager
            GameManager.Instance.AddScore(1);
            //play chime sound - requires audio source
            //destroy item
            Destroy(col.gameObject);
        }
    }
}
