using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Vector2 offset;
    
    void FixedUpdate()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
}
