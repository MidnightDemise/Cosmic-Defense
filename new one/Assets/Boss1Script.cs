using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Boss1Script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform planet;
    private GameObject[] shootpoints;
    [SerializeField] GameObject bulletPrefab;
    private float timer; 
    void Start()
    {
        shootpoints = GameObject.FindGameObjectsWithTag("boss1Shootpoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(planet.position, transform.position) < 10f)
        {
            transform.RotateAround(planet.position, Vector3.forward, 25 * Time.deltaTime);

            if(timer > 1f)
            {
                for(int i = 0; i < shootpoints.Length; i++)
                {
                    Vector3 dir = planet.position - transform.position;
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
            Vector3 dir = planet.position - transform.position;
            transform.Translate(dir * 2f * Time.deltaTime);
        }
        
    }

   
}
