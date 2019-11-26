using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerHealth>() != null)
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<EnemyBase>() != null)
                collision.gameObject.GetComponent<EnemyBase>().TakeDamage(20);
        }
    }
}
