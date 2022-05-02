using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Vector2 offset;
    public bool block;
    
    void Update()
    {
        if (!block)
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        else
            transform.position = new Vector2(0,-1000);
    }
}
