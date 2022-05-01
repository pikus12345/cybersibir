using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform target;
    private Vector3 vec;
    public float coefficent;
    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        vec = Vector3.Lerp(target.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Time.fixedDeltaTime * coefficent);
        transform.position = vec + new Vector3(0,0,-10);
    }
}
