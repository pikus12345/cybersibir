using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldat : MonoBehaviour
{
    Animator animator;
    private bool isLiving = true;
    private Transform player;
    public float moveSpeed;
    public float viewRadius;
    [SerializeField] private float distToPlayer;
    public float attackDistance;
    public Transform gun;
    public GameObject bulletPrefab;
    public GameObject bulletParticlesPrefab;
    private float delay;
    public Transform dulo;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isLiving)
            GoToPlayer();
    }
    private void GoToPlayer()
    {
        distToPlayer = Vector2.Distance(player.position, transform.position);
        if (distToPlayer < attackDistance)
        {
            Fire();
        }
        else if (distToPlayer < viewRadius)
        {
            if (player.position.x > transform.position.x)
                Go(1);
            else
                Go(-1);
            animator.SetInteger("Animation", 1);
            //gun.position = transform.position + new Vector3(0, 10, 0);
        }
        else
            animator.SetInteger("Animation", 0);
            //gun.position = transform.position;
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
            Death();
        }
    }
   public void Fire()
   {
        gun.transform.position = player.position + new Vector3(0, 10, 0);
        if (delay > 0.5f)
        {
            animator.SetInteger("Animation", 2);
            GameObject _bull = Instantiate(bulletPrefab, dulo.position + new Vector3(0, 0, -10), dulo.rotation);
            _bull.GetComponent<Bullet>().xSource = dulo.position.x;
            Instantiate(bulletParticlesPrefab, dulo.position, dulo.rotation);
            delay = 0;
        }
        delay += Time.deltaTime;
        
   }
    public void Death()
    {
        isLiving = false;
        animator.SetInteger("Animation", 3);
        Destroy(GetComponent<Collider2D>());
        Destroy(GetComponent<Rigidbody2D>());
        BossHP bossHP = FindObjectOfType<BossHP>();
        if (bossHP != null)
        {
            bossHP.bolvanchiks.Remove(gameObject);
        }
    }
}
