using UnityEngine;

public class BuildTower : MonoBehaviour
{
    public Transform spawn;
    public GameObject towerSelectionUI;
    private GameObject currentUI;

    private int costTower1 = 100;
    private int costTower2 = 150;

    private void OnMouseDown()
    {
        if(currentUI == null)
        {
            currentUI = Instantiate(towerSelectionUI, spawn);
            currentUI.transform.localPosition = Vector3.zero;
            BuildCanvas ui = currentUI.GetComponent<BuildCanvas>();
            if (ui != null)
                ui.Setup(this, costTower1, costTower2);
        }
    }

    public void BuildTowercl(GameObject towerPrefab)
    {
        GameObject tower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
        UpgradeTower upgradescript = tower.GetComponent<UpgradeTower>();
        if (upgradescript != null)
        {
            upgradescript.Init(spawn);
        }
        Destroy(currentUI);
        Destroy(gameObject);
    }

}
