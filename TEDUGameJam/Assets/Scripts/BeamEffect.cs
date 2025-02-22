using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamEffect : MonoBehaviour
{
    public GameObject beamEffectPrefab;
    // Işın efektinin zemine göre yukarıda oluşturulacağı offset (örneğin 5 birim yukarı)
    public float beamYOffset = 5f;
    // Işın efektinin oluşturulma aralığı (örneğin her 1 saniyede bir)
    public float dropInterval = 1.0f;
    // Zemin ortasından ne kadar sağa-sola rastgele yer değiştireceğini belirleyen değer
    public float randomRangeX = 3f;
    // Coroutine referansı
    private Coroutine beamCoroutine;

    // Oyuncu trigger alanına girdiğinde beam düşürmeye başlar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (beamCoroutine == null)
            {
                beamCoroutine = StartCoroutine(DropBeamRepeatedly());
            }
        }
    }
    // Oyuncu trigger alanından çıktığında beam düşürme durur
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (beamCoroutine != null)
            {
                StopCoroutine(beamCoroutine);
                beamCoroutine = null;
            }
        }
    }
    // Coroutine: Belirlenen aralıklarla, zeminin ortasından rastgele bir x offset ile beam efekt prefab'ını oluşturur.
    private IEnumerator DropBeamRepeatedly()
    {
        while (true)
        {
            // Rastgele x offset değeri hesapla
            float randomOffsetX = Random.Range(-randomRangeX, randomRangeX);
            // Spawn pozisyonunu, zemin pozisyonuna ekleyerek ayarla
            Vector3 spawnPosition = new Vector3(transform.position.x + randomOffsetX, transform.position.y + beamYOffset, transform.position.z);
            GameObject beam = Instantiate(beamEffectPrefab, spawnPosition, Quaternion.identity);
            // Prefab ölçeğini korumak için
            beam.transform.localScale = beamEffectPrefab.transform.localScale;
            yield return new WaitForSeconds(dropInterval);
        }
    }
}
