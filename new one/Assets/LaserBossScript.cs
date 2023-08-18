using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserBossScript : MonoBehaviour
{
    [SerializeField] Transform planet;
    private LineRenderer lineRenderer;
    private GameObject planetPrefab;

    float health = 25000;

    // event support 
    LaserBossDestroyedEvent laserBossDestroyedEvent = new LaserBossDestroyedEvent();

    // Start is called before the first frame update


    // Update is called once per frame

    void Start()
    {
        // Declaring Event invoker
        EventManager.AddLaserBossDestroyedEventInvoker(this);
        
        planet = GameObject.FindWithTag("planet").transform;
        planetPrefab = GameObject.FindWithTag("planet");
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(planet.position, transform.position) < 9f && planetPrefab != null)
        {
            transform.RotateAround(planet.position, Vector3.forward, 25 * Time.deltaTime);
            lineRenderer.SetPosition(0,transform.position);
            lineRenderer.SetPosition(1, planet.position);

           
        }
        else
        {
            if(planetPrefab != null)
            {
                Vector3 dir = planet.position - transform.position;
                transform.Translate(dir * 2f * Time.deltaTime);
            }
            
        }


        if(lineRenderer.GetPosition(1) != null && planetPrefab != null)
        {
            AudioManager.Play(ClipName.LaserShot);
            planet.GetComponent<SwipeEarth>().Damage(1f);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            AudioManager.Play(ClipName.EnemyExplode);
            laserBossDestroyedEvent.Invoke();
            Destroy(gameObject);
        }
    }

    public void AddLaserBossDestroyedEventListener(UnityAction listener)
    {
        laserBossDestroyedEvent.AddListener(listener);
    }
}

