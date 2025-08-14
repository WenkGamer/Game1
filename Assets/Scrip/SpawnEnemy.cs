using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform path1;
    public Transform path2;
    public GameObject WinGame;

    public int waveCount = 0;
    public int soloPathWaves = 3;

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
        while (waveCount < 10)
        {
            waveCount++;
            int enemyCount = DemEnemy(waveCount);

            for(int i = 0; i< enemyCount; i++)
            {
                SpawnEnemy();
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
        return 19;
        

    }

    public void SpawnEnemy()
    {
        GameObject enemyObj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemyAlive++;
        enemy.spawner = this;
        if(waveCount < soloPathWaves)
        {
            enemy.pathParent = path1;
        }
        else
        {
            enemy.pathParent = Random.value < 0.5f ? path1 : path2;
        }
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
