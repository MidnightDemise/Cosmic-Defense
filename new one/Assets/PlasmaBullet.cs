using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform shootpoint;
    Vector3 direction;
    private Rigidbody rb;

    public int megaLaserDamage;
    void Start()
    {
        megaLaserDamage = ConfigurationUtils.MegaLaserDamage;
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
        Destroy(gameObject);
        //Debug.Log("Trigger working");
        if(other.CompareTag("GreenShip"))
        {
            other.GetComponent<GreenSip>().DamageShip(megaLaserDamage);

        }

        if (other.CompareTag("YellowShip"))
        {
            other.GetComponent<yelloShip>().DamageShip(megaLaserDamage);


        }

        if (other.CompareTag("RedShip"))
        {

            other.GetComponent<RedShip>().DamageShip(megaLaserDamage);


        }
        if (other.CompareTag("ArmyBoss"))
        {
            other.GetComponent<Boss1Script>().TakeDamage(megaLaserDamage);
        }
        if (other.CompareTag("LaserBoss"))
        {
            other.GetComponent<LaserBossScript>().TakeDamage(megaLaserDamage);
        }
        if (other.CompareTag("FishBoss"))
        {
            other.GetComponent<ElectricBossScript>().TakeDamage(megaLaserDamage);
        }

    }



    
}
