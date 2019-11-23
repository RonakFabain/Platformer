using UnityEngine;

public class RangedEnemy : EnemyBase
{
    [SerializeField] float range;
    [SerializeField] float rateOfFire;
    RaycastHit2D hit;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletStartPos;
    private Quaternion rotInit;
    
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
        rotInit = transform.rotation;

    }

    protected override void Attack()
    {
        if (timer >= rateOfFire)
        {
            timer = 0;
            // Instantiate(bullet, transform.position, rotInit);
            ObjectPoolManager.Instance.SpawnFromPool("EnemyBullet", transform.position, rotInit);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * range);
    }
}
