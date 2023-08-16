using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePartTRotateScript : MonoBehaviour
{
    public float increment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + increment);
        increment += Time.deltaTime * 45;
    }
}
