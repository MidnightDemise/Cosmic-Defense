using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GreenSip : MonoBehaviour
{

    public float greenMoveSpeed = 5f;
    public float health;
    private Transform Target;
    private Rigidbody rb;
    public GameObject gravityBall;
    public static Vector3  originalVelocity;
    private bool isStunned;

    private GameObject planetPrefab;

    private EnemyManager enemyManager;


    // for events 
    GreenShipPointsAddedEvent greenShipPointsAddedEvent = new GreenShipPointsAddedEvent();

    // for scoring 
    int points; 

    // Start is called before the first frame update
    void Start()
    {
        points = ConfigurationUtils.GreenShipPoints;

        health = ConfigurationUtils.GreenEnemyHealth;
        rb = gameObject.GetComponent<Rigidbody>();
        Target = GameObject.FindGameObjectWithTag("planet").transform;
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();

        planetPrefab = GameObject.FindWithTag("planet");

        EventManager.AddGreenShipPointsAddedEventInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GravityBallScript.gameObjects.Contains(gameObject) && planetPrefab != null)
        {

            Vector3 dir = Target.position - transform.position;

            rb.velocity = dir.normalized * 2f;

            originalVelocity = rb.velocity;
        }


        if (health <= 0)
        {
            //Destroy(gameObject);
        }

    }


    public void SetGreenShipHealth(float newHealth)
    {
        health = newHealth;
    }

    public void DamageShip(float damage,List<GameObject> linerenderers)
    {
        health -= damage;
        if (health <= 0)
        {
            
            AudioManager.Play(ClipName.EnemyExplode);
            
            
            foreach (GameObject line in linerenderers)
            {
                if (line.GetComponent<LineRenderer>().enabled)
                {
                    line.GetComponent<LineRenderer>().enabled = false;
                }
            }
            
            enemyManager.enemies.Remove(gameObject);
            ReturnToPool();
        }
    }

    public void DamageShip(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            AudioManager.Play(ClipName.EnemyExplode);
            greenShipPointsAddedEvent.Invoke(points);
            EventManager.RemoveGreenShipPointsAddedEventInvoker(this);
            AudioManager.Play(ClipName.EnemyExplode);
            enemyManager.enemies.Remove(gameObject);
            ReturnToPool();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Node") || other.CompareTag("planet"))
        {
            planetPrefab.GetComponent<SwipeEarth>().Damage(health);
            enemyManager.enemies.Remove(gameObject);
            ReturnToPool();
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

    public void ReturnToPool()
    {
        if (enemyManager != null)
        {
            enemyManager.ReturnShipToPool(gameObject);
        }
    }

    public void AddGreenShipPointsAddedEventListener(UnityAction<int> listener)
    {
        greenShipPointsAddedEvent.AddListener(listener);
    }

}
