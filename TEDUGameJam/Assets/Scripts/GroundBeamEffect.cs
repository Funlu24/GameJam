using UnityEngine;

public class GroundBeamEffect : MonoBehaviour
{
    // Işın efekt prefab'ını Inspector üzerinden atayın.
    public GameObject beamEffectPrefab;
    // Işın efektinin zemine göre yukarıda oluşturulacağı offset (örneğin 5 birim yukarı)
    public float beamYOffset = 5f;

    // Oluşturulan ışın efektinin referansı
    private GameObject activeBeamEffect;

    // Oyuncu, zeminin trigger alanına girdiğinde ışın efektini oluştur.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && beamEffectPrefab != null && activeBeamEffect == null)
        {
            Debug.Log("Player triggera girdi, ışın efekt oluşturuluyor.");
            // Zemin pozisyonuna göre ışın efektinin spawn pozisyonunu ayarla.
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + beamYOffset, transform.position.z);
            // Işın efektini world space'de oluşturuyoruz (parent olarak eklemiyoruz).
            activeBeamEffect = Instantiate(beamEffectPrefab, spawnPosition, Quaternion.identity);
            // Işın efektinin orijinal ölçeğini koruması için.
            activeBeamEffect.transform.localScale = beamEffectPrefab.transform.localScale;
        }
    }

    // Oyuncu, zeminin trigger alanından çıktığında ışın efektini yok et.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && activeBeamEffect != null)
        {
            Debug.Log("Player triggerdan çıktı, ışın efekt yok ediliyor.");
            Destroy(activeBeamEffect);
        }
    }
}
