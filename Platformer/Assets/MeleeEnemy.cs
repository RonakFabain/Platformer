using UnityEngine;
public class MeleeEnemy : EnemyBase
{
    [SerializeField] float range;
    [SerializeField] float rateOfFire;
    RaycastHit2D hit;


    void Start()
    {
        speed = 1;
        isRight = true;
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
                Debug.Log("HIT");
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
   

    }

    protected override void Attack()
    {
        if (timer >= rateOfFire)
        {
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
}
