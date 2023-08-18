using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool
{
    private List<GameObject> pool = new List<GameObject>();
    private GameObject prefab;

    public GameObjectPool(GameObject prefab, int initialPoolSize)
    {
        this.prefab = prefab;
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Object.Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Object.Instantiate(prefab);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}