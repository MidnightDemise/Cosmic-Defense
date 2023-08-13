using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPoints;
    public GreenSip script;
    private List<GameObject> childObjects = new List<GameObject>();

    //Enemies Array
    public List<GameObject> enemies = new List<GameObject>();

    //Prefabs
    public GameObject greenShipPrefab;
    public GameObject yellowShipPrefab;
    public GameObject redShipPrefab;

    public GameObject gravityBall;
    //WaveTimers
    public float waveTimer;
    public float nextWaveTimer = 30f;
    public float spawnTimer = 5f;
    public float timer;
    public float preparationTimer = 30f;


    //DropRates
    public int DropRateOfGreen = 800;
    public int DropRateOfYellow = 1200;
    public int DropRateOfRed = 1500;

    //events
    LevelCompleteEvent levelCompleteEvent = new LevelCompleteEvent();
    private bool levelComplete = false;
   
    
    void Start()
    {
        EventManager.AddLevelCompleteEventInvoker(this);
        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag("spawnPoint");

        for(int i = 0; i < spawnObjects.Length; i++)
        {
            spawnPoints[i] = spawnObjects[i].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > preparationTimer && timer <= 60f)
        {   
            spawnWave1();
            timer += Time.deltaTime;
        }
        else if(timer >= 60f && timer <= 90f)
        {
            DropRateOfGreen = 40000;
            DropRateOfYellow =20200;
            DropRateOfRed = 10500;
           spawnWave2();
            timer += Time.deltaTime;
        }
        else if(timer >= 90f && !levelComplete)
        {
            spawnWave3();
            if(timer >= 120f)
            {
                levelCompleteEvent.Invoke();
                levelComplete = true;
            }
        }
    }


    void spawnWave1()
    {

        
            spawnGreenShip(1,DropRateOfGreen);
            spawnYellowShip(1,DropRateOfYellow);
            spawnRedShip(1, DropRateOfRed) ;
       

    }


    void spawnWave3()
    {
        spawnGreenShip(1, DropRateOfGreen);
        spawnYellowShip(1, DropRateOfYellow);
        spawnRedShip(1, DropRateOfRed);
       

    }


    void spawnWave2()
    {

        spawnGreenShip(1, DropRateOfGreen);
        spawnYellowShip(1, DropRateOfYellow);
        spawnRedShip(1, DropRateOfRed);
    }

    void spawnGreenShip(int amount,int dropRate)
    {
        for(int i = 0; i < amount; i++)
        {
            if (Random.Range(1, dropRate) == 2)
            {
                spawn(greenShipPrefab);
            }

        }
       
    }

    void spawnYellowShip(int amount, int dropRate)
    {
        for (int i = 0; i < amount; i++)
        {
            if(Random.Range(1,dropRate) == 2)
            {
                spawn(yellowShipPrefab);
            }
        }
    }

    void spawnRedShip(int amount,int dropRate)
    {
       for(int i = 0; i< amount; i++)
        {
            if(Random.Range(1,dropRate) == 2)
            {
                spawn(redShipPrefab);
            }
        }
    }

    void spawn(GameObject prefab)
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        GameObject enemy = Instantiate(prefab, spawnPoints[randomIndex].position, Quaternion.identity);

        enemies.Add(enemy);
    }


    public void AddLevelCompleteEventListener(UnityAction listener)
    {
        levelCompleteEvent.AddListener(listener);
    }
   


}
