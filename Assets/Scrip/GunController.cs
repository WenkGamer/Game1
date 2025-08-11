using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;       // Prefab đạn
    public Transform firePoint;           // Vị trí bắn
    public float fireRate = 1f;           // Số lần bắn mỗi giây
    public float fireRange = 5f;          // Tầm bắn
    public float damage = 3f;

    private float fireCooldown = 0f;
    private Transform target;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        FindTarget();

        if (target != null && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= fireRange)
            {
                shortestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        target = nearestEnemy;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetTarget(target);
            bulletScript.SetDamage(damage);
        }
    }
}
