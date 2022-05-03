using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Org1 : MonoBehaviour
{
    Animator animator;
    private Transform player;
    public float moveSpeed;
    public float viewRadius;
    [SerializeField] private float distToPlayer;
    public float attackDistance;
    private BossHP bosshp;
    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bosshp = GetComponent<BossHP>();
    }
    private void Update()
    {
        GoToPlayer();
    }
    private void GoToPlayer()
    {
        if (bosshp.bolvanchiks.Count > 0)
        {
            animator.SetInteger("Animation", 0);
            return;
        } 
        distToPlayer = Vector2.Distance(player.position, transform.position);
        if (distToPlayer < attackDistance)
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
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            animator.SetInteger("Animation", 3);
        }
    }
    public void Punch()
    {
        animator.SetInteger("Animation", 2);
    }
    public void Hurt()
    {
        if (distToPlayer < attackDistance)
        {
            player.GetComponent<PlayerLife>().Death(transform.position.x);
        }
    }
    
}
