using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f; // player speed

    public Rigidbody2D rb; // player rigidbody component
    public Animator animator; // handles all animations for player, even based on inputs or variables

    Vector2 velocity; // x and y speed for movement

    // Update is called once per frame
    void Update() {
        // for input
        velocity.x = Input.GetAxisRaw("Horizontal"); // -1 to 1 based on input, L or R
        velocity.y = Input.GetAxisRaw("Vertical");   // -1 to 1 based on input, Up or Down

        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        animator.SetFloat("Speed", velocity.sqrMagnitude);
    }

    // ilke Update, but in a fixed time interval (50/sec usually)
    void FixedUpdate(){
        //for movement
        rb.MovePosition(rb.position + velocity*speed*Time.fixedDeltaTime); // Time.fixedDeltaTime makes the movement consistent
    }
}
