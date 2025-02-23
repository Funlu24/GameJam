using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLights : MonoBehaviour
{
    public int damageAmount = 10; // Hasar miktarı

    // Eğer collider'ınız trigger modundaysa OnTriggerEnter2D kullanın
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Karakter trigger objeye dokundu! Hasar: " + damageAmount);
            }
        }
    }
}
