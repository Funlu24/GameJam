using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public string groundTag = "Ground";
    public int damageAmount = 10; // Işının vereceği hasar miktarı
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer ışın karaktere çarparsa hasar ver
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Işın karaktere çarptı! Hasar: " + damageAmount);
            }
            Destroy(gameObject); // Işın karaktere çarpınca yok olsun
        }
        // Eğer ışın zemine çarparsa yok et
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
