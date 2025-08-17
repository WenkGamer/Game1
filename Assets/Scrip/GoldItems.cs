using System.Collections;
using UnityEngine;

public class GoldItems : MonoBehaviour
{
    private int goldValue;
    public float lifetime = 0.2f;

    public void SetGold(int value)
    {
        goldValue = value;
    }
    void Start()
    {
     StartCoroutine(CollectAndDestroy());
    }

    IEnumerator CollectAndDestroy()
    {
      yield return new WaitForSeconds(lifetime);
      if (GameManager.instance != null && goldValue > 0)
     {
            GameManager.instance.AddGold(goldValue);
        }

        Destroy(gameObject);
    }

}
