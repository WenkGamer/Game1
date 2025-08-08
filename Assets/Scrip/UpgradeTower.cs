using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject upgradeUI;
    public GameObject towerlvup;
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
            currentUI = Instantiate(upgradeUI, baseTower);
            UpgradeUI ui = currentUI.GetComponent<UpgradeUI>();
            if (ui != null)
                ui.Setup(this);
        }
    }

    public void Upgrade()
    {
        if(towerlvup != null)
        {
            GameObject newTower = Instantiate(towerlvup, transform.position, Quaternion.identity);
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
