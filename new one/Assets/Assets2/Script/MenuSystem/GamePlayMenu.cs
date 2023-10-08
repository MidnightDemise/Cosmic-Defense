using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayMenu : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject scoreTextGameObject;

    //score text Support
    static int score = 0;
    static Text scoreText;

    int currentScore;

    [SerializeField]
    Button canonButton;

    [SerializeField]
    Button gravityLauncherButton;

    [SerializeField]
    Button laserTowerButton;

    [SerializeField]
    Button missileLauncherButton;

    [SerializeField]
    Button plasmaLauncherButton;

    [SerializeField]
    Button ClockWiseButton;

    [SerializeField]
    Button CounterClockWiseButton;

    
    //rotation functionality
    
    const float RotateDegreesPerSecond = 180;

    bool clockwiseButtonPressed;
    bool counterClockwiseButtonPressed;
    bool upButtonPressed;
    bool downButtonPressed;
    


    #endregion


    #region Properties

    /// <summary>
    /// Gets the score
    /// </summary>
    public int Score
    {
        get { return score; }
    }

    public int CurrentScore
    {
        get { return currentScore; }
    }

    #endregion

    private void Start()
    {
        // for initializing score text
        score = ConfigurationUtils.StartingScore;
        scoreText = scoreTextGameObject.GetComponent<Text>();
        scoreText.text = score.ToString();

        canonButton.interactable = false;
        gravityLauncherButton.interactable = false;
        laserTowerButton.interactable = false;
        missileLauncherButton.interactable = false;
        plasmaLauncherButton.interactable = false;

        EventManager.AddGreenShipPointsAddedEventListener(AddPoints);
        EventManager.AddYellowShipPointsAddedEventListener(AddPoints);
        EventManager.AddRedShipPointsAddedEventListener(AddPoints);

        EventManager.AddCostDeductedEventListener(DeductCost);

    }

    private void Update()
    {
        currentScore = int.Parse(scoreText.text);
        if(currentScore >= ConfigurationUtils.CanonPrice)
        {
            canonButton.interactable = true;
        }
        else if(currentScore < ConfigurationUtils.CanonPrice)
        {
            canonButton.interactable = false;
        }

        if (currentScore >= ConfigurationUtils.GravityLauncherPrice)
        {
            gravityLauncherButton.interactable = true;
        }
        else if(currentScore < ConfigurationUtils.GravityLauncherPrice) 
        {
            gravityLauncherButton.interactable = false;
        }

        if (currentScore >= ConfigurationUtils.LaserTowerPrice)
        {
            laserTowerButton.interactable = true;
        }
        else if(currentScore < ConfigurationUtils.LaserTowerPrice)
        {
            laserTowerButton.interactable = false;
        }

        if (currentScore >= ConfigurationUtils.MissileLauncherPrice)
        {
            missileLauncherButton.interactable = true;
        }
        else if(currentScore < ConfigurationUtils.MissileLauncherPrice)
        {
            missileLauncherButton.interactable = false;
        }
        if (currentScore >= ConfigurationUtils.PlasmaLauncherPrice)
        {
            plasmaLauncherButton.interactable = true;
        }
        else if(currentScore < ConfigurationUtils.PlasmaLauncherPrice)
        {
            plasmaLauncherButton.interactable = false;
        }

    }

    public void HandleQuitButtonClicked()
    {
        Time.timeScale = 1;
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);

    }

    public void HandleRestartButtonClick()
    {
        Time.timeScale = 1;
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
        
    }

    public void HandleBuildButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        ClockWiseButton.enabled = false;
        CounterClockWiseButton.enabled = false;
    }

    public void HandleReturnButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        ClockWiseButton.enabled = true;
        CounterClockWiseButton.enabled = true;
    }

    void AddPoints(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void DeductCost(int cost)
    {
        score -= cost;
        scoreText.text = score.ToString();
    }

    

}
