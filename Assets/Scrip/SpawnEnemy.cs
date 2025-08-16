using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy settings")]
    public Transform[] paths;
    public EnemyData[] enemyDatas;

    [Header("Game settings")]
    public GameObject WinGame;
    public int waveCount = 0;
    public int maxWaves = 10;

    public float timebtEnemies = 1f;
    public float timebtWaves = 5f;

    [HideInInspector] public int enemyAlive = 0;
    private bool allWaveDone = false;

    private void Start()
    {
        enemyAlive = 0;
        StartCoroutine(SpawnWaves());
    }
    private void Update()
    {
        GameWin();
    }
    IEnumerator SpawnWaves()
    {
        while (waveCount < maxWaves)
        {
            waveCount++;
            int enemyCount = DemEnemy(waveCount);

            for(int i = 0; i< enemyCount; i++)
            {
                SpawnEnemy(waveCount);
                yield return new WaitForSeconds(timebtEnemies);
            }
            yield return new WaitForSeconds(timebtWaves);
        }
        allWaveDone = true;
    }

    int DemEnemy(int wave)
    {
        if (wave == 1) return 5;
        if (wave == 2) return 7;
        if (wave == 3) return 10;
        if (wave > 3 && wave < 10) return 15;
        return 1;
    }

    public void SpawnEnemy(int currentWave)
    {
        EnemyStats stats;
        if(currentWave <= 2)
        {
            stats = enemyDatas[0].enemies[0];
        }
        else if(currentWave < maxWaves)
        {
            stats = (Random.value < 0.7f ? enemyDatas[0].enemies[0] : enemyDatas[0].enemies[1]);
        }
        else
        {
            stats = enemyDatas[0].enemies[2];
        }

        Transform path = paths[Random.Range(0, paths.Length - 1)];

        GameObject enemyObj = Instantiate(stats.EnemyPrefab, transform.position, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();

        enemyAlive++;
        enemy.spawner = this;
        enemy.pathParent = path;
        enemy.Init(stats);
    }

    public void GameWin()
    {
        if(allWaveDone && enemyAlive == 0)
        {
            WinGame.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
