using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bulletPoint;
    private Rigidbody rb;
    private EnemyManager enemyManager;
    private Vector3 initialDirection; // New variable to store the initial direction

    public float bulletSpeed = 10f;

    public int canonDamage;

    void Start()
    {
        canonDamage = ConfigurationUtils.CanonDamage;
        
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


        if(transform.position.y > 50 || transform.position.y  < -50 || transform.position.x > 50 || transform.position.x < -50)
        {
            Destroy(gameObject);
        }
        

        
    }

    public void setRotation(Quaternion rotation)
    {
        transform.rotation = rotation; 
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GreenShip"))
        {
            Destroy(gameObject);
            other.GetComponent<GreenSip>().DamageShip(canonDamage);
        }
        else if(other.CompareTag("YellowShip"))
        {
            Destroy(gameObject);
            other.GetComponent<yelloShip>().DamageShip(canonDamage);
        }
        else if(other.CompareTag("RedShip"))
        {
            Destroy(gameObject);
            other.GetComponent<RedShip>().DamageShip(canonDamage);
        }
        else if (other.CompareTag("ArmyBoss"))
        {
            Destroy(gameObject);
            other.GetComponent<Boss1Script>().TakeDamage(canonDamage);
        }
        else if (other.CompareTag("FishBoss"))
        {
            Destroy(gameObject);
            other.GetComponent<ElectricBossScript>().TakeDamage(canonDamage);
        }
        else if (other.CompareTag("LaserBoss"))
        {
            Destroy(gameObject);
            other.GetComponent<LaserBossScript>().TakeDamage(canonDamage);
        }
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
