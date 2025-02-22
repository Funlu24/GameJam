using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject gOScreen;
    public FillStatusBar fillStatusBar;
    public float currentHealth;
    public float maxHealth = 100f;
    public Animator animator;
    public Rigidbody2D rb;

    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
       public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        
        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HealthPickup")) 
        {
            Heal(50); 
            Destroy(other.gameObject); 
        }
        if (other.CompareTag("Deadly"))
        {
            Die();
            Debug.Log("Deadly");
        }
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0) return; // E�er zaten �l� ise i�lemi iptal et

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        animator.SetBool("isDead", true);
        gOScreen.SetActive(true);
        Destroy(this.gameObject, 1.5f);
        //Time.timeScale = 0f;
    }
}
