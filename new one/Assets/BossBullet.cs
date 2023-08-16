using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Vector3 dir;
    private GameObject planet;
    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindWithTag("planet");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * 15f * Time.deltaTime;
    }

    public void setInitialDirection(Vector3 direction)
    {
        dir = direction.normalized;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "planet" || other.CompareTag("Node"))
        {
            planet.GetComponent<SwipeEarth>().Damage(25);
            Destroy(gameObject);
        }
    }
}
