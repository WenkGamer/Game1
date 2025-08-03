using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    [Header("Cai dat mau")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Cai dat thanh mau")]
    public GameObject healthBarPrefab;
    private Image healthBarForeground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        GameObject healtBarGO= Instantiate(healthBarPrefab,transform.position,Quaternion.identity,transform);

        healthBarForeground= healtBarGO.transform.Find("healthBarBackground/healthBarForeground").GetComponent<Image>();
    }

    public void TakeDamage(int damage) // can sua
    {
        currentHealth -=damage ;
        UpdateHealthBar();


        if (currentHealth <= 0)
        {
            Die();
        } }

    // Update is called once per frame
    void Update()
    {
        
    }
        void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBarForeground.fillAmount= healthPercentage;
    }
    void Die()
    {
        Debug.Log(gameObject.name+"die");
        Destroy(gameObject);
    }
}
