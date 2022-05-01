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
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = movespeed * 65;
        else
            speed = movespeed * 50;
        if (hor != 0)
            animator.SetInteger("Animation", 1);
        else
            animator.SetInteger("Animation", 0);
        if (hor > 0)
            transform.rotation = Quaternion.Euler(0,0,0);
        else if(hor < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetKeyDown(KeyCode.Space) & canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce * 1000));
        }
    }
    private void FixedUpdate()
    {
        hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(transform.right * speed * Mathf.Abs(hor));
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
