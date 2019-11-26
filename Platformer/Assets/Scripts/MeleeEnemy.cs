using UnityEngine;
public class MeleeEnemy : EnemyBase
{
    [SerializeField] float range;
    [SerializeField] float rateOfFire;
    RaycastHit2D hit;
    Animator anim;
    Rigidbody2D rb;


    new void Start()
    {
        base.Start();
        speed = 1;
        isRight = true;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    new void Update()
    {
        base.Update();
        CheckRayCast();
        Move();

    }


    protected override void CheckRayCast()
    {
        timer += Time.deltaTime;
        hit = (Physics2D.Raycast(transform.position, transform.right, range, 1 << LayerMask.NameToLayer("Hitable")));
        if (hit.collider != null)
        {

            if (hit.collider.tag.Equals("Wall"))
            {

                transform.Rotate(0, 180, 0);
                isRight = !isRight;
            }
            if (hit.collider.tag.Equals("Player"))
            {
                Attack();
            }


        }


    }
    protected override void Move()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime);

        anim.SetBool("isMoving", Mathf.Abs( rb.velocity.x) > 0);


    }

    protected override void Attack()
    {
        if (timer >= rateOfFire)
        {
            anim.SetTrigger("Attack");
            timer = 0;
            if (hit.collider.GetComponent<PlayerHealth>() != null)
                hit.collider.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * range);
    }

    protected override void Animate()
    {
        base.Animate();
        anim.SetTrigger("isHit");

    }
}
