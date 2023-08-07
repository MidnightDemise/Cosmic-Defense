using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpingCameraPos : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0f;
    public Transform firstPosition;
    public Transform secondPosition;
    public LerpingCameraPos script;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BuildPositionLerp();
    }


    public void BuildPositionLerp()
    {
        if (timer < 1f)
        {
            timer = (timer + Time.deltaTime);

            transform.position = Vector3.Lerp(firstPosition.position, secondPosition.position, timer);
            transform.rotation = Quaternion.Slerp(firstPosition.rotation, secondPosition.rotation, timer);
        }
        else if( timer > 1f)
        {
            timer = 0f;
            script.enabled = false;
            
        }
    }
}
