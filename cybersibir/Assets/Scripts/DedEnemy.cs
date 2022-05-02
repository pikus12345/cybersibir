using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedEnemy : MonoBehaviour
{
    Animator animator;
    private bool isLiving = true;
    private Transform player;
    public float moveSpeed;
    public float viewRadius;
    [SerializeField]private float distToPlayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (isLiving)
            GoToPlayer();
    }
    private void GoToPlayer()
    {
        distToPlayer = Vector2.Distance(player.position, transform.position);
        if (distToPlayer < 2.2f)
        {
            Punch();
        }
        else if (distToPlayer < viewRadius)
        {
            if (player.position.x > transform.position.x)
                Go(1);
            else
                Go(-1);
            animator.SetInteger("Animation", 1);
        }
        else
            animator.SetInteger("Animation", 0);
    }
    private void Go(float hor)
    {
        transform.Translate(Mathf.Abs(hor) * Time.deltaTime * moveSpeed, 0, 0);
        if (hor < 0)
            transform.rotation = Quaternion.Euler(0,180,0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Death();
        }
    }
    public void Punch()
    {
        animator.SetInteger("Animation", 2);
        Debug.Log("Punch!");
    }
    public void Hurt()
    {
        if (distToPlayer < 2.2f)
        {
            player.GetComponent<PlayerLife>().Death();
        }
    }
    public void Death()
    {
        isLiving = false;
        animator.SetInteger("Animation", 3);
        Destroy(GetComponent<Collider2D>());
        Destroy(GetComponent<Rigidbody2D>());
    }
}
