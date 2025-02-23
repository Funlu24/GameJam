using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreen; // Game Over UI Panel

    void Start()
    {
        gameOverScreen.SetActive(false); // Oyun başlarken Game Over ekranı kapalı olacak
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true); // Game Over ekranını aç
        Time.timeScale = 0f; // Oyunu durdur (isteğe bağlı)
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu tekrar hızlandır
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden yükle
    }

    public void QuitGame()
    {
        Application.Quit(); // Oyunu kapat (Sadece Build alınmış oyunlarda çalışır)
    }
}
