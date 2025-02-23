using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Eğer karakter objeye değerse
        {
            FindObjectOfType<WinScreen>().ShowWinScreen(); // Win ekranını aç
            Destroy(gameObject); // Kazanma objesini yok et
        }
    }
}
