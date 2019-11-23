using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    protected float health;
    protected float currentHealth;
    protected bool isDead;
    protected bool isRight;
    protected float speed = 1;
    protected float timer;

    protected abstract void CheckRayCast();
    protected abstract void Move();
    protected virtual void Attack() { }

    protected void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
    }

    protected void Update()
    {
        isDead = currentHealth <= 0 ? true : false;
    }

}
