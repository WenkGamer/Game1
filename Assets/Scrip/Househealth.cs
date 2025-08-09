using UnityEngine;
using UnityEngine.UI;

public class Househealth : MonoBehaviour
{
    [Tooltip(" Thanh Slider Ui de hien thi mau")]
    public Slider healthBarSlider;

    [Tooltip("Mau toi da cua ngoi nha")]
    public float maxHealth = 100f;

    // Máu hiện tại, sễ được thiết lập khi batws đầu game
    private float currenHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenHealth = maxHealth;
        //UpdateHealthBarUI();

        
    }
    public void TeakDamage(float amount)
    {
        currenHealth -= amount;
        // đảm bảo máu thấp hơn 0\
        if (currenHealth < 0)
        {
            currenHealth = 0;
        }

        Debug.Log($"Ngoi nha da chiu {amount} sat thuong. Mau hien tai:{currenHealth} ");

        // Update is called once per frame
        //void Update()
        //{

    }
}
