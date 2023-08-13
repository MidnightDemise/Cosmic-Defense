using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class yelloShip : MonoBehaviour
{
    // Start is called before the first frame update

    public float health;
    public float yellowMoveSpeed = 3f;
    private Transform planet;
    private Rigidbody rb;
    public GameObject gravityBall;
    private EnemyManager enemyManager;
    private bool isStunned;

    void Start()
    {
        planet = GameObject.FindWithTag("planet").transform;
        rb = gameObject.GetComponent<Rigidbody>();
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        health = ConfigurationUtils.YellowEnemyHealth;

    }

    // Update is called once per frame
    void Update()
    {

        if (!GravityBallScript.gameObjects.Contains(gameObject))
        {

            Vector3 dir = planet.position - transform.position;

            rb.velocity = dir.normalized * 2f;
            
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
        

    }


    public void setYellowShipHealth(int newhealth)
    {
        health = newhealth;
    }


    public void DamageShip(float damage)
    {
        health -= damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            enemyManager.enemies.Remove(gameObject);
            Destroy(gameObject,0.1f);
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


}

