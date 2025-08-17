using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    private Transform target;
    private Rigidbody2D rb;
    private float dameBullet;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void SetDamage(float _damage)
    {
        dameBullet = _damage;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(dameBullet);
            Destroy(gameObject);
        }
    }
}
