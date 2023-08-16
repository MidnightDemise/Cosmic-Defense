using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbRotateLaserBoss : MonoBehaviour
{
    // Start is called before the first frame update

    public float increment;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x + increment, transform.rotation.y + increment, transform.rotation.z + increment);

        increment += Time.deltaTime * 200;
    }
}
