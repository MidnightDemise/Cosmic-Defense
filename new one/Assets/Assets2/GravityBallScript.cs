using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBallScript : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 initialDirection;
    private EnemyManager enemyManager;

    private GameObject enemy;    
    public Transform planet;
    private Dictionary<GameObject, Vector3> originalVelocities = new Dictionary<GameObject, Vector3>();

    public static List<GameObject> gameObjects = new List<GameObject>();
    float returnVelocityTimer;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
    }

    public void setInitialDirection(Vector3 dir)
    {
        initialDirection = dir.normalized;
    }

    void Update()
    {
        if (initialDirection != null)
        {
            transform.position += initialDirection * 15f * Time.deltaTime;
        }
        GravityAnimation();

        List<GameObject> objectsToRemove = new List<GameObject>();

        foreach (GameObject enemy in gameObjects)
        {
            if (enemy != null)
            {
                if (enemy.transform.position.y > 40)
                {
                    objectsToRemove.Add(enemy);
                }
            }
        }

        // Remove the objects that need to be removed
        foreach (GameObject enemy in objectsToRemove)
        {
            gameObjects.Remove(enemy);
        }
    }


    void GravityAnimation()
    {
        transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(Mathf.Sin(2 * Time.time)), 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb;
        if (collision.gameObject.tag == "Enemy")
        {
            //   Vector3 ForcePoint = collision.contacts[0].point;

            //  foreach (GameObject enemy in enemyManager.enemies)
            //{
            if (!gameObjects.Contains(collision.gameObject));
            {
                gameObjects.Add(collision.gameObject);

                rb = collision.gameObject.GetComponent<Rigidbody>();
                originalVelocities[collision.gameObject] = rb.velocity;
                //     Vector3 blackHoleVector = ForcePoint - enemy.transform.position;
                rb.velocity = Vector3.zero;
                //    isBlackHoleApplied = true;
                //  isBlackHoleApplied2 = true;
                rb.mass = 4;
                rb.AddForce(Vector3.up * 500f, ForceMode.Acceleration);
                

              

            }
            //  if (Vector3.Distance(ForcePoint, enemy.transform.position) < 2f)
            //{


            //}

            // }
            Destroy(gameObject);

        }
        
    }
    

    // Rest of your code...
}
