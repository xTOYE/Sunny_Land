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
    public float portalDistance = 1f; //distance player needs to be to use portal

    private CharacterController2D controller;
    private Transform currentPortal; //referece to current Portal

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    public void OnDrawGizmos()
    {
        // trigger if player is in radius of portal trigger
        if (currentPortal != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(currentPortal.position, portalDistance);
        }
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

        if (currentPortal != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                float distance = Vector2.Distance(transform.position, currentPortal.position);
                if (distance < portalDistance)
                {
                    currentPortal.SendMessage("Interact");
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //detect hitting items
        if (col.gameObject.tag == "Item")
        {
            //add 1 to score - gamemanager
            GameManager.Instance.AddScore(1);
            //play chime sound - requires audio source
            //destroy item
            Destroy(col.gameObject);
        }
        //detect hitting items
        if (col.gameObject.tag == "Portal")
        {
            currentPortal = col.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //detect hitting items
        if (col.CompareTag("Portal"))
        {
            currentPortal = null;
        }
    }
}
