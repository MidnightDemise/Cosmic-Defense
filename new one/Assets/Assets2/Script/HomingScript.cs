using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HomingScript : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public float rotationSpeed = 5f;
    public float blastRadius = 5f;
    public Transform planet;
    private EnemyManager enemyManager;
    private GameObject explosionGameObject;
    private GameObject missile;
    private Vector3 shootpoint;
    float timer = 0;
    public bool isMissileDestroyed;
    public bool isRotating;
    
    bool setTarget = false;

    public int missileDamage;

    void Start()
    {
        missileDamage = ConfigurationUtils.MissileDamage;
        
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        rb = gameObject.GetComponentInChildren<Rigidbody>();
        planet = GameObject.Find("Earth").transform;
        explosionGameObject = GameObject.Find("ExplosionBase");

    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
        Debug.DrawRay(transform.position, -transform.right);

        foreach (GameObject e in enemyManager.enemies)
        {
            if(e != null)
            {
                if (Vector3.Distance(transform.position, e.transform.position) < 4f)
                {
                    Vector3 directionToTarget = e.transform.position - transform.position;
                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, transform.up);

                    rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 4 * rotationSpeed * Time.deltaTime));
                    setTarget = true;
                    rb.velocity = speed * transform.forward;


                }
            }
            
               

        }

        if (!setTarget)
        {
            transform.RotateAround(planet.position, Vector3.forward, 45 * Time.deltaTime);
        }

    }

    public void LaunchMissileAgain(GameObject prefab)
    {
      
            missile = prefab;
        isMissileDestroyed = false;

    }

    public void LaunchMissilePosition(Vector3 newpos)
    {
        shootpoint = newpos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="GreenShip" || other.gameObject.tag == "YellowShip" || other.gameObject.tag =="RedShip" ||
           other.gameObject.tag == "ArmyBoss" || other.gameObject.tag == "LaserBoss" || other.gameObject.tag == "FishBoss")
        {
            explosionGameObject.transform.position = other.gameObject.transform.position;
            isMissileDestroyed = true;

            Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
            ParticleSystem particleEffect = explosionGameObject.GetComponent<ParticleSystem>();
            particleEffect.Play();
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "GreenShip")
                {
                    AudioManager.Play(ClipName.EnemyExplode);
                    collider.GetComponent<GreenSip>().DamageShip(missileDamage);
                 //   enemyManager.enemies.Remove(collider.gameObject);
                   // Destroy(collider.gameObject);

                    setTarget = false;

                }
                
                if(collider.tag == "YellowShip")
                {
                    AudioManager.Play(ClipName.EnemyExplode);
                    collider.GetComponent<yelloShip>().DamageShip(missileDamage);

                }

                if (collider.tag == "RedShip")
                {
                    AudioManager.Play(ClipName.EnemyExplode);
                    collider.GetComponent<RedShip>().DamageShip(missileDamage);

                }
                if(collider.tag == "ArmyBoss")
                {
                    AudioManager.Play(ClipName.EnemyExplode);
                    collider.GetComponent<Boss1Script>().TakeDamage(missileDamage);
                }
                if(collider.tag == "LaserBoss")
                {
                    AudioManager.Play(ClipName.EnemyExplode);
                    collider.GetComponent<LaserBossScript>().TakeDamage(missileDamage);
                }
                if(collider.tag == "FishBoss")
                {
                    AudioManager.Play(ClipName.EnemyExplode);
                    collider.GetComponent<ElectricBossScript>().TakeDamage(missileDamage);
                }

                if (collider.tag == "Missile")
                {
                    setTarget = false;
                }
            }

            Destroy(gameObject);

        }
    }

    

    public void setInitialRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
    public bool getStatusMissle()
    {
        return isMissileDestroyed;
    }

    public void setStatusMissile(bool value)
    {
        isMissileDestroyed = value;
    }
}
