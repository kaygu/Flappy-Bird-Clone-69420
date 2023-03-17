using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float jumpSpeed = 7f;
    private const float forwardVelocity = 5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Dirty way to start the game "paused"
        Time.timeScale = 0; 
    }

    private void Update()
    {
        if (BirdLife.isAlive() && Input.GetButtonDown("Jump"))
        {
            if (Time.timeScale == 0)
            {
                // "Unpause" the game
                Time.timeScale = 1;
            }
            rb.velocity = Vector2.up * jumpSpeed;
            //if (rb.velocity.x > jumpSpeed) rb.velocity = Vector2.up * jumpSpeed; // cap maximum velocity
        }

        // Bird roatation
        if (BirdLife.isAlive())
        {
            float angle = Mathf.Atan2(rb.velocity.y, forwardVelocity) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
