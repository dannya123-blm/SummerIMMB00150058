using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject keyPrefab; 
    public int numberOfKeys = 3; 
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
            Instantiate(keyPrefab, randomPosition, Quaternion.identity);
        }
    }
}
