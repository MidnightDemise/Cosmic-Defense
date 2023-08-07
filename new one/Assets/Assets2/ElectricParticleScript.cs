using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem effect;
    void Start()
    {
        effect = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    public LineRenderer lineRenderer;

    void Update()
    {
        effect.Play();

        if (lineRenderer.positionCount < 2)
            return;

        Vector3 startPosition = lineRenderer.GetPosition(0);
        Vector3 endPosition = lineRenderer.GetPosition(lineRenderer.positionCount - 1);

        transform.position = startPosition;
        transform.LookAt(endPosition);
    }

}
