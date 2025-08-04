
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int currentIndex = 0;
    public int healt = 3;

  //  public int goldValue = 10;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 direction;
    public Transform target;

    public GameObject goldPrefab;

    void Start()
    {
        transform.position = Path.waypoints[0];
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (currentIndex >= Path.waypoints.Count) return;

        Vector3 target = Path.waypoints[currentIndex];
        Vector3 dir = target - transform.position;
        direction = dir.normalized;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentIndex++;
        }
        if (currentIndex >= Path.waypoints.Count)
        {
            
            // Enemy đã đến waypoint cuối
            Destroy(gameObject);
            
        }

        
    }

    public void FixedUpdate()
    {
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }

    //  private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        healt--;

    //    }



    public void TakeDamage(int damage)
    {
        healt -= damage;

        if (healt <= 0)
        {
            Die();
        }





        //if (healt <= 0)
        //{
        // //   Destroy(gameObject);
        //    Die();
        //}
    }
    
     public void Die()
    {
        // Tạo ra vật phẩm vàng tại vị trí của quái vật
        if (goldPrefab != null)
        {
            Instantiate(goldPrefab, transform.position, Quaternion.identity);
        }

        // Hủy đối tượng quái vật sau khi đã tạo vàng
        Destroy(gameObject);
    }
    //void TakeDamage(int damage)
    //{
    //    healt -= damage;
    //    Debug.Log("Enemy took " + damage + " damage. Remaining HP: " + healt);

    //    if (healt <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
