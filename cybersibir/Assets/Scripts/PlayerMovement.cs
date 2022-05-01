using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    private float speed;
    private Rigidbody2D rb;
    private float hor;
    public float jumpForce;
    private bool canJump = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = movespeed * 90;
        else
            speed = movespeed * 50;
        if (Input.GetKeyDown(KeyCode.Space) & canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce * 1000));
        }
    }
    private void FixedUpdate()
    {
        hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(transform.right * speed * hor);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Level"))
            canJump = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Level"))
            canJump = false;
    }
}
