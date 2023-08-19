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
    private float timer = 10f;
    private float currentStunTimer = 0f;
    private bool stun = false;
    public GameObject enemyManager;

    void Start()
    {
       // AudioManager.Play(ClipName.CanonShot);
       
        enemyManager = GameObject.FindWithTag("EnemyManager");
    }

    void Update()
    {
        if(enemyManager.GetComponent<EnemyManager>().enemies.Count == 0)
        {
            return;
        }
        

            if (isStunned())
        {
            return;
        }

        if(timer > 10f)
        {
            //AudioManager.Play(ClipName.CanonShot);

            missile = Instantiate(Missileprefab, shootPoint.position, Quaternion.identity);
            missile.GetComponent<HomingScript>().setInitialRotation(shootPoint.rotation);
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }


    public void setStun(bool value)
    {
        stun = value;
    }

    public bool isStunned()
    {
        return stun;
    }


    public void UpdateStunTimer(float deltaTime)
    {
        currentStunTimer += deltaTime;
    }

    public float GetStunTimer()
    {
        return currentStunTimer;
    }

    public void ResetStunTimer()
    {
        currentStunTimer = 0f;
    }
}
