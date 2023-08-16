using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElectricBossScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform planet;
    public float timer;
    public GameObject electricBall;
    public Transform shootpoint;
    void Start()
    {
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
}
