using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LaserTowerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform laserPoint;
    private EnemyManager enemyManager;
    private List<Transform> laserRanges = new List<Transform>();
    public static List<Transform> EnemyRanges = new List<Transform>();
    public GameObject bulletPrefab;
    private LineRenderer lineRenderer;
    float reloadTimer = 0;
    private int damageMultiplier;
    private List<Collider> colliders = new List<Collider>();
    private Collider[] tempColliders;
    private List<Vector3> positionsOfContacts = new List<Vector3>();
    private float increment = 0f;
    public List<GameObject> lineRenderers = new List<GameObject>(4);

    public bool stun = false;
    public float currentStunTimer = 0f;

    public int laserDamage;


    void Start()
    {
        laserDamage = ConfigurationUtils.LaserDamage;
        
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager").gameObject.GetComponent<EnemyManager>();

        lineRenderer = gameObject.GetComponent<LineRenderer>();

        lineRenderers.Clear();
        for (int i = 0; i < 4; i++)
        {
            GameObject lineObj = Instantiate(bulletPrefab, laserPoint.position, Quaternion.identity);
            lineRenderers.Add(lineObj); // Use Add to add the new line object to the list
            LineRenderer line = lineObj.GetComponent<LineRenderer>();
            line.enabled = false;

        }

    }
    // Update is called once per frame
    void Update()
    {

        
        //Debug.Log(currentStunTimer);

        if (isStunned())
        {
            return;
        }

        if (enemyManager.enemies.Count == 0)
        {
           foreach (GameObject line in lineRenderers)
            {
                line.GetComponent<LineRenderer>().enabled = false;
            }
        }
        positionsOfContacts.Clear();
        laserRanges.Clear(); // Clear the list at the beginning of each frame

        foreach (var enemy in enemyManager.enemies)
        {
            if (enemy != null && Vector3.Distance(transform.position, enemy.transform.position) < 8f)
            {

                laserRanges.Add(enemy.transform);
            }
            else if(enemy != null  && Vector3.Distance(transform.position,enemy.transform.position) > 8f)
            {
                foreach (GameObject line in lineRenderers)
                {
                    if(line.GetComponent<LineRenderer>().enabled)
                    {
                        line.GetComponent<LineRenderer>().enabled = false;

                    }
                }
            }
            
            

        }
        Add4Enemies();


        //  if(reloadTimer > 0.1f)
        // {
        for (int i = 0; i < EnemyRanges.Count; i++)
        {
            LineRenderer line = lineRenderers[i].GetComponent<LineRenderer>();
            line.SetPosition(0, laserPoint.position);

            line.SetPosition(1, EnemyRanges[i].transform.position);

            if (line.GetPosition(1) != null)
            {
                positionsOfContacts.Add(line.GetPosition(1));

            }


            line.enabled = true;

            //  GameObject bulletObj = Instantiate(bulletPrefab, laserPoint.position, Quaternion.identity);
            // LaserBulletScript bulletScript = bulletObj.GetComponent<LaserBulletScript>();
            // bulletScript.targetEnemy = EnemyRanges[i]; // Assign the target enemy to the bullet
            //reloadTimer = 0f;
        }

        foreach (Vector3 pos in positionsOfContacts)
        {
            if (pos != null)
            {
                tempColliders = Physics.OverlapSphere(pos, 0.1f);
                colliders.Add(tempColliders[0]);

            }
        }

        foreach (Collider collider in colliders)
        {
            if (collider != null)
            {
                if (collider.gameObject.tag == "GreenShip")
                {

                    collider.GetComponent<GreenSip>().DamageShip(.9f);


                }


                if (collider.gameObject.tag == "YellowShip")
                {
                    collider.GetComponent<yelloShip>().DamageShip(0.9f);

                }

                if (collider.gameObject.tag == "RedShip")
                {
                    collider.GetComponent<RedShip>().DamageShip(0.9f);

                }

                if (collider.gameObject.tag == "ArmyBoss")
                {
                    collider.GetComponent<Boss1Script>().TakeDamage(0.9f);

                }

                if (collider.gameObject.tag == "LaserBoss")
                {
                    collider.GetComponent<LaserBossScript>().TakeDamage(0.9f);

                }

                if (collider.gameObject.tag == "FishBoss")
                {
                    collider.GetComponent<ElectricBossScript>().TakeDamage(0.9f);

                }

                increment += 0.002f;

                //}
                //   else
                //  {
                //  reloadTimer += Time.deltaTime;
                // }

            }







        }

        colliders.Clear();
    }

    void Add4Enemies()
    {
        laserRanges.Sort((enemy1, enemy2) =>
            Vector3.Distance(transform.position, enemy1.position).CompareTo(
                Vector3.Distance(transform.position, enemy2.position)));


        EnemyRanges.Clear();
        int count = Mathf.Min(laserRanges.Count, 4);


        for (int i = 0; i < count; i++)
        {
            EnemyRanges.Add(laserRanges[i]);
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