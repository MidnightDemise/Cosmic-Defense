using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityVisualScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GravityAnimation();
    }


    void GravityAnimation()
    {
        transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(Mathf.Sin(2 * Time.time)), 1);

    }
}
