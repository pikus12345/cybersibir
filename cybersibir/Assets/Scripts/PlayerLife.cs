using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    
    public void Death()
    {
        Camera.main.GetComponent<GameManager>().ReloadScene();
    }
}
