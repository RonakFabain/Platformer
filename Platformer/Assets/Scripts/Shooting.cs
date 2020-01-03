using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float timer;
    [SerializeField] float rateOfFire;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPos;

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        if (timer >= rateOfFire)
        {
            timer = 0;
            ObjectPoolManager.Instance.SpawnFromPool("Explosion", bulletPos.position, transform.rotation);
        }
    }
}
