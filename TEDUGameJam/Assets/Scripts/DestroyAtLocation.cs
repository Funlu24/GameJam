using UnityEngine;

public class DestroyAtLocation : MonoBehaviour
{
    public Transform destroyPoint;
    public float thresholdDistance = 0.5f;

    void Update()
    {
        if (destroyPoint != null)
        {
            float distance = Vector3.Distance(transform.position, destroyPoint.position);
            if (distance <= thresholdDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
