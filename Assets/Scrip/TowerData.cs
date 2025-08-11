using UnityEngine;

[System.Serializable]
public class TowerLevel
{
    public GameObject towerPrefabs;
    [SerializeField] private int cost;
}

[CreateAssetMenu(fileName = "TowerData", menuName = "GunController/TowerData")]
public class TowerData : MonoBehaviour
{
    public TowerLevel[] levels;
}
