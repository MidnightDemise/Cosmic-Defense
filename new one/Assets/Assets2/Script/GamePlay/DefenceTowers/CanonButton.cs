using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonButton : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject scoreTextObject;

    Text scoreText;

    int currentScore;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreTextObject.GetComponent<Text>();
        currentScore = int.Parse(scoreText.text);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScore >= 150)
        {
            
        }
        else
        {

        }
    }
}
