using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int hp;
    public bool rightSpawn;
    public List<GameObject> bolvanchiks;
    public GameObject bolvanchikPrefab;
    public GameObject boomPrefab;
    public GameObject shield;
    private void Start()
    {
        shield = transform.Find("Shield").gameObject;
    }

    private void Update()
    {
        
        if (hp % 5 == 0)
        {
            
            if (bolvanchiks.Count == 0)
                SpawnBolvanchics();
            if (bolvanchiks.Count > 0)
                hp--;
        }
        if(bolvanchiks.Count == 0)
            shield.SetActive(false);
        else
            shield.SetActive(true);

        if (hp <= 0)
            Death();
    }
    private void SpawnBolvanchics()
    {
        int b;
        if (rightSpawn)
            b = 1;
        else
            b = -1;
        for(int i = 1; i <= 3; i++)
        {
            GameObject bolvan = Instantiate(bolvanchikPrefab, transform.position, Quaternion.identity);
            bolvan.transform.position += new Vector3(b*i*2,0,0);
            bolvanchiks.Add(bolvan);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet") & bolvanchiks.Count == 0)
        {
            hp--;
        }
    }
    public void Death()
    {
        Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
