using UnityEngine;
using TMPro;
public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;
    public TextMeshProUGUI goldText;
    private int currenGold = 0;


    void Awek()
    {
            if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
    }

    public void AddGold(int amount)
    {
        currenGold += amount;
        UpdateGoldUI();
    }
      void UpdateGoldUI()
    {
        goldText.text=currenGold.ToString();
    }
}
