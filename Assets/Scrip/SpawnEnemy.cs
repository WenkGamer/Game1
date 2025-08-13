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

    private void Start()
    {
        StartCoroutine(SpawnWaves());
       
    }
    private void Update()
    {
        GameWin();
    }
    IEnumerator SpawnWaves()
    {
        while (true)
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
        if(waveCount == 11)
        {
            WinGame.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
