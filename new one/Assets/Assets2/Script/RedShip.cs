using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;

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

    int points;


    //for events
    RedShipPointsAddedEvent redShipPointsAddedEvent = new RedShipPointsAddedEvent();

    private void OnEnable()
    {
        points = ConfigurationUtils.RedShipPoints;
        health = ConfigurationUtils.RedEnemyHealth;
    }

    void Start()
    {

        


        planet = GameObject.FindGameObjectWithTag("planet").transform;
        rb = gameObject.GetComponent<Rigidbody>();
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        
        
        

        planetPrefab = GameObject.FindWithTag("planet");

        EventManager.AddRedShipPointsAddedEventInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        float amplitude = 40.0f;
        float frequency = 0.5f;
        newPosition.x += Mathf.Sin(Time.time * frequency) * 1 / amplitude;
        transform.position = newPosition;

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
            AudioManager.Play(ClipName.EnemyExplode);
            redShipPointsAddedEvent.Invoke(points);
            EventManager.RemoveRedShipPointsAddedEventInvoker(this);
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

    public void AddRedShipPointsAddedEventListener(UnityAction<int> listener)
    {
        redShipPointsAddedEvent.AddListener(listener);
    }

}
