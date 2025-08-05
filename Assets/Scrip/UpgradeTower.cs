using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject upgradeUI;
    public GameObject towerlv2;
    private GameObject currentUI;
    private Transform baseTower;
    public GameObject basesell;

    public void Init(Transform canvas)
    {
        baseTower = canvas;
    }

    private void OnMouseDown()
    {
        if(currentUI == null)
        {
            if (upgradeUI == null || baseTower == null)
            {
                Debug.LogWarning("UpgradeUI hoặc baseTower bị null");
                return;
            }
            currentUI = Instantiate(upgradeUI, baseTower);
            UpgradeUI ui = currentUI.GetComponent<UpgradeUI>();
            if (ui != null)
                ui.Setup(this);
            else
                Debug.LogWarning("Không tìm thấy UpgradeUI script trong prefab");
        }
    }

    public void Upgrade()
    {
        if(towerlv2 != null)
        {
            GameObject newTower = Instantiate(towerlv2, transform.position, Quaternion.identity);
            UpgradeTower uiscript = newTower.GetComponent<UpgradeTower>();
            if (uiscript != null)
                uiscript.Init(baseTower);

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
