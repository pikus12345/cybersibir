using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Music"))
            {
                if (obj != gameObject)
                {
                    Destroy(obj);
                }
            }
        }
    }
}
