using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public Transform pistolSlide;
    private Vector3 pistolNormalLocalPos;
    Gun gun;
    public GameObject gunShotPrefab;

    private void Start()
    {
        pistolNormalLocalPos = pistolSlide.localPosition;
        gun = FindObjectOfType<Gun>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
        else
        {
            if (pistolSlide.position != pistolNormalLocalPos)
            {
                pistolSlide.transform.localPosition = Vector3.Lerp(pistolSlide.localPosition, pistolNormalLocalPos, Time.deltaTime * 10);
                gun.offset = Vector2.Lerp(gun.offset, Vector2.zero, Time.deltaTime * 6);
            }
        }

    }
    public void Shot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Instantiate(gunShotPrefab, bulletSpawn);
        pistolSlide.Translate(-0.2f,0,0);

        gun.offset += (-(Vector2)gun.transform.right) / 2 + (-(Vector2)gun.transform.up) / 2;

    }
}
