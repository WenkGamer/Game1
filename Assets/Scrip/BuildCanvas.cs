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

    public void Setup(BuildTower spotBuild, int costtw1, int costtw2)
    {
        spot = spotBuild;

        bttower1.onClick.AddListener(() => Build(towerPrefab1, costtw1));
        bttower2.onClick.AddListener(() => Build(towerPrefab2, costtw2));
    }

    private void Build(GameObject towerPrefab, int cost)
    {
        if (GameManager.instance.SpendGold(cost))
        {
            spot.BuildTowercl(towerPrefab);
            Destroy(gameObject);
        }
    }
}
