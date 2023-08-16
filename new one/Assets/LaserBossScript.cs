using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBossScript : MonoBehaviour
{
    [SerializeField] Transform planet;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update


    // Update is called once per frame

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(planet.position, transform.position) < 9f)
        {
            transform.RotateAround(planet.position, Vector3.forward, 25 * Time.deltaTime);
            lineRenderer.SetPosition(0,transform.position);
            lineRenderer.SetPosition(1, planet.position);

           
        }
        else
        {
            Vector3 dir = planet.position - transform.position;
            transform.Translate(dir * 2f * Time.deltaTime);
        }


        if(lineRenderer.GetPosition(1) != null)
        {
            planet.GetComponent<SwipeEarth>().Damage(1f);
        }
    }
}

