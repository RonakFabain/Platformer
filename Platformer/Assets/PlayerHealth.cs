using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    float currentHealth;
    bool isDead;

    private void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
    }

    void Update()
    {
        isDead = currentHealth <= 0 ? true : false;
    }

}