using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed = 1;

    void Update()
    {
        transform.localPosition += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerHealth>() != null)
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);

            gameObject.SetActive(false);

        }


    }
}
