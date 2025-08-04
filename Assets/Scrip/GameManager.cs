using UnityEngine;
using TMPro; // Nếu bạn sử dụng TextMeshPro cho UI Text

public class GameManager : MonoBehaviour
{
    // Một singleton để truy cập dễ dàng từ các script khác
    public static GameManager instance;

    public TextMeshProUGUI goldText; // Kéo và thả UI Text vào đây
    private int currentGold = 0;

    void Awake()
    {
        // Đảm bảo chỉ có một thể hiện của GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Giữ đối tượng này không bị hủy khi chuyển màn hình
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Phương thức để thêm vàng
    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldUI();
    }

    // Phương thức để cập nhật giao diện
    void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = currentGold.ToString();
        }
    }
}
