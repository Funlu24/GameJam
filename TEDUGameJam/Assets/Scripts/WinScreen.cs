using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen; // Win ekranı (Inspector'dan atanmalı)
    void Start()
    {
        winScreen.SetActive(false); // Oyunun başında Win ekranını kapat
    }
    public void ShowWinScreen()
    {
        winScreen.SetActive(true); // Win ekranını aç
        Time.timeScale = 0f; // Oyunu durdur
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu tekrar hızlandır
        SceneManager.LoadScene(1); // Mevcut sahneyi yeniden yükle
    }
    public void QuitGame()
    {
        Application.Quit(); // Oyunu kapat
    }
}
