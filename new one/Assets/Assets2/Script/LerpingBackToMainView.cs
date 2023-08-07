using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpingBackToMainView : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firstposition;
    public Transform secondPosition;
    public LerpingBackToMainView script;
    Vector3 originalPos;
    Quaternion originalRot;
    float timer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 1f)
        {
            timer += Time.deltaTime;

            transform.position = Vector3.Lerp(secondPosition.position, firstposition.position, timer);
            transform.rotation = Quaternion.Slerp(secondPosition.rotation, firstposition.rotation, timer);
        }
        else if(timer > 1f)
        {
            timer = 0f;
            script.enabled = false;
        }
    }
}
