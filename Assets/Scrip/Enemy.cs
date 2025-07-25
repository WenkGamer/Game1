using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int currentIndex = 0;
    public int healt = 3;


    void Start()
    {
        transform.position = Path.waypoints[0];
    }

    void Update()
    {
        if (currentIndex >= Path.waypoints.Count) return;

        Vector3 target = Path.waypoints[currentIndex];
        Vector3 dir = target - transform.position;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            healt--;
            
        }
        if (healt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
