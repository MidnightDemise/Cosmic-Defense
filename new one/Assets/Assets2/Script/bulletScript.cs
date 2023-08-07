using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bulletPoint;
    private Rigidbody rb;
    private EnemyManager enemyManager;
    private Vector3 initialDirection; // New variable to store the initial direction

    public float bulletSpeed = 10f;

    void Start()
    {
        bulletPoint = GameObject.FindGameObjectWithTag("shootpoint").transform;
        rb = gameObject.GetComponent<Rigidbody>();
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
    }

    public void setInitialDirection(Vector3 dir)
    {
        initialDirection = dir.normalized;
    }
    // Update is called once per frame
    void Update()
    {

        transform.position +=  initialDirection * 10f * Time.deltaTime;
        

        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            enemyManager.enemies.Remove(collision.gameObject);
            LaserTowerScript.EnemyRanges.Remove(collision.gameObject.transform);            
        }
    }

}
