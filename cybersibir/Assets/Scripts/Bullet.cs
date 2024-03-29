using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public GameObject particlePrefab;
    public GameObject bloodSplash;

    public float xSource;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = transform.right * Time.fixedDeltaTime * moveSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Player"))
        {
            Instantiate(bloodSplash, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(particlePrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

}
