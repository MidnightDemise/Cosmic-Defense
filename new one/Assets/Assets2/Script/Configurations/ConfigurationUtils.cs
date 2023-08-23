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

    public static int LaserDamage
    {
        get { return LevelsUtils.LaserDamage; }
    }

    public static int MegaLaserDamage
    {
        get { return LevelsUtils.MegaLaserDamage; }
    }


    public static int GreenShipPoints
    {
        get { return LevelsUtils.GreenShipPoints; }
    }

    public static int YellowShipPoints
    {
        get { return LevelsUtils.YellowShipPoints; }
    }

    public static int RedShipPoints
    {
        get { return LevelsUtils.RedShipPoints; }
    }

    public static int StartingScore
    {
        get { return LevelsUtils.LevelStartingScore; }
    }


    #region Defence Towers Price

    public static int CanonPrice
    {
        get { return configurationData.CanonPrice; }
    }

    public static int GravityLauncherPrice
    {
        get { return configurationData.GravityLauncherPrice; }
    }

    public static int LaserTowerPrice
    {
        get { return configurationData.LaserTowerPrice; }
    }

    public static int MissileLauncherPrice
    {
        get { return configurationData.MissileLauncherPrice; }
    }

    public static int PlasmaLauncherPrice
    {
        get { return configurationData.PlasmaLauncherPrice; }
    }

    #endregion

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

    #region Laser Level Wise Damage

    public static int LaserLevelOneDamage
    {
        get { return configurationData.LaserLevelOneDamage; } 
    }

    public static int LaserLevelTwoDamage
    {
        get { return configurationData.LaserLevelTwoDamage; }
    }

    public static int LaserLevelThreeDamage
    {
        get { return configurationData.LaserLevelThreeDamage; }
    }

    public static int LaserLevelFourDamage
    {
        get { return configurationData.LaserLevelFourDamage; }
    }


    public static int LaserLevelFiveDamage
    {
        get { return configurationData.LaserLevelFiveDamage; }
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

    public static int MegaLaserLevelFourDamage
    {
        get { return configurationData.MegaLaserLevelThreeDamage; }
    }

    public static int MegaLaserLevelFiveDamage
    {
        get { return configurationData.MegaLaserLevelThreeDamage; }
    }

    #endregion

    #region Green Ship Level wise Points

    public static int LevelOneGreenShipPoints
    {
        get { return configurationData.LevelOneGreenShipPoints; }
    }

    public static int LevelTwoGreenShipPoints
    {
        get { return configurationData.LevelTwoGreenShipPoints; }
    }

    public static int LevelThreeGreenShipPoints
    {
        get { return configurationData.LevelThreeGreenShipPoints; }
    }

    public static int LevelFourGreenShipPoints
    {
        get { return configurationData.LevelFourGreenShipPoints; }
    }

    public static int LevelFiveGreenShipPoints
    {
        get { return configurationData.LevelFiveGreenShipPoints; }
    }

    #endregion

    #region Yellow Ship Level Wise Points

    public static int LevelOneYellowShipPoints
    {
        get { return configurationData.LevelOneYellowShipPoints; }
    }

    public static int LevelTwoYellowShipPoints
    {
        get { return configurationData.LevelTwoYellowShipPoints; }
    }

    public static int LevelThreeYellowShipPoints
    {
        get { return configurationData.LevelThreeYellowShipPoints; }
    }

    public static int LevelFourYellowShipPoints
    {
        get { return configurationData.LevelFourYellowShipPoints; }
    }

    public static int LevelFiveYellowShipPoints
    {
        get { return configurationData.LevelFiveYellowShipPoints; }
    }

    #endregion

    #region Red Ship Level Wise Points

    public static int LevelOneRedShipPoints
    {
        get { return configurationData.LevelOneRedShipPoints; }
    }

    public static int LevelTwoRedShipPoints
    {
        get { return configurationData.LevelTwoRedShipPoints; }
    }

    public static int LevelThreeRedShipPoints
    {
        get { return configurationData.LevelThreeRedShipPoints; }
    }

    public static int LevelFourRedShipPoints
    {
        get { return configurationData.LevelFourRedShipPoints; }
    }

    public static int LevelFiveRedShipPoints
    {
        get { return configurationData.LevelFiveRedShipPoints; }
    }

    #endregion

    #region Level Wise Starting Points

    public static int LevelOneStartingScore
    {
        get { return configurationData.LevelOneStartingScore; }
    }

    public static int LevelTwoStartingScore
    {
        get { return configurationData.LevelTwoStartingScore; }
    }

    public static int LevelThreeStartingScore
    {
        get { return configurationData.LevelThreeStartingScore; }
    }

    public static int LevelFourStartingScore
    {
        get { return configurationData.LevelFourStartingScore; }
    }

    public static int LevelFiveStartingScore
    {
        get { return configurationData.LevelFiveStartingScore; }
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
