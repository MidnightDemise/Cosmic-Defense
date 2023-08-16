using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BOSS1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform planet;
    private GameObject[] shootpoints;

    private float timer;
    void Start()
    {
        shootpoints = GameObject.FindGameObjectsWithTag("boss1Shootpoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(planet.position, transform.position) < 6f)
        {
            transform.RotateAround(planet.position, Vector3.forward, 45 * Time.deltaTime);

            if (timer > 1f)
            {
                for (int i = 0; i < shootpoints.Length; i++)
                {

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
