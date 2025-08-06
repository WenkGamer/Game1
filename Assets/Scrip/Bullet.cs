using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private Rigidbody2D rb;
    public int damebullet = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damebullet);  // Gây dame
            }
            //Enemy2 enemy2 = target.GetComponent<Enemy2>();
            //if (enemy != null)
            //{
            //    enemy2.TakeDamage(damebullet);  // Gây dame
            //}

            Destroy(gameObject); // Xoá đạn
        }
    }
    void HitTarget()
    {
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damebullet);
        }
        Destroy(gameObject);
    }

        
}
