
using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int healt = 3;
    public Transform pathParent;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 direction;
    private List<Transform> waypoints = new List<Transform>();
    private int currentIndex = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        foreach(Transform point in pathParent)
        {
            waypoints.Add(point);
        }
        if(waypoints.Count > 0)
            transform.position = waypoints[0].position;
    }

    void Update()
    {
        if (currentIndex >= waypoints.Count) return;

        Transform target = waypoints[currentIndex];
        Vector3 dir = target.position - transform.position;
        direction = dir.normalized;

        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentIndex++;
        }
        if (currentIndex >= waypoints.Count)
        {
            
            // Enemy đã đến waypoint cuối
            Destroy(gameObject);
            
        }

        
    }

    public void FixedUpdate()
    {
        if(animator != null)
        {
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
        }
    }


    public void TakeDamage(int damage)
    {
        healt -= damage;

        if (healt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
