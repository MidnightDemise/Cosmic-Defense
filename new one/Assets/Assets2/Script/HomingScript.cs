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
    float timer = 0;
    
    bool setTarget = false;

    void Start()
    {
        
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        rb = gameObject.GetComponent<Rigidbody>();
        planet = GameObject.Find("Earth").transform;
        explosionGameObject = GameObject.Find("ExplosionBase");

    }

    void Update()
    {
        foreach(GameObject e in enemyManager.enemies)
        {
            if (Vector3.Distance(transform.position, e.transform.position) < 4f)
            {
                setTarget = true;
                Vector3 directionToTarget = e.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, transform.up);
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));
                rb.velocity = transform.forward * speed;
            }

            
        }

        if (!setTarget)
        {
            transform.RotateAround(planet.position, Vector3.forward, 45 * Time.deltaTime);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            explosionGameObject.transform.position = collisionPoint;
            Destroy(gameObject);
            Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
            ParticleSystem particleEffect = explosionGameObject.GetComponent<ParticleSystem>();
            particleEffect.Play();
            foreach(Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {

                    
                    enemyManager.enemies.Remove(collider.gameObject);
                    Destroy(collider.gameObject,5f);
                    setTarget = false;

                }
                    
            }

        }
    }

}
