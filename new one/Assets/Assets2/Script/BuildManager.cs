using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
    private List<GameObject> Nodes = new List<GameObject>();
    public GameObject BuildButton;
    private float angle;
    public Transform planetPos;
    public static Vector3 originalPosCamera;
    public static Quaternion originalRotCamera;


    // for event handling
    CostDeductedEvent costDeductedEvent = new CostDeductedEvent();

    //for costing 
    int canonCost;
    int gravityLauncherCost;
    int laserTowerCost;
    int missileLauncherCost;
    int plasmaLauncherCost;

    // for fixing turret placements

    private GameObject selectedWeaponType;
    
    bool canonButtonClicked = false;
    bool gravityLauncherButtonClicked = false;
    bool laserButtonClicked = false;
    bool missileLauncherButtonClicked = false;
    bool plasmaLauncherButtonClicked = false;


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

    private void Start()
    {
        
        
        
        EventManager.AddCostDeductedEventInvoker(this);
        
        canonCost = ConfigurationUtils.CanonPrice;
        gravityLauncherCost = ConfigurationUtils.GravityLauncherPrice;
        laserTowerCost = ConfigurationUtils.LaserTowerPrice;
        missileLauncherCost = ConfigurationUtils.MissileLauncherPrice;
        plasmaLauncherCost = ConfigurationUtils.PlasmaLauncherPrice;


    }

    private void Update()
    {
        
        if (BuildButton.activeSelf)
        {
             foreach(GameObject Node in Nodes)
            {
                Node.SetActive(false);
            }
        }
        else
        {
            foreach(GameObject Node in Nodes)
            {
                Node.SetActive(true);
            }
        }

    }

    // Update is called once per frame

    public void setTurret()
    {
        if(!canonButtonClicked)
        {
            selectedWeaponType = turret;
            costDeductedEvent.Invoke(canonCost);
            canonButtonClicked = true; 
        }
        else
        {
            selectedWeaponType = null;
        }
        
    }

    public void SetMissile()
    {
        if(!missileLauncherButtonClicked)
        {
            selectedWeaponType = missileLauncher;
            costDeductedEvent.Invoke(missileLauncherCost);
            missileLauncherButtonClicked = true;
        }
        else
        {
            selectedWeaponType = null;
        }
    }

    public void SetLaser()
    {
        if(!laserButtonClicked)
        {
            selectedWeaponType = laserLauncher;
            costDeductedEvent.Invoke(laserTowerCost);
            laserButtonClicked = true;
        }
        else
        {
            selectedWeaponType=null;
        }
        
    }
    
    public void setGravityBall()
    {
        if(!gravityLauncherButtonClicked)
        {
            selectedWeaponType = gravityBall;
            costDeductedEvent.Invoke(gravityLauncherCost);
            gravityLauncherButtonClicked = true;
        }
        else
        {
            selectedWeaponType = null;
        }
        
    }

    public void setMegaLaser()
    {
        if(!plasmaLauncherButtonClicked)
        {
            selectedWeaponType = MegaLaserLauncher;
            costDeductedEvent.Invoke(plasmaLauncherCost);
            plasmaLauncherButtonClicked = true;
        }
        else
        {
            selectedWeaponType = null;
        }
    }
    public GameObject GetGameTurret()
    {
            return selectedWeaponType;        
    }


    private void createNodes()
    {
        float angleStep  = 360f / numberOfPlates;
        for(int i = 0; i < numberOfPlates; i++)
        {
            angle = i * angleStep;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * 4.308425f; //y = r * sin theta
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * 4.308425f;
            Vector3 platePosition = planetPos.position + new Vector3(x, y, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, -( 270 - angle));
            GameObject plate = Instantiate(platePrefab, platePosition, rotation);
            plate.transform.SetParent(planetPos);
            Nodes.Add(plate);

        }
    }

  

   

    public void AddCostDeductedEventListener(UnityAction<int> listener)
    {
        costDeductedEvent.AddListener(listener);
    }

  

    
}
