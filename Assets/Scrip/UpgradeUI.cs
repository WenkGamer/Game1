using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Button btUpgrade;
    public Button btSell;
    private UpgradeTower tower;

     public void Setup(UpgradeTower tower)
    {
        this.tower = tower;
        btUpgrade.onClick.AddListener(() => tower.Upgrade());
        btSell.onClick.AddListener(() => tower.Sell());
    }
}
