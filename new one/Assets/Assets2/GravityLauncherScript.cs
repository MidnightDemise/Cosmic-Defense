using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class GravityLauncherScript : MonoBehaviour
{
    float reloadTimer;
    float waitTimer = 0f;
    public Transform shootpoint;
    public GameObject gravityBall;
    public static bool startMoving;
    // Start is called before the first frame update
    private EnemyManager enemyManager;
    private GameObject temp;
    Vector3 dir;
    private bool stun;
    public float currentStunTimer;
    void Start()
    {
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentStunTimer);

        if (isStunned())
        {
            return;
        }

        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemyManager.enemies)
        {
            if(enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }

            }


        }
           
        
            if(closestEnemy != null & closestDistance < 10f)
            {
                dir = closestEnemy.transform.position - transform.position;

                if (reloadTimer > 2.5f)
                {
                    AudioManager.Play(ClipName.GravityLauncherShot);
                    temp = Instantiate(gravityBall, shootpoint.position, Quaternion.identity);
                    temp.GetComponent<GravityBallScript>().setInitialDirection(dir);
                    reloadTimer = 0f;
                }
                else
                {
                    reloadTimer += Time.deltaTime;
                }

            }
        

        

    

        
    }

    public bool ShouldMove()
    {
        return startMoving ;
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
