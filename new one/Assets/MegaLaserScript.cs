using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MegaLaserScript : MonoBehaviour
{
    // Start is called before the first frame update

    private EnemyManager enemyManager;
    public Transform shootpoint;
    public GameObject plasmaBullet;
    public float timer = 2f;
    public float currentStunTimer = 0f;
    public bool stun;
    void Start()
    {

        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentStunTimer);
        if(isStunned())
        {
            return;
        }
        if (enemyManager.enemies.Count == 0)
            return;

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



        if (closestEnemy != null && closestDistance < 10f)
        {
           
            Vector3 dir = closestEnemy.transform.position - shootpoint.position;
            transform.LookAt(closestEnemy.transform);

            if (timer > 2f)
            {
                float halfAngleRad = Mathf.Deg2Rad * 30 * 0.5f;
                Vector3 sideBulletDir1 = Quaternion.AngleAxis(30, transform.right) * dir;
                Vector3 sideBulletDir2 = Quaternion.AngleAxis(-30, transform.right) * dir;

                // Instantiate and set the initial directions for the three bullets
                AudioManager.Play(ClipName.MegaLaserShot); 
                GameObject plasma = Instantiate(plasmaBullet, shootpoint.position, Quaternion.identity);
                GameObject plasma1 = Instantiate(plasmaBullet, shootpoint.position, Quaternion.identity);
                GameObject plasma2 = Instantiate(plasmaBullet, shootpoint.position, Quaternion.identity);
                plasma.GetComponent<PlasmaBullet>().setInitialDirection(dir);
                plasma1.GetComponent<PlasmaBullet>().setInitialDirection(sideBulletDir1);
                plasma2.GetComponent<PlasmaBullet>().setInitialDirection(sideBulletDir2);
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
           

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
