using UnityEngine;

[System.Serializable]
public class TowerLevel
{
    public GameObject towerPrefabs;
    [SerializeField] private int cost;
    public int Cost => cost;
}

[CreateAssetMenu(fileName = "TowerData", menuName = "Data/TowerData")]
public class TowerData : ScriptableObject
{
    public TowerLevel[] levels;
}
