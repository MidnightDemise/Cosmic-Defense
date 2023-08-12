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


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger working");
        if(other.CompareTag("GreenShip"))
        {
            other.GetComponent<GreenSip>().DamageShip(70);

        }

        if (other.CompareTag("YellowShip"))
        {
            other.GetComponent<yelloShip>().DamageShip(70);


        }

        if (other.CompareTag("RedShip"))
        {

            other.GetComponent<RedShip>().DamageShip(70);


        }
    }



    
}
