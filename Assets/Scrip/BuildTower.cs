    using UnityEngine;
    using UnityEngine.EventSystems;

    public class BuildTower : MonoBehaviour
    {
        public Transform spawn;
        public GameObject towerSelectionUI;
        public TowerData tower1Data;
        public TowerData tower2Data;

        private GameObject currentUI;
        private static GameObject activeUI;
        private static BuildTower activeBase;

        private void OnMouseDown()
        {
            if(activeUI != null && activeUI != currentUI)
            {
                Destroy(activeUI);
                activeUI = null;
            }
            if(currentUI == null)
            {
                currentUI = Instantiate(towerSelectionUI, spawn);
                currentUI.transform.localPosition = Vector3.zero;
                BuildCanvas ui = currentUI.GetComponent<BuildCanvas>();
                if (ui != null)
                    ui.Setup(this, tower1Data, tower2Data);
                activeUI = currentUI;
                activeBase = this;
            }
        }

        private void Update()
        {
            if(activeUI != null && Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mouseWorld.z = 0;
                    if(Vector2.Distance(mouseWorld, activeBase.transform.position) > 0.5f)
                    {
                        Destroy(activeUI);
                        activeUI = null;
                        activeBase = null;
                    }
                }
            }
        }

        public void BuildTowercl(TowerData towerData)
        {
            GameObject tower = Instantiate(towerData.levels[0].towerPrefabs, transform.position, Quaternion.identity);
            UpgradeTower upgradescript = tower.GetComponent<UpgradeTower>();
            if (upgradescript != null)
            {
                upgradescript.Init(spawn, towerData, towerData.levels[0].Cost, 0);
            }
            Destroy(currentUI);
            currentUI = null;
            activeUI = null;
            activeBase = null;
            Destroy(gameObject);
        }

    }
