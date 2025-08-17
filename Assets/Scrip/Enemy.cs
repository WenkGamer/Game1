
using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    private EnemyStats stats;

    private float health;
    private float dameAmount;
    private float speed;
    private int goldValue;
    public GameObject goldPrefab;

    public Transform pathParent;
    private List<Transform> waypoints = new List<Transform>();
    private int currentIndex = 0;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 direction;
    public bool useX = true;
    public bool useY = true;

    [HideInInspector] public Spawner spawner;

    public void Init(EnemyStats enemyStats)
    {
        this.stats = enemyStats;

        health = stats.Health;
        dameAmount = stats.Damage;
        speed = stats.Speed;
        goldValue = stats.GoldDrop;

        waypoints.Clear();
        foreach(Transform points in pathParent)
        {
            waypoints.Add(points);
        }
        if(waypoints.Count > 0)
            transform.position = waypoints[0].position;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
            Destroy(gameObject);
        }

        
    }

    public void FixedUpdate()
    {
        if(animator != null)
        {
            if(useX)
                animator.SetFloat("X", direction.x);
            if (useY)
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
        spawner.enemyAlive--;
        if (goldPrefab != null && goldValue > 0)
        {
            GameObject gold = Instantiate(goldPrefab, transform.position, Quaternion.identity);
            GoldItems goldItems = gold.GetComponent<GoldItems>();
            if(goldItems != null)
            {
                goldItems.SetGold(goldValue);
            }
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