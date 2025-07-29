using UnityEngine;

public class BuildTower : MonoBehaviour
{
    public Transform spawn;
    public GameObject towerSelectionUI;
    private GameObject currentUI;

    private void OnMouseDown()
    {
        if(currentUI == null)
        {
            //currentUI = Instantiate(towerSelectionUI, transform.position, Quaternion.identity, spawn);
            currentUI = Instantiate(towerSelectionUI, spawn);
            currentUI.transform.localPosition = Vector3.zero;
            BuildCanvas ui = currentUI.GetComponent<BuildCanvas>();
            if (ui != null)
            {
                Debug.Log("Đã gọi UI");
                ui.Setup(this);
            }
            else 
            {
                Debug.LogError("Khing tim thay ui");
            }
        }
    }

    public void BuildTowercl(GameObject towerPrefab)
    {
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        Destroy(currentUI);
        Destroy(gameObject);
    }

}
