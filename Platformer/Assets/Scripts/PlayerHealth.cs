using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    float currentHealth;
    bool isDead;
    [HideInInspector]
    public bool isHit;

    private void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        isHit = true;
        Invoke("CanTakeHit", 1);
    }

    void Update()
    {
        isDead = currentHealth <= 0 ? true : false;
        if (isDead)
        {
            ObjectPoolManager.Instance.SpawnFromPool("Explosion", transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void CanTakeHit()
    {
        isHit = false;
    }
}