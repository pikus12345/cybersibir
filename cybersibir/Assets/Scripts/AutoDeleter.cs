using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeleter : MonoBehaviour
{
    public float deleteTime;
    float timer;
    private void Update()
    {
        if (timer > deleteTime)
            Destroy(gameObject);
        else
            timer += Time.deltaTime;


    }
}
