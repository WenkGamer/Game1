using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildCanvas : MonoBehaviour
{
    private BuildTower spot;

    public GameObject towerPrefab1;
    public GameObject towerPrefab2;

    public Button bttower1;
    public Button bttower2;

    public void Setup(BuildTower spotBuild)
    {
        spot = spotBuild;

        bttower1.onClick.AddListener(() => Build(towerPrefab1));
        bttower2.onClick.AddListener(() => Build(towerPrefab2));
    }

    private void Build(GameObject towerPrefab)
    {
        spot.BuildTowercl(towerPrefab);
        Destroy(gameObject);
    }

}
