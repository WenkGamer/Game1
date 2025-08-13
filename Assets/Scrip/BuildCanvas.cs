using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildCanvas : MonoBehaviour
{
    private BuildTower spot;

    public TowerData towerPrefab1;
    public TowerData towerPrefab2;

    public Button bttower1;
    public Button bttower2;

    public void Setup(BuildTower spotBuild, TowerData t1, TowerData t2)
    {
        spot = spotBuild;
        towerPrefab1 = t1;
        towerPrefab2 = t2;

        bttower1.GetComponentInChildren<TextMeshProUGUI>().text = $"Archer({t1.levels[0].Cost}G)";
        bttower2.GetComponentInChildren<TextMeshProUGUI>().text = $"Bomb({t2.levels[0].Cost}G)";

        bttower1.onClick.AddListener(() => Build(t1));
        bttower2.onClick.AddListener(() => Build(t2));
    }

    private void Build(TowerData towerData)
    {
        if (GameManager.instance.SpendGold(towerData.levels[0].Cost))
        {
            spot.BuildTowercl(towerData);
            Destroy(gameObject);
        }
    }
}
