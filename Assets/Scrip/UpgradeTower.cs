using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeTower : MonoBehaviour
{
    public GameObject upgradeUI;
    private GameObject currentUI;
    private Transform baseTower;
    public GameObject basesell;
    private static GameObject activeUI;
    private static UpgradeTower activeTower;

    public TowerData towerData;
    [SerializeField] private int currentLevel = 0;
    public int CurrentLevel => currentLevel;

    private int totalSpent = 0;

    public void Init(Transform canvas, TowerData data, int spent = 0, int level = 0)
    {
        baseTower = canvas;
        towerData = data;
        totalSpent = spent;
        currentLevel = level;
    }

    private void OnMouseDown()
    {
        if(activeUI != null && activeUI != currentUI)
        {
            Destroy(activeUI);
            activeUI = null;
        }
        if(currentUI == null)
        {
            currentUI = Instantiate(upgradeUI, baseTower);
            UpgradeUI ui = currentUI.GetComponent<UpgradeUI>();
            if (ui != null)
                ui.Setup(this);
            activeUI = currentUI;
            activeTower = this;
        }
    }

    private void Update()
    {
        if (activeUI != null && Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorld.z = 0;
                if (Vector2.Distance(mouseWorld, activeTower.transform.position) > 0.5f)
                {
                    Destroy(activeUI);
                    activeUI = null;
                    activeTower = null;
                }
            }
        }
    }

    public void Upgrade()
    {
        if (currentLevel < towerData.levels.Length - 1)
        {   
            int cost = towerData.levels[currentLevel + 1].Cost;
            if (GameManager.instance.SpendGold(cost))
            {
                totalSpent += cost;
                GameObject newTower = Instantiate(towerData.levels[currentLevel + 1].towerPrefabs, transform.position, Quaternion.identity);
                UpgradeTower uiscript = newTower.GetComponent<UpgradeTower>();
                if (uiscript != null)
                {
                    uiscript.Init(baseTower, towerData, totalSpent, currentLevel + 1);
                }
                Destroy(currentUI);
                Destroy(gameObject);
            }
        }
    }

    public void Sell()
    {
        int refund = Mathf.FloorToInt(totalSpent * 0.5f);
        GameManager.instance.AddGold(refund);

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
