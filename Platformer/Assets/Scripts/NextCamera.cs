using UnityEngine;

public class NextCamera : MonoBehaviour
{
    [SerializeField] GameObject nextCamera;
    [SerializeField] Vector3 trans;
    PlayerSpawner playerSpawner;
    private void Start()
    {
        playerSpawner = FindObjectOfType<PlayerSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextCamera.transform.position += trans;

           //Add offset to player if wanted
            this.gameObject.GetComponent<NextCamera>().enabled = false;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            this.gameObject.GetComponent<NextCamera>().enabled = false;
            playerSpawner.NextSpawnPoint();
        }
    }

  
}
