using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public UnityEvent damageEvent;
    public UnityEvent deathEvent;
    void Update()
    {
        if (health <= 0)
            Die();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        damageEvent?.Invoke();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        deathEvent?.Invoke();
    }
}
