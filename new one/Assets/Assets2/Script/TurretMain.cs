using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class TurretMain : MonoBehaviour
{
    public Transform target; // Reference to the target prefab
    public GameObject prefabbbb;
    public Transform bulletPoint;
    private EnemyManager enemyManager;
    public float rotationSpeed = 5f;
    private bool stun = false;
    float recoilTimer = 0f;
    public float stunTimer;
    public float currentStunTimer = 0f;
    public GameObject fishBoss;
    Quaternion originalRotation;

    private void Awake()
    {
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        originalRotation = transform.rotation;
    }
    void Update()
    {        //Debug.Log(currentStunTimer);

        if (isStunned())
        {
            return;
        }
        if (enemyManager.enemies.Count == 0)
            return;

        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;



        foreach (GameObject enemy in enemyManager.enemies)
        {
            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }

        }

        if (closestEnemy != null && closestDistance < 8f)
            {
                Vector3 targetDirection = closestEnemy.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                if (recoilTimer > 0.5f)
                {
                    AudioManager.Play(ClipName.BossEnemyShot);
                    GameObject newBullet = Instantiate(prefabbbb, bulletPoint.position, Quaternion.identity);
                    newBullet.GetComponent<bulletScript>().setInitialDirection(transform.forward);
                    newBullet.GetComponent<bulletScript>().setRotation(transform.rotation);
                    recoilTimer = 0f;
                }
                else
                {
                    recoilTimer += Time.deltaTime;
                }
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);
            }
        }
    

    public void setStun(bool value)
    {
        stun = value;
    }

    public bool isStunned()
    {
        return stun;
    }


    public void UpdateStunTimer(float deltaTime)
    {
        currentStunTimer += deltaTime;
    }

    public float GetStunTimer()
    {
        return currentStunTimer;
    }

    public void ResetStunTimer()
    {
        currentStunTimer = 0f;
    }

}

