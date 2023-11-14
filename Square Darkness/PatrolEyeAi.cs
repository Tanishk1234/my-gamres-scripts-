using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEyeAi : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2.0f;
    public float rotationSpeed = 2.0f;
    public float sightRange = 5.0f;
    public float shootRange = 3.0f;
    public float shootCooldown = 2.0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Light spotLight;

    private int currentPatrolPointIndex;
    private Transform player;
    private bool canShoot = true;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        currentPatrolPointIndex = 0;
        StartCoroutine(Patrol());
    }

    private void Update()
    {
        // Check if player is in sight range
        if (Vector2.Distance(transform.position, player.position) <= sightRange)
        {
            // Rotate towards the player
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);

            // Check if player is in shooting range
            if (Vector2.Distance(transform.position, player.position) <= shootRange)
            {
                if (canShoot)
                {
                    Shoot();
                    canShoot = false;
                    StartCoroutine(ShootCooldown());
                }
            }
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            Transform target = patrolPoints[currentPatrolPointIndex];
            while (Vector2.Distance(transform.position, target.position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                yield return null;
            }

            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
            target = patrolPoints[currentPatrolPointIndex];
            yield return null;
        }
    }
}
