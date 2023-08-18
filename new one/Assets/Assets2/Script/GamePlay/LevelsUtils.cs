using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelsUtils 
{
    #region Fields

    static Levels levels;
    static bool levelThree;
    static bool levelFour;
    static bool levelFive;

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

    public static int CanonDamage
    {
        get
        {
            switch (levels)
            {
                case Levels.LevelOne:
                    return ConfigurationUtils.CanonLevelOneDamage;
                case Levels.LevelTwo:
                    return ConfigurationUtils.CanonLevelTwoDamage;
                case Levels.LevelThree:
                    return ConfigurationUtils.CanonLevelThreeDamage;
                case Levels.LevelFour:
                    return ConfigurationUtils.CanonLevelFourDamage;
                case Levels.LevelFive:
                    return ConfigurationUtils.CanonLevelFiveDamage;
                default:
                    return ConfigurationUtils.CanonLevelOneDamage;
            }
        }
    }

    public static int MissileDamage
    {
        get
        {
            switch (levels)
            {
                case Levels.LevelOne:
                    return ConfigurationUtils.MissileLevelOneDamage;
                case Levels.LevelTwo:
                    return ConfigurationUtils.MissileLevelTwoDamage;
                case Levels.LevelThree:
                    return ConfigurationUtils.MissileLevelThreeDamage;
                case Levels.LevelFour:
                    return ConfigurationUtils.MissileLevelFourDamage;
                case Levels.LevelFive:
                    return ConfigurationUtils.MissileLevelFiveDamage;
                default:
                    return ConfigurationUtils.MissileLevelOneDamage;
            }
        }
    }

    public static int MegaLaserDamage
    {
        get
        {
            switch (levels)
            {
                case Levels.LevelOne:
                    return ConfigurationUtils.MegaLaserLevelOneDamage;
                case Levels.LevelTwo:
                    return ConfigurationUtils.MegaLaserLevelTwoDamage;
                case Levels.LevelThree:
                    return ConfigurationUtils.MegaLaserLevelThreeDamage;
                default:
                    return ConfigurationUtils.MegaLaserLevelOneDamage;
            }
        }
    }

    public static bool LevelThree
    {
        get
        {
            switch (levels)
            {
                case Levels.LevelThree:
                    return levelThree;              
                default: 
                    return levelThree;
            }
        }
    }

    public static bool LevelFour
    {
        get
        {
            switch(levels)
            {
                case Levels.LevelFour:
                    return levelFour;
                default:
                    return levelFour;
            }
        }
    }

    public static bool LevelFive
    {
        get
        {
            switch (levels)
            {
                case Levels.LevelFive:
                    return levelFive;
                default:
                    return levelFive;
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
        switch (levels)
        {
            case Levels.LevelThree:
                levelThree = true;
                levelFour = false;
                levelFive = false;
                break;
            case Levels.LevelFour:
                levelThree = false;
                levelFour = true;
                levelFive = false;
                break;
            case Levels.LevelFive:
                levelThree = false;
                levelFour = false;
                levelFive = true;
                break;
            default:
                levelThree = false;
                levelFour = false;
                levelFive = false;
                break;
        }

        SceneManager.LoadScene("GamePlay");
    }

    #endregion
}
