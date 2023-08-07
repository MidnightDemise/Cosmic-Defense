using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform planet;
    public float speed = 5f;
    public int enemyHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = planet.position - transform.position;
        
        transform.Translate(dir.normalized * speed * Time.deltaTime);


      

    }

   // private void OnTriggerEnter(Collider other)
    //{
    // .//   if(other.gameObject.tag == "bullet")
      //  {
         //   Destroy(gameObject);
     //   }
    //}
}
