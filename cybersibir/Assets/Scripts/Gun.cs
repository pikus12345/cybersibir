using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gun;
    public float aimSpeed;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
