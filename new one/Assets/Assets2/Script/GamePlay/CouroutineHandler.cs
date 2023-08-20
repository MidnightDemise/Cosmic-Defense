using UnityEngine;
using System.Collections;

public class CoroutineHandler : MonoBehaviour
{
    private static CoroutineHandler _instance;

    public static CoroutineHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CoroutineHandler>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "CoroutineHandler";
                    _instance = obj.AddComponent<CoroutineHandler>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
    }
}
