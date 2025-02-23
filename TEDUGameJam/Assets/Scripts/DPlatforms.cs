using System.Collections;
using UnityEngine;

public class DPlatforms : MonoBehaviour
{
    public float visibleDuration = 3f; // Platform ne kadar süre görünecek?
    public float hiddenDuration = 2f;  // Platform ne kadar süre kaybolacak?

    private Collider2D platformCollider; // Çarpışma için collider referansı
    private SpriteRenderer platformRenderer; // Görsellik için renderer referansı

    void Start()
    {
        platformCollider = GetComponent<Collider2D>(); // Collider bileşenini al
        platformRenderer = GetComponent<SpriteRenderer>(); // Renderer bileşenini al

        StartCoroutine(PlatformCycle()); // Platformun kaybolup geri gelmesini başlat
    }
    private IEnumerator PlatformCycle()
    {
        while (true) // Sonsuz döngü
        {
            // Platformu görünür yap
            platformRenderer.enabled = true;
            platformCollider.enabled = true;
            yield return new WaitForSeconds(visibleDuration); // Belirli süre bekle

            // Platformu gizle
            platformRenderer.enabled = false;
            platformCollider.enabled = false;
            yield return new WaitForSeconds(hiddenDuration); // Belirli süre bekle
        }
    }
}