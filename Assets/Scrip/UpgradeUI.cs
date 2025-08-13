using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public Button btUpgrade;
    public Button btSell;
    private UpgradeTower tower;

    public void Setup(UpgradeTower tower)
    {
        this.tower = tower;

        if(tower.CurrentLevel >= tower.towerData.levels.Length - 1)
        {
            btUpgrade.gameObject.SetActive(false);
        }
        else
        {
            int upgradeCost = tower.towerData.levels[tower.CurrentLevel + 1].Cost;
            btUpgrade.GetComponentInChildren<TextMeshProUGUI>().text = $"Upgrade ({upgradeCost}G)";
            btUpgrade.onClick.RemoveAllListeners();
            btUpgrade.onClick.AddListener(() => tower.Upgrade());
        }
        btSell.onClick.RemoveAllListeners();
        btSell.onClick.AddListener(() => tower.Sell());
    }
}
