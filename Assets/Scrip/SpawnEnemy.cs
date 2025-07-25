using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;
    public float spawnDelay = 1f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 10f, spawnDelay);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab);
        Instantiate(enemy2Prefab);
    }
}
