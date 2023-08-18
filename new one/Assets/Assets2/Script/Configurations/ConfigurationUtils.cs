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

    public static int CanonDamage
    {
        get { return LevelsUtils.CanonDamage; }
    }

    public static int MissileDamage
    {
        get { return LevelsUtils.MissileDamage; }
    }

    public static int MegaLaserDamage
    {
        get { return LevelsUtils.MegaLaserDamage; }
    }


    //for levels parameter


    public static int LevelOneGreenEnemyHealth
    {
    #region Green Enemy
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

    #region Canon Level Wise Damage

    public static int CanonLevelOneDamage
    {
        get { return configurationData.CanonLevelOneDamage; }
    }

    public static int CanonLevelTwoDamage
    {
        get { return configurationData.CanonLevelTwoDamage; }
    }


    public static int CanonLevelThreeDamage
    {
        get { return configurationData.CanonLevelThreeDamage; }
    }

    public static int CanonLevelFourDamage
    {
        get { return configurationData.CanonLevelFourDamage; }
    }

    public static int CanonLevelFiveDamage
    {
        get { return configurationData.CanonLevelFiveDamage; }
    }

    #endregion

    #region Missile Launcher Level Wise Damage

    public static int MissileLevelOneDamage
    {
        get { return configurationData.MissileLevelOneDamage; }
    }

    public static int MissileLevelTwoDamage
    {
        get { return configurationData.MissileLevelTwoDamage; }
    }

    public static int MissileLevelThreeDamage
    {
        get { return configurationData.MissileLevelThreeDamage; }
    }

    public static int MissileLevelFourDamage
    {
        get { return configurationData.MissileLevelFourDamage; }
    }

    public static int MissileLevelFiveDamage
    {
        get { return configurationData.MissileLevelFiveDamage; }
    }

    #endregion

    #region MegaLaser Level Wise Damage

    public static int MegaLaserLevelOneDamage
    {
        get { return configurationData.MegaLaserLevelOneDamage; }
    }

    public static int MegaLaserLevelTwoDamage
    {
        get { return configurationData.MegaLaserLevelTwoDamage; }
    }

    public static int MegaLaserLevelThreeDamage
    {
        get { return configurationData.MegaLaserLevelThreeDamage; }
    }

    #endregion


    #region Public Methods

    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }

    #endregion
}
