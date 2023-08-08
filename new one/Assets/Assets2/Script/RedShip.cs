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
    public int health;
    public GameObject gravityBall;
    private EnemyManager enemyManager;

    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("planet").transform;
        rb = gameObject.GetComponent<Rigidbody>();
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!GravityBallScript.gameObjects.Contains(gameObject))
        {

            Vector3 dir = planet.position - transform.position;

            rb.velocity = dir.normalized * 2f;

        }
   




    }



    public void SetRedShipHealth(int newHealth)
    {
        health = newHealth;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Node")

        {
            Destroy(gameObject,0.1f);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * 500f, ForceMode.Acceleration);
            GravityBallScript.gameObjects.Add(collision.gameObject);
        }
    }

}