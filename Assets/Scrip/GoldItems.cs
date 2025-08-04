using System.Collections;
using UnityEngine;

public class GoldItems : MonoBehaviour
{
    public int goldValue = 10;
    public float lifetime = 0.2f;
    void Start()
    {
     StartCoroutine(CollectAndDestroy());

      }

    IEnumerator CollectAndDestroy()
    {
      yield return new WaitForSeconds(lifetime);
      if (GameManager.instance != null)
     {
            GameManager.instance.AddGold(goldValue);
        }

        Destroy(gameObject);
    }

}
