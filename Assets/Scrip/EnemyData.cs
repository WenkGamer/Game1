using UnityEngine;

[System.Serializable]
public class EnemyStats
{
    public GameObject enemyPrefab;
    [SerializeField] private float health = 10f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private int damage = 10;
    [SerializeField] private int goldDrop = 10;

    public GameObject EnemyPrefab => enemyPrefab;
    public float Health => health;
    public float Speed => speed;
    public int Damage => damage;
    public int GoldDrop => goldDrop;
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    public EnemyStats[] enemies;
}
