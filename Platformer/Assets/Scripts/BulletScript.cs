using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed = 10;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3f && this.gameObject.activeInHierarchy)
        {
            timer = 0;
            Disable();
        }
        transform.localPosition += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerHealth>() != null)
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
            ObjectPoolManager.Instance.SpawnFromPool("Explosion", transform.position, Quaternion.identity);
            gameObject.SetActive(false);


        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<EnemyBase>() != null)
                collision.gameObject.GetComponent<EnemyBase>().TakeDamage(20);
            ObjectPoolManager.Instance.SpawnFromPool("Explosion", transform.position, Quaternion.identity);
            gameObject.SetActive(false);

        }




    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
