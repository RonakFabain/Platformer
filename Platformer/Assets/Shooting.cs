using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    protected float speed = 1;
    protected float timer;
    [SerializeField] protected float rateOfFire;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPos;

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
		
	}

     void Shoot()
    {
        if (timer >= rateOfFire)
        {
            timer = 0;
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
}
