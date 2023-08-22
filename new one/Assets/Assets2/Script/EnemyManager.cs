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

    // fields for coroutines 
    private int currentWaveNumber = 0;
    private int totalWaves = 3;

    public int[] delay = { 5, 4, 3 };

    // Start is called before the first frame update
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


        LevelStart();
    }


    private void LevelStart()
    {
        Invoke(nameof(StartSpawning), 10f);
    }

    private void StartSpawning()
    {
        currentWaveNumber += 1;
        Debug.Log("Starting Wave" + currentWaveNumber);
        StartCoroutine(SpawnerRoutine(delay[currentWaveNumber - 1]));
        Debug.Log("done");

        float totalSpawnDuration = 0;
        for (int i = 1; i < 5; i++)
        {
            totalSpawnDuration += delay[currentWaveNumber - 1];
        }

        float clearDelay = totalSpawnDuration + 5f;

        StartCoroutine(ClearWave(clearDelay));
    }

    IEnumerator ClearWave(float delay)
    {
        yield return new WaitForSeconds(delay);

        Debug.Log(currentWaveNumber);


        if (currentWaveNumber >= totalWaves && !levelComplete)
        {
            if (LevelsUtils.LevelThree)
            {
                SpawnBoss(bossPrefabs[0]);
            }
            else if (LevelsUtils.LevelFour)
            {
                SpawnBoss(bossPrefabs[1]);
            }
            else if (LevelsUtils.LevelFour)
            {
                SpawnBoss(bossPrefabs[2]);
            }
            else
            {
                levelCompleteEvent.Invoke();
                levelComplete = true;
            }
        }
        else
        {
            StartSpawning();
        }

    }


    IEnumerator SpawnerRoutine(float delay)
    {
        for (int i = 1; i < 5; i++)
        {
            SpawnerGreenShip(i);
            yield return new WaitForSeconds(delay);
            SpawnerYellowShip(1);
            yield return new WaitForSeconds(delay);
            SpawnerRedShip(1);
            yield return new WaitForSeconds(delay);
        }
    }

    private void SpawnerGreenShip(int amount)
    {
        for (int i = 3; i > amount; i--)
        {
            GameObject enemy = greenShipPool.GetObjectFromPool();
            if (enemy != null)
            {
                enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                enemies.Add(enemy);
            }
        }
    }

    private void SpawnerYellowShip(int amount)
    {
        for (int i = 3; i > amount; i--)
        {
            GameObject enemy = yellowShipPool.GetObjectFromPool();
            if (enemy != null)
            {
                enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                enemies.Add(enemy);
            }
        }


    }

    private void SpawnerRedShip(int amount)
    {

        for (int i = 3; i > amount; i--)
        {
            GameObject enemy = redShipPool.GetObjectFromPool();
            if (enemy != null)
            {
                enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                enemies.Add(enemy);
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }




    void SpawnBoss(GameObject bossPrefab)
    {
        if (bossPrefabs.Length > 0)
        {
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;
            GameObject boss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            enemies.Add(boss);
        }
        else
        {
            Debug.LogWarning("No boss prefab defined.");
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
