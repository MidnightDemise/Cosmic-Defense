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
    public static GameObject turretToBuild;
    public GameObject platePrefab;
    public GameObject turret;
    public GameObject laserLauncher;
    public GameObject missileLauncher;
    public GameObject gravityBall;
    public GameObject MegaLaserLauncher;



    //for Buttons To setAcTIVE AND SETFALSE

    public GameObject turretButton;
    public GameObject missileButton;
    public GameObject laserButton;
    public GameObject gravityButton;
    public GameObject plasmaButton;





    // NODE STUFF
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

    public static bool isCLickedOnButton;
    // for fixing turret placements



    public GameObject[] turretButtons;


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
        if (isCLickedOnButton)
        {
            turretButton.SetActive(false);
            missileButton.SetActive(false);
            laserButton.SetActive(false);
            gravityButton.SetActive(false);
            plasmaButton.SetActive(false);


        }
        else if(!BuildButton.activeSelf)
        {
            turretButton.SetActive(true);
            missileButton.SetActive(true);
            laserButton.SetActive(true);
            gravityButton.SetActive(true);
            plasmaButton.SetActive(true);

        }

        if (BuildButton.activeSelf)
        {
            foreach (GameObject Node in Nodes)
            {
                Node.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject Node in Nodes)
            {
                Node.SetActive(true);
            }
        }

    }

    // Update is called once per frame

    public void setTurret()
    {

        costDeductedEvent.Invoke(canonCost);
        turretToBuild = turret;
        isCLickedOnButton = true;

    }

    public void SetMissile()
    {

        costDeductedEvent.Invoke(missileLauncherCost);
        turretToBuild = missileLauncher;
        isCLickedOnButton = true;
    }

    public void SetLaser()
    {

        costDeductedEvent.Invoke(laserTowerCost);
        turretToBuild = laserLauncher;
        isCLickedOnButton = true;
    }

    public void setGravityBall()
    {

        costDeductedEvent.Invoke(gravityLauncherCost);
        turretToBuild = gravityBall;
        isCLickedOnButton = true;

    }

    public void setMegaLaser()
    {

        costDeductedEvent.Invoke(plasmaLauncherCost);
        turretToBuild = MegaLaserLauncher;
        isCLickedOnButton = true;
    }
    public GameObject GetGameTurret()
    {
        return turretToBuild;
    }


    private void createNodes()
    {
        float angleStep = 360f / numberOfPlates;
        for (int i = 0; i < numberOfPlates; i++)
        {
            angle = i * angleStep;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * 4.308425f; //y = r * sin theta
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * 4.308425f;
            Vector3 platePosition = planetPos.position + new Vector3(x, y, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, -(270 - angle));
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
