using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 2f;
    public int currentIndex = 0;
    private int healt = 3;

    private Rigidbody2D rd;
    private Animator animator;
    private Vector2 direction;

    void Start()
    {
        transform.position = Path2.waypoints2[0];
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (currentIndex >= Path2.waypoints2.Count) return;

        Vector3 target = Path2.waypoints2[currentIndex];
        Vector3 dir = target - transform.position;
        direction = dir.normalized;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentIndex++;
        }
        if (currentIndex >= Path2.waypoints2.Count)
        {

            // Enemy đã đến waypoint cuối
            Destroy(gameObject);
            /*healt--;
            if (healt == 0)
            {
                Time.timeScale = 0;
            }// hoặc làm gì đó*/
        }


    }
    public void FixedUpdate()
    {
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
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
