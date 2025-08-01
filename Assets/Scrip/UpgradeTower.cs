using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject upgradeUI;
    public GameObject tower1lv2;
    private GameObject currentUI;
    private Transform baseTower;

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
        if(tower1lv2 != null)
        {
            GameObject newTower = Instantiate(tower1lv2, transform.position, Quaternion.identity);
            UpgradeTower uiscript = newTower.GetComponent<UpgradeTower>();
            if (uiscript != null)
                uiscript.Init(baseTower);

            Destroy(currentUI);
            Destroy(gameObject);
        }
    }

    public void Sell()
    {
        Destroy(currentUI);
        Destroy(gameObject);
    }
}
