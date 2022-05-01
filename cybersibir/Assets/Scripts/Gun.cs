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
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Lerp(
            gun.rotation, Quaternion.Euler(0, 0, rotateZ), Time.fixedDeltaTime*aimSpeed
            );
    }
}
