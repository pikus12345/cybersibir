using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
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
}
