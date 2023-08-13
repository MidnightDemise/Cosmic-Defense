using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtils
{
    #region Fields

    static ConfigurationData configurationData;

    #endregion

    #region Properties

    public static int GreenEnemyHealth
    {
        get { return LevelsUtils.GreenEnemyHealth; }
    }

    public static int YellowEnemyHealth
    {
        get { return LevelsUtils.YellowEnemyHealth; }
    }

    public static int RedEnemyHealth
    {
        get { return LevelsUtils.RedEnemyHealth; }
    }


    //for levels parameter


    #region Green Enemy
    public static int LevelOneGreenEnemyHealth
    {
        get { return configurationData.LevelOneGreenEnemyHealth; }
    }

    public static int LevelTwoGreenEnemyHealth
    {
        get { return configurationData.LevelTwoGreenEnemyHealth; }
    }

    public static int LevelThreeGreenEnemyHealth
    {
        get { return configurationData.LevelThreeGreenEnemyHealth; }
    }

    public static int LevelFourGreenEnemyHealth
    {
        get { return configurationData.LevelFourGreenEnemyHealth; }

    }

    public static int LevelFiveGreenEnemyHealth
    {
        get { return configurationData.LevelFiveGreenEnemyHealth; }
    }

    #endregion

    #region Yellow Enemy

    public static int LevelOneYellowEnemyHealth
    {
        get { return configurationData.LevelOneYellowEnemyHealth; }
    }

    public static int LevelTwoYellowEnemyHealth
    {
        get { return configurationData.LevelTwoYellowEnemyHealth; }
    }

    public static int LevelThreeYellowEnemyHealth
    {
        get { return configurationData.LevelThreeYellowEnemyHealth; }
    }

    public static int LevelFourYellowEnemyHealth
    {
        get { return configurationData.LevelFourYellowEnemyHealth; }

    }

    public static int LevelFiveYellowEnemyHealth
    {
        get { return configurationData.LevelFiveYellowEnemyHealth; }
    }

    #endregion

    #region Red Enemy 

    public static int LevelOneRedEnemyHealth
    {
        get { return configurationData.LevelOneRedEnemyHealth; }
    }

    public static int LevelTwoRedEnemyHealth
    {
        get { return configurationData.LevelTwoRedEnemyHealth; }
    }

    public static int LevelThreeRedEnemyHealth
    {
        get { return configurationData.LevelThreeRedEnemyHealth; }
    }

    public static int LevelFourRedEnemyHealth
    {
        get { return configurationData.LevelFourRedEnemyHealth; }

    }

    public static int LevelFiveRedEnemyHealth
    {
        get { return configurationData.LevelFiveRedEnemyHealth; }
    }

    #endregion

    #endregion


    #region Public Methods

    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }

    #endregion
}
