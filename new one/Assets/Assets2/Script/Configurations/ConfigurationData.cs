using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ConfigurationData
{
    #region Fields
    
    //config data file name
    const string ConfigurationDataFileName = "ConfigurationData.csv";

    Dictionary<ConfigurationDataValueName, int> values =
        new Dictionary<ConfigurationDataValueName, int>();

    
    

    #endregion

    #region Properties
    /// <summary>
    /// returns normal enemy health
    /// </summary>
    public int GreenEnemyHealth 
    {
        get { return values[ConfigurationDataValueName.GreenEnemyHealth]; }
    }

    public int YellowEnemyHealth
    {
        get { return values[ConfigurationDataValueName.YellowEnemyHealth]; }
    }

    public int RedEnemyHealth
    {
        get { return values[ConfigurationDataValueName.RedEnemyHealth]; }
    }

    public int CanonDamage
    {
        get { return values[ConfigurationDataValueName.CanonLevelOneDamage]; }
    }

    public int MissileLauncherDamage
    {
        get { return values[ConfigurationDataValueName.MissileLauncherLevelOneDamage]; }
    }

    public int MegaLaserDamage
    {
        get { return values[ConfigurationDataValueName.MegaLaserLevelOneDamage]; }
    }


    #region Green Enemy Level wise Health

    /// <summary>
    /// Returns level one green enemy health
    /// </summary>
    public int LevelOneGreenEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelOneGreenEnemyHealth]; }
    }

    public int LevelTwoGreenEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelTwoGreenEnemyHealth]; }
    }

    public int LevelThreeGreenEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelThreeGreenEnemyHealth]; }
    }

    public int LevelFourGreenEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelFourGreenEnemyHealth]; }
    }

    public int LevelFiveGreenEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelFiveGreenEnemyHealth]; }
    }

    #endregion

    #region Yellow Enemy Level wise Health

    /// <summary>
    /// Returns level two health
    /// </summary>
    public int LevelOneYellowEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelOneYellowEnemyHealth]; }
    }

    public int LevelTwoYellowEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelTwoYellowEnemyHealth]; }
    }

    public int LevelThreeYellowEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelThreeYellowEnemyHealth]; }
    }

    public int LevelFourYellowEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelFourYellowEnemyHealth]; }
    }

    public int LevelFiveYellowEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelFiveYellowEnemyHealth]; }
    }

    #endregion

    #region Red Enemy Level wise Health

    /// <summary>
    /// Returns level three health
    /// </summary>
    public int LevelOneRedEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelOneRedEnemyHealth]; }
    }

    public int LevelTwoRedEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelTwoRedEnemyHealth]; }
    }

    public int LevelThreeRedEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelThreeRedEnemyHealth]; }
    }

    public int LevelFourRedEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelFourRedEnemyHealth]; }
    }

    public int LevelFiveRedEnemyHealth
    {
        get { return values[ConfigurationDataValueName.LevelFiveRedEnemyHealth]; }
    }

    #endregion

    #region Canon Level Wise Damage

    public int CanonLevelOneDamage
    {
        get { return values[ConfigurationDataValueName.CanonLevelOneDamage]; }
    }

    public int CanonLevelTwoDamage
    {
        get { return values[ConfigurationDataValueName.CanonLevelTwoDamage]; }
    }

    public int CanonLevelThreeDamage
    {
        get { return values[ConfigurationDataValueName.CanonLevelThreeDamage]; }
    }

    public int CanonLevelFourDamage
    {
        get { return values[ConfigurationDataValueName.CanonLevelFourDamage]; }

    }

    public int CanonLevelFiveDamage
    {
        get { return values[ConfigurationDataValueName.CanonLevelFiveDamage]; }
    }

    #endregion

    #region Missile Launcher Level Wise Damage

    public int MissileLevelOneDamage
    {
        get { return values[ConfigurationDataValueName.MissileLauncherLevelOneDamage]; }
    }

    public int MissileLevelTwoDamage
    {
        get { return values[ConfigurationDataValueName.MissileLauncherLevelTwoDamage]; }
    }

    public int MissileLevelThreeDamage
    {
        get { return values[ConfigurationDataValueName.MissileLauncherLevelThreeDamage]; }
    }

    public int MissileLevelFourDamage
    {
        get { return values[ConfigurationDataValueName.MissileLauncherLevelFourDamage]; }
    }

    public int MissileLevelFiveDamage
    {
        get { return values[ConfigurationDataValueName.MissileLauncherLevelFiveDamage]; }
    }

    #endregion

    #region Laser Level Wise Damage

    public int LaserLevelOneDamage
    {
        get { return values[ConfigurationDataValueName.LaserLevelOneDamage]; }
    }

    public int LaserLevelTwoDamage
    {
        get { return values[ConfigurationDataValueName.LaserLevelTwoDamage]; }
    }

    public int LaserLevelThreeDamage
    {
        get { return values[ConfigurationDataValueName.LaserLevelThreeDamage]; }
    }

    public int LaserLevelFourDamage
    {
        get { return values[ConfigurationDataValueName.LaserLevelFourDamage]; }
    }

    public int LaserLevelFiveDamage
    {
        get { return values[ConfigurationDataValueName.LaserLevelFiveDamage]; }
    }

    #endregion

    #region MegaLaser Level Wise Damage

    public int MegaLaserLevelOneDamage
    {
        get { return values[ConfigurationDataValueName.MegaLaserLevelOneDamage]; }
    }

    public int MegaLaserLevelTwoDamage
    {
        get { return values[ConfigurationDataValueName.MegaLaserLevelTwoDamage]; }
    }

    public int MegaLaserLevelThreeDamage
    {
        get { return values[ConfigurationDataValueName.MegaLaserLevelThreeDamage]; }
    }


    #endregion

    #region Green Ship Level Wise Points

    public int LevelOneGreenShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelOneGreenShipPoints]; }
    }

    public int LevelTwoGreenShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelTwoGreenShipPoints]; }
    }

    public int LevelThreeGreenShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelThreeGreenShipPoints]; }
    }

    public int LevelFourGreenShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelFourGreenShipPoints]; }
    }

    public int LevelFiveGreenShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelFiveGreenShipPoints]; }
    }

    #endregion

    #region Yellow Ship Level Wise Points

    public int LevelOneYellowShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelOneYellowShipPoints]; }
    }

    public int LevelTwoYellowShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelTwoYellowShipPoints]; }
    }

    public int LevelThreeYellowShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelThreeYellowShipPoints]; }
    }

    public int LevelFourYellowShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelFourYellowShipPoints]; }
    }

    public int LevelFiveYellowShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelFiveYellowShipPoints]; }
    }

    #endregion

    #region Red Ship Level Wise Points

    public int LevelOneRedShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelOneRedShipPoints]; }
    }

    public int LevelTwoRedShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelTwoRedShipPoints]; }
    }

    public int LevelThreeRedShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelThreeRedShipPoints]; }
    }

    public int LevelFourRedShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelFourRedShipPoints]; }
    }

    public int LevelFiveRedShipPoints
    {
        get { return values[ConfigurationDataValueName.LevelFiveRedShipPoints]; }
    }

    #endregion

    #region Level Wise Starting Scores

    public int LevelOneStartingScore
    {
        get { return values[ConfigurationDataValueName.LevelOneStartingScore]; }
    }

    public int LevelTwoStartingScore
    {
        get { return values[ConfigurationDataValueName.LevelTwoStartingScore]; }
    }

    public int LevelThreeStartingScore
    {
        get { return values[ConfigurationDataValueName.LevelThreeStartingScore]; }
    }

    public int LevelFourStartingScore
    {
        get { return values[ConfigurationDataValueName.LevelFourStartingScore]; }
    }

    public int LevelFiveStartingScore
    {
        get { return values[ConfigurationDataValueName.LevelFiveStartingScore]; }
    }

    #endregion

    #region Defence Tower Prices

    public int CanonPrice
    {
        get { return values[ConfigurationDataValueName.CanonPrice]; }
    }

    public int GravityLauncherPrice
    {
        get { return values[ConfigurationDataValueName.GravityLauncherPrice]; }
    }

    public int LaserTowerPrice
    {
        get { return values[ConfigurationDataValueName.LaserTowerPrice]; }
    }

    public int MissileLauncherPrice
    {
        get { return values[ConfigurationDataValueName.MissileLauncherPrice]; }
    }

    public int PlasmaLauncherPrice
    {
        get { return values[ConfigurationDataValueName.PlasmaLauncherPrice]; }
    }

    #endregion

    #endregion

    #region Constructor

    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            //populate values
            string currentLine = input.ReadLine();
            while (currentLine != null)
            {
                string[] tokens = currentLine.Split(',');
                ConfigurationDataValueName valueName =
                    (ConfigurationDataValueName)Enum.Parse(
                        typeof(ConfigurationDataValueName), tokens[0]);
                values.Add(valueName, int.Parse(tokens[1]));
                currentLine = input.ReadLine();
            }
        }

        catch (Exception ex)
        {
            SetDefaultValues();
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    void SetDefaultValues()
    {
        values.Clear();
        values.Add(ConfigurationDataValueName.GreenEnemyHealth, 50);
        values.Add(ConfigurationDataValueName.YellowEnemyHealth, 75);
        values.Add(ConfigurationDataValueName.RedEnemyHealth, 110);
        values.Add(ConfigurationDataValueName.LevelOneGreenEnemyHealth, 50);
        values.Add(ConfigurationDataValueName.LevelTwoGreenEnemyHealth, 100);
        values.Add(ConfigurationDataValueName.LevelThreeGreenEnemyHealth, 220);
        values.Add(ConfigurationDataValueName.LevelFourGreenEnemyHealth, 400);
        values.Add(ConfigurationDataValueName.LevelFiveGreenEnemyHealth, 620);
        values.Add(ConfigurationDataValueName.LevelOneYellowEnemyHealth, 75);
        values.Add(ConfigurationDataValueName.LevelTwoYellowEnemyHealth, 175);
        values.Add(ConfigurationDataValueName.LevelThreeYellowEnemyHealth, 350);
        values.Add(ConfigurationDataValueName.LevelFourYellowEnemyHealth, 520);
        values.Add(ConfigurationDataValueName.LevelFiveYellowEnemyHealth, 650);
        values.Add(ConfigurationDataValueName.LevelOneRedEnemyHealth, 110);
        values.Add(ConfigurationDataValueName.LevelTwoRedEnemyHealth, 250);
        values.Add(ConfigurationDataValueName.LevelThreeRedEnemyHealth, 375);
        values.Add(ConfigurationDataValueName.LevelFourRedEnemyHealth, 550);
        values.Add(ConfigurationDataValueName.LevelFiveRedEnemyHealth, 675);
        values.Add(ConfigurationDataValueName.CanonLevelOneDamage, 50);
        values.Add(ConfigurationDataValueName.CanonLevelTwoDamage, 75);
        values.Add(ConfigurationDataValueName.CanonLevelThreeDamage, 100);
        values.Add(ConfigurationDataValueName.CanonLevelFourDamage, 125);
        values.Add(ConfigurationDataValueName.CanonLevelFiveDamage, 150);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelOneDamage, 75);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelTwoDamage, 125);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelThreeDamage, 150);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelFourDamage, 170);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelFiveDamage, 175);
        values.Add(ConfigurationDataValueName.LaserLevelOneDamage, 1);
        values.Add(ConfigurationDataValueName.LaserLevelTwoDamage, 1);
        values.Add(ConfigurationDataValueName.LaserLevelThreeDamage, 1);
        values.Add(ConfigurationDataValueName.LaserLevelFourDamage, 1);
        values.Add(ConfigurationDataValueName.LaserLevelFiveDamage, 1);
        values.Add(ConfigurationDataValueName.MegaLaserLevelOneDamage, 120);
        values.Add(ConfigurationDataValueName.MegaLaserLevelTwoDamage, 220);
        values.Add(ConfigurationDataValueName.MegaLaserLevelThreeDamage, 320);
        values.Add(ConfigurationDataValueName.LevelOneGreenShipPoints, 25);
        values.Add(ConfigurationDataValueName.LevelTwoGreenShipPoints, 50);
        values.Add(ConfigurationDataValueName.LevelThreeGreenShipPoints, 75);
        values.Add(ConfigurationDataValueName.LevelFourGreenShipPoints, 100);
        values.Add(ConfigurationDataValueName.LevelFiveGreenShipPoints, 125);
        values.Add(ConfigurationDataValueName.LevelOneYellowShipPoints, 50);
        values.Add(ConfigurationDataValueName.LevelTwoYellowShipPoints, 75);
        values.Add(ConfigurationDataValueName.LevelThreeYellowShipPoints, 100);
        values.Add(ConfigurationDataValueName.LevelFourYellowShipPoints, 125);
        values.Add(ConfigurationDataValueName.LevelFiveYellowShipPoints, 150);
        values.Add(ConfigurationDataValueName.LevelOneRedShipPoints, 125);
        values.Add(ConfigurationDataValueName.LevelTwoRedShipPoints, 150);
        values.Add(ConfigurationDataValueName.LevelThreeRedShipPoints, 175);
        values.Add(ConfigurationDataValueName.LevelFourRedShipPoints, 200);
        values.Add(ConfigurationDataValueName.LevelFiveRedShipPoints, 225);
        values.Add(ConfigurationDataValueName.CanonPrice, 150);
        values.Add(ConfigurationDataValueName.GravityLauncherPrice, 250);
        values.Add(ConfigurationDataValueName.LaserTowerPrice, 2000);
        values.Add(ConfigurationDataValueName.MissileLauncherPrice, 500);
        values.Add(ConfigurationDataValueName.PlasmaLauncherPrice, 1000);
        values.Add(ConfigurationDataValueName.LevelOneStartingScore, 200);
        values.Add(ConfigurationDataValueName.LevelTwoStartingScore, 500);
        values.Add(ConfigurationDataValueName.LevelThreeStartingScore, 1500);
        values.Add(ConfigurationDataValueName.LevelFourStartingScore, 3000);
        values.Add(ConfigurationDataValueName.LevelFiveStartingScore, 5000);

    }

    #endregion
}
