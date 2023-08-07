using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundScript : MonoBehaviour
{
    public float speed = 10f;
    public Transform planet;
    // Start is called before the first frame update
    Vector3 intiialposition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            intiialposition = Input.mousePosition;
        }
        //transform.RotateAround(planet.position,Vector3.up, speed * Time.deltaTime); Rotates the given camera along in the y axis
        if(Input.GetMouseButton(0))
        {
            Vector3 dir =( Input.mousePosition - intiialposition).normalized;

            transform.RotateAround(planet.position, dir, 100f * Time.deltaTime);

        }
    }
}
