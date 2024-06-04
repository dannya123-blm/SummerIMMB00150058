using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] keyPrefabs; // Array to hold different key prefabs
    public int numberOfKeys = 3; // Number of keys to spawn
    public Vector3 spawnArea; // Area in which to spawn keys

    void Start()
    {
        SpawnKeys();
    }

    void SpawnKeys()
    {
        for (int i = 0; i < numberOfKeys; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // Select a random key prefab from the array
            GameObject keyPrefab = keyPrefabs[Random.Range(0, keyPrefabs.Length)];

            Instantiate(keyPrefab, randomPosition, Quaternion.identity);
        }
    }
}
