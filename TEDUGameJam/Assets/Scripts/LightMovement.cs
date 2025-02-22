using System.Collections;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    public Transform target;
    // Takip hızı
    public float speed = 5f;
    // Takip sırasında karakterle istenilen minimum mesafe (örneğin 2 birim)
    public float followDistance = 2f;
    // Karakterle temas gerçekleşince true olur
    private bool canFollow = false;

    void Update()
    {
        if (canFollow && target != null)
        {

            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            float distance = Vector3.Distance(transform.position, targetPosition);
            if(distance > followDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform == target)
        {
            canFollow = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == target)
        {
            canFollow = true;
        }
    }
    
}

