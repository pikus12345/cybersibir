using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float moveSpeed;
    private void FixedUpdate()
    {
        transform.Translate(moveSpeed*Time.fixedDeltaTime,0,0);
    }
}
