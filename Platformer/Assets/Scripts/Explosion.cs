using UnityEngine;
using System;
using System.Collections;

public class Explosion : MonoBehaviour
{

    [SerializeField] float decayTime = 3;
    [SerializeField] float force = 5;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    Collider2D playerCollision;
    

    private void OnEnable()
    {
        playerCollision = GameObject.Find("Player").GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        Invoke("Destroy", decayTime);
        rb.AddForce(transform.right * 100 * force);
        Physics2D.IgnoreCollision(playerCollision, circleCollider, true);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
    }
    //TODO Throwing
    //Fix UI
    // Mobile Movement?
    //2nd Level
    //Animation Coding
    //Level Polish- Colliders bounds etc

}
