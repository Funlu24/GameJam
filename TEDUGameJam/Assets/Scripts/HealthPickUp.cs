using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healAmount = 20; // Can artırma miktarı

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Eğer karakterin tag'ı "Player" ise
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                if (playerHealth.currentHealth < playerHealth.maxHealth) // Eğer canı full değilse
                {
                    playerHealth.Heal(healAmount); // Can artır
                    Destroy(gameObject); // Objeyi yok et
                }
                else
                {

                }
            }
        }
    }
}
