using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Hareketin başlayacağı ve biteceği noktalar (Inspector üzerinden atanmalı)
    public Transform pointA;
    public Transform pointB;
    // Platformun hareket hızı
    public float speed = 2f;
    // Şu anda hedeflenen nokta
    private Vector3 target;
    void Start()
    {
        // Başlangıçta platform pointA noktasına doğru hareket edecek.
        target = pointA.position;
    }
    void Update()
    {
        // Platformu, hedef noktaya doğru hareket ettir.
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Platform hedefe yaklaştığında (0.1f mesafe içinde), hedefi değiştir.
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }
}
