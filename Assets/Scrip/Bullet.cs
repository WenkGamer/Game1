using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private Rigidbody2D rb;

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
            // TODO: Gây sát thương tại đây
            Destroy(gameObject);
        }
    }
}
