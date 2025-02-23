using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VoidDeath : MonoBehaviour
{
    public float fallThreshold = -10f; // Karakter bu yükseklikten aşağı düşerse ölecek
    public GameObject gameOverScreen; // Game Over ekranı UI paneli

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Debug.Log("☠️ Oyuncu haritadan düştü!");
            ShowGameOverScreen(); // Ölüm ekranını aç
        }
    }

    void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Game Over ekranını aç
            Time.timeScale = 0f; // Oyunu durdur
        }
        else
        {

        }
    }
}
