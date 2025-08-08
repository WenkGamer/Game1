using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Button btUpgrade;
    public Button btSell;
    private UpgradeTower tower;

    [SerializeField] private int upgradecost;

    public void Setup(UpgradeTower tower)
    {
        this.tower = tower;

        if(tower.towerlvup == null)
        {
            btUpgrade.gameObject.SetActive(false);
        }
        else
        {
            btUpgrade.onClick.RemoveAllListeners();
            btUpgrade.onClick.AddListener(() => tower.Upgrade(upgradecost));
        }
        btSell.onClick.RemoveAllListeners();
        btSell.onClick.AddListener(() => tower.Sell());
    }
}
