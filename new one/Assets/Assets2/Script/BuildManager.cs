using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static List<GameObject> numberOfTurrets = new List<GameObject>();
    public static BuildManager instance;
    public Transform camera;
    private GameObject turretToBuild;
    public GameObject platePrefab;
    public GameObject turret;
    public GameObject laserLauncher;
    public GameObject missileLauncher;
    public GameObject gravityBall;
    public GameObject MegaLaserLauncher;
    public float numberOfPlates = 20;
    private float angle;
    public Transform planetPos;
    public static Vector3 originalPosCamera;
    public static Quaternion originalRotCamera;
    // Start is called before the first frame update
    void Awake()
    {
        createNodes();

        originalPosCamera = camera.position;
        originalRotCamera = camera.rotation;
        
        if (instance != null)
        {
            return;
        }
        instance = this;


    }


    // Update is called once per frame
    
    public void setTurret()
    {
        turretToBuild = turret;
    }

    public void SetMissile()
    {
        turretToBuild = missileLauncher;
    }

    public void SetLaser()
    {
        turretToBuild = laserLauncher;
    }
    
    public void setGravityBall()
    {
        turretToBuild = gravityBall;
    }

    public void setMegaLaser()
    {
        turretToBuild = MegaLaserLauncher;
    }
    public GameObject GetGameTurret()
    {
        return turretToBuild;
    }


    private void createNodes()
    {
        float angleStep  = 360f / numberOfPlates;
        for(int i = 0; i < numberOfPlates; i++)
        {
            angle = i * angleStep;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * 5f;
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * 5f;
            Vector3 platePosition = planetPos.position + new Vector3(x, y, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, -( 270 - angle));
            GameObject plate = Instantiate(platePrefab, platePosition, rotation);
            plate.transform.SetParent(planetPos);

        }
    }

    
}
