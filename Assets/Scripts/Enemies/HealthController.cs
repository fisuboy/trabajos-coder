using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private GeneralData data;
    [SerializeField] private HealthBar healthBar;
    private Animator anim;
    private int currentHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = data.life;
        healthBar.SetMaxHealth(data.life);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log(currentHealth);
        anim.SetTrigger("TakeDamage");
        if (currentHealth <= 0)
            Die();
    }
    
    private void Die()
    {
        Debug.Log("Enemy died");
        anim.SetBool("isDead", true);
        GetComponent<ScarabEnemy>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }
}
