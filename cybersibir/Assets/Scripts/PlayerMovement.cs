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
    public float slideForce;
    private CapsuleCollider2D capsuleCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
        Gun gun = FindObjectOfType<Gun>();
        if (Input.GetMouseButton(1))
        {
            animator.SetInteger("Animation", 4);
            speed = 0;
            gun.block = true;
            return;
            //ÁËÎÊÈÐÓÅÒ ÎÑÒÀËÜÍÎÅ ÄÂÈÆÅÍÈÅ
        }
        else
            gun.block = false;

        if (Input.GetKey(KeyCode.LeftShift))
            speed = movespeed * 65;
        else
            speed = movespeed * 50;
        if (hor > 0)
            //right
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (hor < 0)
            //left
            transform.rotation = Quaternion.Euler(0, 180, 0);
        if (canJump)
        {
            if ((Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftControl)) & hor != 0 & Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(transform.right * slideForce);
            }
            if ((Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftControl)) & hor != 0 & Input.GetKey(KeyCode.LeftShift))
            {
                //SLIDE
                animator.SetInteger("Animation", 3);
                capsuleCollider.offset = new Vector2(-0.18f, 0.15f);
                capsuleCollider.size = new Vector2(0.9f, 0.16f);
                capsuleCollider.direction = CapsuleDirection2D.Horizontal;
                speed = 0;
                canJump = false;
            }
            else
            {
                capsuleCollider.offset = new Vector2(0,0.41f);
                capsuleCollider.size = new Vector2(0.11f,0.65f);
                capsuleCollider.direction = CapsuleDirection2D.Vertical;
                if (hor != 0)
                    //RUN
                    animator.SetInteger("Animation", 1);
                else
                    //IDLE
                    animator.SetInteger("Animation", 0);
            }
        }
        //JUMP
        if (Input.GetKeyDown(KeyCode.Space) & canJump)
           rb.AddForce(new Vector2(0, jumpForce * 1000));
        if(!canJump & speed != 0)
            animator.SetInteger("Animation", 2);


    }
    private void FixedUpdate()
    {
        hor = Input.GetAxisRaw("Horizontal");
        transform.Translate(speed*Time.fixedDeltaTime/1000*Mathf.Abs(hor),0,0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EnemyBullet"))
        {
            GetComponent<PlayerLife>().Death(collision.collider.GetComponent<Bullet>().xSource);
        }
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
