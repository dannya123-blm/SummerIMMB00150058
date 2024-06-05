using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; 
    public GameObject[] keyPrefabs; 
    public int numberOfKeys = 3; 
    public int numberOfEnemies = 3; 
    public Vector3 spawnArea; // Area in which to spawn keys and enemies

    private GameObject[] spawnedKeys;
    private GameObject[] spawnedEnemies;

    void Start()
    {
        spawnedKeys = new GameObject[numberOfKeys];
        spawnedEnemies = new GameObject[numberOfEnemies];
        SpawnKeys();
        SpawnEnemies();
        DeactivateSpawnedObjects();
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
            spawnedKeys[i] = Instantiate(keyPrefab, randomPosition, Quaternion.identity);
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // Select a random enemy prefab from the array
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            spawnedEnemies[i] = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }

    void DeactivateSpawnedObjects()
    {
        foreach (GameObject key in spawnedKeys)
        {
            if (key != null)
            {
                key.SetActive(false);
            }
        }

        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                enemy.SetActive(false);
            }
        }
    }

    public void ActivateSpawnedObjects()
    {
        foreach (GameObject key in spawnedKeys)
        {
            if (key != null)
            {
                key.SetActive(true);
            }
        }

        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                enemy.SetActive(true);
            }
        }
    }
}
