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
        if (currentHealth <= 0) return; // Eğer zaten ölü ise işlemi iptal et

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true); // Ölüm animasyonunu tetikle
        gOScreen.SetActive(true); // Game Over ekranını aç
        StartCoroutine(ShowGameOverScreen()); // Game Over ekranını açan coroutine çalıştır
        Destroy(this.gameObject); // Karakteri 1.5 saniye sonra yok et
    }

    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(1.5f); // Ölüm animasyonu oynasın diye 1.5 saniye bekle
        FindObjectOfType<GameOverScreen>().ShowGameOverScreen(); // Game Over ekranını aç
    }
}
