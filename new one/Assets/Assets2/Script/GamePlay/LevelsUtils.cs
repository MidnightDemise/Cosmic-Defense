using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelsUtils 
{
    #region Fields

    static Levels levels;

    #endregion

    #region Static Properties 

    public static int GreenEnemyHealth
    {
        get
        {
            switch(levels)
            {
                case Levels.LevelOne:
                    return ConfigurationUtils.LevelOneGreenEnemyHealth;
                case Levels.LevelTwo:
                    return ConfigurationUtils.LevelTwoGreenEnemyHealth;
                case Levels.LevelThree:
                    return ConfigurationUtils.LevelThreeGreenEnemyHealth;
                case Levels.LevelFour:
                    return ConfigurationUtils.LevelFourGreenEnemyHealth;
                case Levels.LevelFive:
                    return ConfigurationUtils.LevelFiveGreenEnemyHealth;        
                default:
                    return ConfigurationUtils.LevelOneGreenEnemyHealth;
            }
        }
    }

    public static int YellowEnemyHealth
    {
        get
        {
            switch (levels)
            {
                case Levels.LevelOne:
                    return ConfigurationUtils.LevelOneYellowEnemyHealth;
                case Levels.LevelTwo:
                    return ConfigurationUtils.LevelTwoYellowEnemyHealth;
                case Levels.LevelThree:
                    return ConfigurationUtils.LevelThreeYellowEnemyHealth;
                case Levels.LevelFour:
                    return ConfigurationUtils.LevelFourYellowEnemyHealth;
                case Levels.LevelFive:
                    return ConfigurationUtils.LevelFiveYellowEnemyHealth;
                default:
                    return ConfigurationUtils.LevelOneYellowEnemyHealth;
            }
        }
    }

    public static int RedEnemyHealth
    {
        get
        {
            switch (levels)
            {
                case Levels.LevelOne:
                    return ConfigurationUtils.LevelOneRedEnemyHealth;
                case Levels.LevelTwo:
                    return ConfigurationUtils.LevelTwoRedEnemyHealth;
                case Levels.LevelThree:
                    return ConfigurationUtils.LevelThreeRedEnemyHealth;
                case Levels.LevelFour:
                    return ConfigurationUtils.LevelFourRedEnemyHealth;
                case Levels.LevelFive:
                    return ConfigurationUtils.LevelFiveRedEnemyHealth;
                default:
                    return ConfigurationUtils.LevelOneRedEnemyHealth;
            }
        }
    }

    #endregion

    #region Methods

    public static void Initialize()
    {
        EventManager.AddGameStartedEventListener(HandleGameStartedEvent);
    }
    
    static void HandleGameStartedEvent(Levels name)
    {
        levels = name;
        SceneManager.LoadScene("GamePlay");
    }

    private static int CalculateTotalEnemyHealth(int greenHealth, int yellowHealth, int redHealth)
    {
        return greenHealth + yellowHealth + redHealth;
    }

    #endregion
}
