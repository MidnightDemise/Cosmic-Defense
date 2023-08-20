using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    //handling object pooling
    private GameObjectPool greenShipPool;
    private GameObjectPool yellowShipPool;
    private GameObjectPool redShipPool;

    

    // handling boss instantiation
    public GameObject[] bossPrefabs;
    private bool bossSpawned = false;

    //handling build manager button 
    [SerializeField]
    Button buildButton;

    void Start()
    {
        greenShipPool = new GameObjectPool(greenShipPrefab, 5);
        yellowShipPool = new GameObjectPool(yellowShipPrefab, 5);
        redShipPool = new GameObjectPool(redShipPrefab, 5);

        EventManager.AddLevelCompleteEventInvoker(this);

        

        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag("spawnPoint");

        for (int i = 0; i < spawnObjects.Length; i++)
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
            buildButton.GetComponent<Button>().enabled = false;
            buildButton.GetComponent<Image>().enabled = false;
            spawnWave1();
            timer += Time.deltaTime;
        }
        else if (timer >= 60f && timer <= 90f)
        {
            DropRateOfGreen = 40000;
            DropRateOfYellow = 20200;
            DropRateOfRed = 10500;
            spawnWave2();
            timer += Time.deltaTime;
        }
        else if (timer >= 90f && !levelComplete)
        {
            spawnWave3();
            if (timer >= 120f && LevelsUtils.LevelThree || LevelsUtils.LevelFour || LevelsUtils.LevelFive)
            {
                if (!bossSpawned)
                {
                    SpawnBoss();
                    bossSpawned = true;
                }
            }
            else if (timer >= 120f)
            {
                
                levelCompleteEvent.Invoke();
                levelComplete = true;
            }

        }
    }


    void spawnWave1()
    {


        spawnGreenShip(1, DropRateOfGreen);
        spawnYellowShip(1, DropRateOfYellow);
        spawnRedShip(1, DropRateOfRed);


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

    void spawnGreenShip(int amount, int dropRate)
    {
        for (int i = 0; i < amount; i++)
        {
            if (Random.Range(1, dropRate) == 2)
            {
                //spawn(greenShipPrefab);
                GameObject enemy = greenShipPool.GetObjectFromPool();
                if (enemy != null)
                {
                    enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                    enemies.Add(enemy);
                }
            }

        }

    }

    void spawnYellowShip(int amount, int dropRate)
    {
        for (int i = 0; i < amount; i++)
        {
            if (Random.Range(1, dropRate) == 2)
            {
                //spawn(yellowShipPrefab);
                GameObject enemy = yellowShipPool.GetObjectFromPool();
                if (enemy != null)
                {
                    enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                    enemies.Add(enemy);
                }

            }
        }
    }

    void spawnRedShip(int amount, int dropRate)
    {
        for (int i = 0; i < amount; i++)
        {
            if (Random.Range(1, dropRate) == 2)
            {
                //spawn(redShipPrefab);
                GameObject enemy = redShipPool.GetObjectFromPool();
                if (enemy != null)
                {
                    enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                    enemies.Add(enemy);
                }
            }
        }
    }

    void spawn(GameObject prefab)
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        GameObject enemy = Instantiate(prefab, spawnPoints[randomIndex].position, Quaternion.identity);

        enemies.Add(enemy);
    }

    void SpawnBoss()
    {
        if (bossPrefabs.Length > 0 && LevelsUtils.LevelThree)
        {
            GameObject bossPrefab = bossPrefabs[0];
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;
            GameObject bossOne = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            enemies.Add(bossOne);

        }
        else if (bossPrefabs.Length > 0 && LevelsUtils.LevelFour)
        {
            GameObject bossPrefab = bossPrefabs[1];
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;
            GameObject bossTwo = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            enemies.Add(bossTwo);
        }
        else if (bossPrefabs.Length > 0 && LevelsUtils.LevelFive)
        {
            GameObject bossPrefab = bossPrefabs[2];
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;
            GameObject bossThree = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            enemies.Add(bossThree);
        }
        else
        {
            Debug.LogWarning("No boss prefab defined for the current level.");
            bossSpawned = true; // Skip boss spawning
        }
    }

    public void ReturnShipToPool(GameObject ship)
    {
        if (greenShipPool != null)
        {
            greenShipPool.ReturnObjectToPool(ship);
        }

    }


    public void AddLevelCompleteEventListener(UnityAction listener)
    {
        levelCompleteEvent.AddListener(listener);
    }



}
