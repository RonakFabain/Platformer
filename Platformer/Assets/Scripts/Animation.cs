using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    [SerializeField] Animator anim;
    Movement movement;
    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponentInParent<Movement>();
    }


    void Update()
    {
        if (anim != null)
        {
            anim.SetBool("isRunning", Mathf.Abs(movement.x) > 0f);
            anim.SetBool("isJumping", movement.rb.velocity.y > 0);
            anim.SetBool("isFalling", movement.rb.velocity.y < 0);


          

        }

    }
}
