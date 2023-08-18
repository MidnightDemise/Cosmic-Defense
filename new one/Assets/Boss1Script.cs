using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Boss1Script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform planet;
    private GameObject planetPrefab;
    private GameObject[] shootpoints;
    [SerializeField] GameObject bulletPrefab;
    private float timer;

    float health = 15000f;

    //event handling
    ArmyBossDestroyedEvent armyBossDestroyedEvent = new ArmyBossDestroyedEvent();

    void Start()
    {
        //event handling
        EventManager.AddArmyBossDestroyedEventInvoker(this);
        
        planet = GameObject.FindWithTag("planet").transform;
        planetPrefab = GameObject.FindWithTag("planet");
        shootpoints = GameObject.FindGameObjectsWithTag("boss1Shootpoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(planet.position, transform.position) < 10f && planetPrefab != null)
        {
            transform.RotateAround(planet.position, Vector3.forward, 25 * Time.deltaTime);

            if(timer > 1f)
            {
                for(int i = 0; i < shootpoints.Length; i++)
                {
                    Vector3 dir = planet.position - transform.position;
                    AudioManager.Play(ClipName.BossEnemyShot);
                  GameObject bullet =  Instantiate(bulletPrefab, shootpoints[i].transform.position, Quaternion.identity);
                    bullet.GetComponent<BossBullet>().setInitialDirection(dir);
                    timer = 0f;
                }
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        
        else
        {
            if(planetPrefab != null)
            {
                Vector3 dir = planet.position - transform.position;
                transform.Translate(dir * 2f * Time.deltaTime);
            }
            
        }
        
        

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            AudioManager.Play(ClipName.EnemyExplode);
            armyBossDestroyedEvent.Invoke();
            Destroy(gameObject, 0.5f);
        }

    }

    public void AddArmyBossDestroyedEventListener(UnityAction listener)
    {
        armyBossDestroyedEvent.AddListener(listener);
    }

   
}
