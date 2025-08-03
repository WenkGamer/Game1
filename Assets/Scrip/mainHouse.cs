using UnityEngine;
using UnityEngine.UI;


public class mainHouse : MonoBehaviour
{
    public Image healthFill;


    int health;
    int maxHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        maxHealth = 100;
        health = maxHealth;

        healthFill.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            if (health > 0)
            {
                health -= 10;
                healthFill.fillAmount = (float)health / (float)maxHealth;
                //GameManager.gm.Showhealth(health,maxHealth);

                if (health <= 0)
                {
                    //  StartCoroutine(DeadDelay());
                }
            }
        }

    }
}
