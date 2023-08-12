using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class GreenSip : MonoBehaviour
{

    public float greenMoveSpeed = 5f;
    private float health = 50;
    private Transform Target;
    private Rigidbody rb;
    public GameObject gravityBall;
    public static Vector3  originalVelocity;
    private bool isStunned;

    private EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Target = GameObject.FindGameObjectWithTag("planet").transform;
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GravityBallScript.gameObjects.Contains(gameObject))
        {

            Vector3 dir = Target.position - transform.position;

            rb.velocity = dir.normalized * 2f;

            originalVelocity = rb.velocity;
        }


        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }


    public void SetGreenShipHealth(float newHealth)
    {
        health = newHealth;
    }

    public void DamageShip(float damage)
    {
        health -= damage;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Node"))
        {
            Destroy(gameObject);
        }
    }
   // private void OnCollisionEnter(Collision collision)
    //{
       // if(collision.gameObject.tag == "Enemy")
        //{
          //  Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
         //   rb.velocity = Vector3.zero;
           // rb.AddForce(Vector3.up * 500f, ForceMode.Acceleration);
            //GravityBallScript.gameObjects.Add(collision.gameObject);
       // }
    //}


    public void setStun(bool value)
    {
        isStunned = value;
    }

    public bool getStun()
    {
        return isStunned;
    }


}
