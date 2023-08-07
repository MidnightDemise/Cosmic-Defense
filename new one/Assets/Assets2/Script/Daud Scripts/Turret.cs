using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform[] targets = new Transform[4];

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;
    public LineRenderer laserPrefab;
    public Transform firePoint;

    private LineRenderer[] activeLasers = new LineRenderer[4];

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTargets", 0f, 0.5f);
    }

    void UpdateTargets()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        for (int i = 0; i < 4; i++)
        {
            float minDistance = Mathf.Infinity;
            Transform nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy <= range && distanceToEnemy < minDistance && !ArrayContainsTransform(targets, enemy.transform))
                {
                    minDistance = distanceToEnemy;
                    nearestEnemy = enemy.transform;
                }
            }

            targets[i] = nearestEnemy;
        }
    }

    bool ArrayContainsTransform(Transform[] array, Transform target)
    {
        foreach (Transform t in array)
        {
            if (t == target)
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (targets[0] == null)
        {
            // If no targets, stop firing lasers and clear active lasers
            StopFiringLasers();
            return;
        }

        // Target lock on
    
        if (fireCountDown <= 0f)
        {
            FireLasers();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    void FireLasers()
    {
        for (int i = 0; i < 4; i++)
        {
            if (targets[i] != null)
            {
                if (activeLasers[i] == null)
                {
                    // If no active laser for this target, create a new one
                    activeLasers[i] = Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
                }

                // Update the laser's endpoint to stay locked onto the target
                activeLasers[i].SetPosition(0, firePoint.position);
                activeLasers[i].SetPosition(1, targets[i].position);
            }
            else
            {
                // If no target for this laser, disable it
                if (activeLasers[i] != null)
                {
                    Destroy(activeLasers[i].gameObject);
                }
            }
        }
    }

    void StopFiringLasers()
    {
        // Disable all active lasers when there is no target
        for (int i = 0; i < 4; i++)
        {
            if (activeLasers[i] != null)
            {
                Destroy(activeLasers[i].gameObject);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
