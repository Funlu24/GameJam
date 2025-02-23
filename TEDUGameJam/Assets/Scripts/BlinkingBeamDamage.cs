using System.Collections;
using UnityEngine;

public class BlinkingBeamDamage : MonoBehaviour
{
    public float blinkInterval = 1f; // Işığın yanıp sönme süresi
    public int damageAmount = 10; // Işığın vereceği hasar miktarı
    public float damageCooldown = 0.5f; // Hasar tekrar süresi (0.5 saniyede bir hasar verir)

    public SpriteRenderer beamSprite; // Işığın SpriteRenderer bileşeni
    private bool isBeamOn = true; // Işığın açık olup olmadığını takip eder
    private bool playerInside = false; // Oyuncu ışığın içinde mi?
    private float lastDamageTime; // En son ne zaman hasar alındı?

    void Start()
    {
        if (beamSprite == null)
            beamSprite = GetComponent<SpriteRenderer>();

        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // Işığı aç
            isBeamOn = true;
            if (beamSprite != null)
                beamSprite.enabled = true;
            yield return new WaitForSeconds(blinkInterval / 2f);

            // Işığı kapat
            isBeamOn = false;
            if (beamSprite != null)
                beamSprite.enabled = false;

            // Eğer oyuncu içerdeyse hemen hasar ver
            if (playerInside)
            {
                TryToGiveDamage();
            }

            yield return new WaitForSeconds(blinkInterval / 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            // Eğer ışık kapalıysa hemen hasar ver
            if (!isBeamOn)
            {
                TryToGiveDamage();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

        }
    }

    private void TryToGiveDamage()
    {
        if (!isBeamOn && Time.time - lastDamageTime >= damageCooldown) // Işık kapalıysa ve cooldown geçtiyse
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                    lastDamageTime = Time.time; // Hasar zamanını güncelle
                }
            }
        }
    }
}
