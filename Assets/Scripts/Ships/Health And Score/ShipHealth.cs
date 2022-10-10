using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public HealthBar healthBar;
    public UnityEvent damageEvent;
    public UnityEvent deathEvent;

    private Animator animator;
    void Update()
    {
        if (health <= 0)
            Die();
        
        animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(int damage)
    {
        float floatHealth;

        health -= damage;
        floatHealth = (float) health;
        damageEvent?.Invoke();

        if(gameObject.activeInHierarchy)
            animator.SetFloat("Health Percent", floatHealth/maxHealth);
        
        Debug.Log(floatHealth/maxHealth);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        healthBar.gameObject.SetActive(false);
        deathEvent?.Invoke();
    }
}
