using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform shootpoint;
    Vector3 direction;
    private Rigidbody rb;
    void Start()
    {
    }

    public void setInitialDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    public void setRotation(float x)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x + x , transform.rotation.y,transform.rotation.z);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * 15f * Time.deltaTime ;
    }
}
