using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject upgradeUI;
    private GameObject currentUI;
    private Transform baseTower;
    public GameObject basesell;

    public GameObject[] towerLevels;
    [SerializeField] private int[] costUpgrade;
    [SerializeField] private int currentLevel = 0; 

    public void Init(Transform canvas)
    {
        baseTower = canvas;
    }

    private void OnMouseDown()
    {
        if(currentUI == null)
        {
            currentUI = Instantiate(upgradeUI, baseTower);
            UpgradeUI ui = currentUI.GetComponent<UpgradeUI>();
            if (ui != null)
                ui.Setup(this);
        }
    }

    public void Upgrade(int cost)
    {
        if(currentLevel < towerLevels.Length && GameManager.instance.SpendGold(cost))
        {
                GameObject newTower = Instantiate(towerLevels[currentLevel], transform.position, Quaternion.identity);
                UpgradeTower uiscript = newTower.GetComponent<UpgradeTower>();
                if (uiscript != null)
            {
                uiscript.Init(baseTower);
                currentLevel++;
            }

                Destroy(currentUI);
                Destroy(gameObject);
        }
    }

    public void Sell()
    {
        if(basesell != null)
        {
            GameObject newBase = Instantiate(basesell, transform.position, Quaternion.identity);

            BuildTower buildScript = newBase.GetComponent<BuildTower>();
            if(buildScript != null)
            {
                buildScript.spawn = baseTower;
            }
        }
        Destroy(currentUI);
        Destroy(gameObject);
    }
}
