using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    protected float health=100;
    protected float currentHealth;
    protected bool isDead;
    protected bool isRight;
    protected float speed = 1;
    protected float timer;

    protected abstract void CheckRayCast();
    protected abstract void Move();
    protected virtual void Attack() { }

    protected void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        Animate();
    }

    protected void Update()
    {
        isDead = currentHealth <= 0 ? true : false;
        if (isDead)
            Destroy(gameObject);
    }

    virtual protected void Animate() { }
        
}
