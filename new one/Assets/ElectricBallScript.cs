using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ElectricBallScript : MonoBehaviour
{
    private Vector3 dir;
    private Collider[] colliders;
    private List<Collider> stunColliders = new List<Collider>();
    private GameObject planet;
    float reliveTimer;
    // Start is called before the first frame updat
    private void Awake()
    {
        planet = GameObject.FindWithTag("planet");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += dir * 15f * Time.deltaTime;
      
       


        if (stunColliders != null)
        {
            for (int i = stunColliders.Count - 1; i >= 0; i--)
            {
                Collider collider = stunColliders[i];
                if(collider.gameObject.tag == "Turret")
                {
                    TurretMain turretMain = collider.gameObject.GetComponent<TurretMain>();


                    if (turretMain.isStunned())
                    {
                        turretMain.UpdateStunTimer(Time.deltaTime);
                        if (turretMain.GetStunTimer() >= 5f)
                        {
                            turretMain.setStun(false);
                            stunColliders.RemoveAt(i);
                            turretMain.ResetStunTimer();
                        }
                    }
                    else
                    {
                        turretMain.setStun(true);
                    }

                }

                if(collider.gameObject.tag == "MissileLauncher")
                {
                    MissileLookScript turretMain = collider.gameObject.GetComponent<MissileLookScript>();


                    if (turretMain.isStunned())
                    {
                        turretMain.UpdateStunTimer(Time.deltaTime);
                        if (turretMain.GetStunTimer() >= 5f)
                        {
                            turretMain.setStun(false);
                            stunColliders.RemoveAt(i);
                            turretMain.ResetStunTimer();
                        }
                    }
                    else
                    {
                        turretMain.setStun(true);
                    }
                }

                if (collider.gameObject.tag == "LaserTower")
                {
                    LaserTowerScript turretMain = collider.gameObject.GetComponent<LaserTowerScript>();


                    if (turretMain.isStunned())
                    {
                        turretMain.UpdateStunTimer(Time.deltaTime);
                        if (turretMain.GetStunTimer() >= 5f)
                        {
                            turretMain.setStun(false);
                            stunColliders.RemoveAt(i);
                            turretMain.ResetStunTimer();
                        }
                    }
                    else
                    {
                        turretMain.setStun(true);
                    }
                }
                if (collider.gameObject.tag == "GravityLauncher")
                {
                    GravityLauncherScript turretMain = collider.gameObject.GetComponent<GravityLauncherScript>();


                    if (turretMain.isStunned())
                    {
                        turretMain.UpdateStunTimer(Time.deltaTime);
                        if (turretMain.GetStunTimer() >= 5f)
                        {
                            turretMain.setStun(false);
                            stunColliders.RemoveAt(i);
                            turretMain.ResetStunTimer();
                        }
                    }
                    else
                    {
                        turretMain.setStun(true);
                    }
                }

                if (collider.CompareTag("PlasmaLauncher"))
                {
                    MegaLaserScript turretMain = collider.gameObject.GetComponent<MegaLaserScript>();


                    if (turretMain.isStunned())
                    {
                        turretMain.UpdateStunTimer(Time.deltaTime);
                        if (turretMain.GetStunTimer() >= 5f)
                        {
                            turretMain.setStun(false);
                            stunColliders.RemoveAt(i);
                            turretMain.ResetStunTimer();
                        }
                    }
                    else
                    {
                        turretMain.setStun(true);
                    }
                }


            }
        }




    }

    public void setInitialDirection(Vector3 direction)
    {
        dir = direction.normalized;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("planet") || other.gameObject.tag == "Node")
        {
            planet.GetComponent<SwipeEarth>().Damage(20);
            Vector3 triggerPoint = other.ClosestPointOnBounds(transform.position);
            colliders = Physics.OverlapSphere(triggerPoint, 1.7f);

            Vector3 localTriggerPoint = transform.InverseTransformPoint(triggerPoint);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Turret") && !stunColliders.Contains(collider))
                {
                    stunColliders.Add(collider);
                    TurretMain turretMain = collider.gameObject.GetComponent<TurretMain>();
                    turretMain.setStun(true);

                }

                if(collider.CompareTag("MissileLauncher") && !stunColliders.Contains(collider))
                {
                    Debug.Log("hi");
                    stunColliders.Add(collider);
                    MissileLookScript missile = collider.gameObject.GetComponent<MissileLookScript>();
                    missile.setStun(true);
                }
                if (collider.CompareTag("LaserTower") && !stunColliders.Contains(collider))
                {
                    Debug.Log("hi");
                    stunColliders.Add(collider);
                    LaserTowerScript laserTower = collider.gameObject.GetComponent<LaserTowerScript>();
                    laserTower.setStun(true);
                }
                if (collider.CompareTag("GravityLauncher") && !stunColliders.Contains(collider))
                {
                    Debug.Log("hi");
                    stunColliders.Add(collider);
                    GravityLauncherScript gravity = collider.gameObject.GetComponent<GravityLauncherScript>();
                    gravity.setStun(true);

                }
                if (collider.CompareTag("PlasmaLauncher") && !stunColliders.Contains(collider))
                {
                    Debug.Log("hi");
                    stunColliders.Add(collider);
                    MegaLaserScript plasma = collider.gameObject.GetComponent<MegaLaserScript>();
                    plasma.setStun(true);
                }
            }
        }
    }
}
