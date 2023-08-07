using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLookScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public GameObject Missileprefab;
    public Transform shootPoint;
    public float reload;
    bool isMissileDestroyed = false;
   
    void Start()
    {
        Instantiate(Missileprefab, shootPoint.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        if(reload > 2f && isMissileDestroyed)
        {
            Instantiate(Missileprefab, shootPoint.position, Quaternion.identity);
            reload = 0;
        }
        else
        {
            reload += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            isMissileDestroyed = true;
            
        }
    }
}
