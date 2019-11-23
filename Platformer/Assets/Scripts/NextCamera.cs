using UnityEngine;

public class NextCamera : MonoBehaviour
{
    [SerializeField] GameObject nextCamera;
    [SerializeField] Vector3 trans;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextCamera.transform.position += trans;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            this.gameObject.GetComponent<NextCamera>().enabled = false;
        }

    }
}
