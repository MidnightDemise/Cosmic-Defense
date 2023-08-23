using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;

public class yelloShip : MonoBehaviour
{
    // Start is called before the first frame update

    public float health;
    public float yellowMoveSpeed = 3f;
    private Transform planet;
    private GameObject planetPrefab;
    private Rigidbody rb;
    public GameObject gravityBall;
    private EnemyManager enemyManager;
    private bool isStunned;

    int points;

    //for events
    YellowShipPointsAddedEvent yellowShipPointsAddedEvent = new YellowShipPointsAddedEvent();


    private void OnEnable()
    {
        points = ConfigurationUtils.YellowShipPoints;
        health = ConfigurationUtils.YellowEnemyHealth;

    }

    void Start()
    {
        planet = GameObject.FindWithTag("planet").transform;

        rb = gameObject.GetComponent<Rigidbody>();
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        
        

        planetPrefab = GameObject.FindWithTag("planet");

        EventManager.AddYellowShipPointsAddedEventInvoker(this);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        float amplitude = 45.0f;  
        float frequency = 0.5f;  
        newPosition.x += Mathf.Sin(Time.time * frequency) * 1/amplitude;
        transform.position = newPosition;

        if (!GravityBallScript.gameObjects.Contains(gameObject) && planetPrefab != null)
        {

            Vector3 dir = planet.position - transform.position;

            rb.velocity = dir.normalized * 2f;
            
        }

        if(health <= 0)
        {
            //Destroy(gameObject);
        }
        

    }


    public void setYellowShipHealth(int newhealth)
    {
        health = newhealth;
    }


    public void DamageShip(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            AudioManager.Play(ClipName.EnemyExplode);
            yellowShipPointsAddedEvent.Invoke(points);
            EventManager.RemoveYellowShipPointsAddedEventInvoker(this);
            enemyManager.enemies.Remove(gameObject);
            ReturnToPool();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Node" || other.CompareTag("planet"))


            {
                planetPrefab.GetComponent<SwipeEarth>().Damage(health);
            enemyManager.enemies.Remove(gameObject);

            AudioManager.Play(ClipName.EnemyExplode);
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
            enemyManager.ReturnShipToPool(gameObject);
        }
    }

    public void AddYellowShipPointsAddedEventListener(UnityAction<int> listener)
    {
        yellowShipPointsAddedEvent.AddListener(listener);
    }

}

