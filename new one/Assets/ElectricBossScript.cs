using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class ElectricBossScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform planet;
    public float timer;
    public GameObject electricBall;
    public Transform shootpoint;

    float health = 35000;

    // Event functionality
    FishBossDestroyedEvent fishBossDestroyedEvent = new FishBossDestroyedEvent();

    void Start()
    {
        //Declaring Event 
        EventManager.AddFishBossDestroyedEventInvoker(this);
        
        planet = GameObject.FindWithTag("planet").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(planet.position, transform.position) < 9f)
        {
            
            transform.RotateAround(planet.position, Vector3.forward, 25 * Time.deltaTime);
            
            if(timer > 1f)
            {
                AudioManager.Play(ClipName.BossEnemyShot);
                GameObject a = Instantiate(electricBall, shootpoint.position, Quaternion.identity);
                a.GetComponent<ElectricBallScript>().setInitialDirection(planet.position - transform.position);
                timer = 0f;

            }
            else
            {
                timer += Time.deltaTime;

            }


        }
        else
        {
            Vector3 dir = planet.position - transform.position;
            transform.Translate(dir * 2f * Time.deltaTime);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health < 0f)
        {
            AudioManager.Play(ClipName.EnemyExplode);
            fishBossDestroyedEvent.Invoke();
            Destroy(gameObject);
        }
    }

    public void AddFishBossDestroyedEventListener(UnityAction listener)
    {
        fishBossDestroyedEvent.AddListener(listener);
    }
}
