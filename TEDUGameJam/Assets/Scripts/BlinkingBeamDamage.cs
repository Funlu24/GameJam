using System.Collections;
using UnityEngine;

public class BlinkingBeamDamage : MonoBehaviour
{
    // Işığın tam bir döngü için toplam süresi (örneğin 1 saniye: 0.5 saniye açık, 0.5 saniye kapalı)
    public float blinkInterval = 1f;
    // Işığın kapalıyken (sönük) oyuncuya vereceği hasar miktarı
    public int damageAmount = 10;
    // Işığın görselini temsil eden SpriteRenderer (atama yapmazsanız, script bulunduğu GameObject'ten alınır)
    public SpriteRenderer beamSprite;

    // Işığın şu an açık olup olmadığını takip eder
    private bool isBeamOn = true;

    void Start()
    {
        if (beamSprite == null)
            beamSprite = GetComponent<SpriteRenderer>();

        StartCoroutine(BlinkRoutine());
    }

    // Işığın yanıp sönmesini sağlayan Coroutine
    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // Işığı aç
            isBeamOn = true;
            if (beamSprite != null)
                beamSprite.enabled = true;
            yield return new WaitForSeconds(blinkInterval / 2f);

            // Işığı kapat (sönük hale getir)
            isBeamOn = false;
            if (beamSprite != null)
                beamSprite.enabled = false;
            yield return new WaitForSeconds(blinkInterval / 2f);
        }
    }

    // Oyuncu, ışının trigger alanına girdiğinde
    private void OnTriggerEnter2D(Collider2D other)
    {
        // "Player" tag'ına sahip oyuncu, ışık kapalıyken hasar alacak
        if (other.CompareTag("Player") && !isBeamOn)
        {
            // Örneğin, oyuncunuzun "PlayerHealth" ya da "DamageReceiver" scripti varsa, aşağıdaki gibi hasar verebilirsiniz:
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Işın kapalıyken oyuncuya hasar verildi: " + damageAmount);
            }
            // Eğer oyuncunuz farklı bir hasar scripti kullanıyorsa, uygun referansı alıp hasar verme işlemini düzenleyin.
        }
    }
}
