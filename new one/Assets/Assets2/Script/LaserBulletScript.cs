using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBulletScript : MonoBehaviour
{
    public Transform targetEnemy; // Store the target enemy for the bullet
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy != null)
        {
            Vector3 dir = targetEnemy.position - transform.position;
            transform.Translate(dir.normalized * 15f * Time.deltaTime);

        }
    }
}
