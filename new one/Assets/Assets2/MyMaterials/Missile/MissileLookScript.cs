using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class MissileLookScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public GameObject Missileprefab;
    public Transform shootPoint;
    public float reload;
    bool isMissileDestroyed = false;
    private GameObject missile;
    private float timer = 0f;

    void Start()
    {
        Instantiate(Missileprefab, shootPoint.position, Quaternion.identity);
    }

    void Update()
    {
        if(timer > 8f)
        {
            missile = Instantiate(Missileprefab, shootPoint.position, Quaternion.identity);
            missile.GetComponent<HomingScript>().setInitialRotation(shootPoint.rotation);
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
