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
    public float timer;
    void Start()
    {

        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
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



        if (closestEnemy != null && closestDistance < 5f)
        {
           
            Vector3 dir = closestEnemy.transform.position - shootpoint.position;
            transform.LookAt(closestEnemy.transform);

            if (timer > 2f)
            {
                float halfAngleRad = Mathf.Deg2Rad * 30 * 0.5f;
                Vector3 sideBulletDir1 = Quaternion.AngleAxis(45, transform.right) * dir;
                Vector3 sideBulletDir2 = Quaternion.AngleAxis(-45, transform.right) * dir;

                // Instantiate and set the initial directions for the three bullets
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
}
