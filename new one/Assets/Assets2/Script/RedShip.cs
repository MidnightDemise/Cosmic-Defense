using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RedShip: MonoBehaviour
{
    // Start is called before the first frame update
    private Transform planet;
    private Rigidbody rb;
    public float RedMoveSpeed = 5f;
    public float health;
    public GameObject gravityBall;
    private EnemyManager enemyManager;
    private bool isStunned;
    private GameObject planetPrefab;

    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("planet").transform;
        rb = gameObject.GetComponent<Rigidbody>();
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        
        
        health = ConfigurationUtils.RedEnemyHealth;

        planetPrefab = GameObject.FindWithTag("planet");
    }

    // Update is called once per frame
    void Update()
    {

        if (!GravityBallScript.gameObjects.Contains(gameObject) && !isStunned && planetPrefab != null)
        {

            Vector3 dir = planet.position - transform.position;

            rb.velocity = dir.normalized * 2f;

        }
   


        if(health < 0)
        {
            //Destroy(gameObject);
        }

    }



    public void SetRedShipHealth(int newHealth)
    {
        health = newHealth;
    }

    public void DamageShip(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            enemyManager.enemies.Remove(gameObject);

            ReturnToPool();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Node")

        {
            planetPrefab.GetComponent<SwipeEarth>().Damage(health);
            enemyManager.enemies.Remove(gameObject);

            ReturnToPool();
        }

       
    }

    public void setStun(bool value)
    {
        isStunned = value;
    }

    public bool getStun()
    {
        return isStunned;
    }

    public void ReturnToPool()
    {
        if (enemyManager != null)
        {
            AudioManager.Play(ClipName.EnemyExplode);

            enemyManager.ReturnShipToPool(gameObject);
        }
    }

}
