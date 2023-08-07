using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBeamScript : MonoBehaviour
{
    private ParticleSystem beam;
    public Transform shootpoint;
    private EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        beam = gameObject.GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
