using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static bool isInBossZone;
    private void Update()
    {
        if (transform.position.y < -30)
            Death();
    }
    public void Death(float xSource)
    {
        if (Input.GetMouseButton(1))
        {
            if (transform.rotation.eulerAngles.y == 0 & transform.position.x < xSource)
            {
                Block();
                return;
            }
            if (transform.rotation.eulerAngles.y == 180 & transform.position.x > xSource)
            {
                Block();
                return;
            }
        }
        Camera.main.GetComponent<GameManager>().ReloadScene();
    }
    public void Death()
    {
        Camera.main.GetComponent<GameManager>().ReloadScene();
    }
    public void Block()
    {
        //play sound
        Debug.Log("Block");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("LevelEnd"))
        {
            FindObjectOfType<GameManager>().EndLevel();
        }
        if (collision.attachedRigidbody.CompareTag("BossZone"))
        {
            isInBossZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("BossZone"))
        {
            isInBossZone = false;
        }
    }

}
