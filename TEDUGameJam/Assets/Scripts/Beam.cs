using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public string groundTag = "Ground";

    // Eğer beam efektiniz Rigidbody2D kullanıyorsa OnCollisionEnter2D kullanılabilir.
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(groundTag))
        {
            Destroy(gameObject);
        }
    }*/
    // Eğer beam efektiniz collider'ı trigger olarak ayarlanmışsa OnTriggerEnter2D kullanın.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(groundTag))
        {
            Destroy(gameObject);
        }
    }
}
