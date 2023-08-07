using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Transform target;
    public float damagePerSecond = 20f;
    public float maxRange = 10f; // Maximum range for the laser to stay locked on

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) <= maxRange)
        {
            // Update the laser's endpoint to stay locked onto the target
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target.position);

        }
        else
        {
            Destroy(gameObject);
        }
    }

}
