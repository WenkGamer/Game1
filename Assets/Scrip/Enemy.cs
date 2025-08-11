
using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [Tooltip("Luong sat thuong cua quai gay ra khi va cham.")]
    public float dameAmount = 20f;

    public float speed = 2f;
    public float health = 3;
    public Transform pathParent;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 direction;
    private List<Transform> waypoints = new List<Transform>();
    private int currentIndex = 0;

    public int goldValue = 10;
    public GameObject goldPrefab;

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


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (goldPrefab != null)
        {
            Instantiate(goldPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("House")) { 
        Househealth houseHeath =other.GetComponent<Househealth>();
        if (houseHeath != null) 
        {
            houseHeath.TeakDamage1(dameAmount);
            Destroy(gameObject);    
        }
    }
    
        
    }
}