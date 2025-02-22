using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VoidDeath : MonoBehaviour
{
    public float fallThreshold = -10f;

    void Update()
    {

        if (transform.position.y < fallThreshold)
        {
            Debug.Log("Oyuncu haritadan düştü!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
        }
    }
}
