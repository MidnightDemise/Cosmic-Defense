using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class GreenSip : MonoBehaviour
{

    public float greenMoveSpeed = 5f;
    public int health;
    private Transform Target;
    private Rigidbody rb;
    public GameObject gravityBall;
    public static Vector3  originalVelocity;

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

        
        

    }


    public void SetGreenShipHealth(int newHealth)
    {
        health = newHealth;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Node")
        {
            Destroy(gameObject,01f);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * 500f, ForceMode.Acceleration);
            GravityBallScript.gameObjects.Add(collision.gameObject);
        }
    }



}
