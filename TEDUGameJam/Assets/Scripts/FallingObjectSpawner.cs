using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public float spawnInterval = 1.0f;
    [SerializeField] public float spawnHeightOffset = 5.0f;

    private bool isSpawning = false;
    private Coroutine spawnCoroutine;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !isSpawning) {
            isSpawning = true;
            spawnCoroutine = StartCoroutine(SpawnObjects());
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isSpawning = false;
            if (spawnCoroutine != null) {
                StopCoroutine(spawnCoroutine);
            }
        }
    }

    private IEnumerator SpawnObjects() {
        while (isSpawning) {
            Vector3 spawnPosition = transform.position + new Vector3(0, spawnHeightOffset, 0);
            Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
