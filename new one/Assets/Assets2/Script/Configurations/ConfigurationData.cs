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

    // configuration for enemy 
    //int greenEnemyHealth = 50;
    //int yellowEnemyHealth = 75;
    //int redEnemyHealth = 110;
    //int levelOneGreenEnemyHealth = 50;
    //int levelTwoGreenEnemyHealth = 100;
    //int levelThreeGreenEnemyHealth = 220;
    //int levelFourGreenEnemyHealth = 400;
    //int levelFiveGreenEnemyHealth = 620;
    //int levelOneYellowEnemyHealth = 75;
    //int levelTwoYellowEnemyHealth = 175;
    //int levelThreeYellowEnemyHealth = 350;
    //int levelFourYellowEnemyHealth = 520;
    //int levelFiveYellowEnemyHealth = 650;
    //int levelOneRedEnemyHealth = 110;
    //int levelTwoRedEnemyHealth = 250;
    //int levelThreeRedEnemyHealth = 375;
    //int levelFourRedEnemyHealth = 550;
    //int levelFiveRedEnemyHealth = 675;
    //int canonLevelOneDamage = 50;
    //int canonLevelTwoDamage = 75;
    //int canonLevelThreeDamage = 100;
    //int canonLevelFourDamage = 125;
    //int canonLevelFiveDamage = 150;
    //int missileLauncherLevelOneDamage = 75;
    //int missileLauncherLevelTwoDamage = 125;
    //int missileLauncherLevelThreeDamage = 150;
    //int missileLauncherLevelFourDamage = 170;
    //int missileLauncherLevelFiveDamage = 175;
    //int laserLevelOneDamage = 1;
    //int laserLevelTwoDamage = 1;
    //int laserLevelThreeDamage = 1;
    //int laserLevelFourDamage = 1;
    //int laserLevelFiveDamage = 1;
    //int megaLaserLevelOneDamage = 120;
    //int megaLaserLevelTwoDamage = 220;
    //int megaLaserLevelThreeDamage = 320;
    //int levelOneGreenShipPoints = 25;
    //int levelTwoGreenShipPoints = 50;
    //int levelThreeGreenShipPoints = 75;
    //int levelFourGreenShipPoints = 100;
    //int levelFiveGreenShipPoints = 125;
    //int levelOneYellowShipPoints = 50;
    //int LevelTwoYellowShipPoints = 75;
    //int levelThreeYellowShipPoints = 100;
    //int levelFourYellowShipPoints = 125;
    //int levelFiveYellowShipPoints = 150;
    //int levelOneRedShipPoints = 125;
    //int levelTwoRedShipPoints = 150;
    //int levelThreeRedShipPoints = 175;
    //int levelFourRedShipPoints = 200;
    //int LevelFiveRedShipPoints = 225;
    //int CanonPrice = 150;
    //int GravityLauncherPrice = 250;
    //int LaserTowerPrice = 2000;
    //int missileLauncherPrice = 500;
    //int plasmaLauncherPrice = 1000;
    //int levelOneStartingScore = 200;
    //int levelTwoStartingScore = 500;
    //int levelThreeStartingScore = 1500;
    //int levelFourStartingScore = 3000;
    //int levelFiveStartingScore = 5000;
    

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
        values.Add(ConfigurationDataValueName.LevelTwoGreenEnemyHealth, 75);
        values.Add(ConfigurationDataValueName.LevelThreeGreenEnemyHealth, 100);
        values.Add(ConfigurationDataValueName.LevelFourGreenEnemyHealth, 125);
        values.Add(ConfigurationDataValueName.LevelFiveGreenEnemyHealth, 150);
        values.Add(ConfigurationDataValueName.LevelOneYellowEnemyHealth, 75);
        values.Add(ConfigurationDataValueName.LevelTwoYellowEnemyHealth, 100);
        values.Add(ConfigurationDataValueName.LevelThreeYellowEnemyHealth, 125);
        values.Add(ConfigurationDataValueName.LevelFourYellowEnemyHealth, 150);
        values.Add(ConfigurationDataValueName.LevelFiveYellowEnemyHealth, 175);
        values.Add(ConfigurationDataValueName.LevelOneRedEnemyHealth, 110);
        values.Add(ConfigurationDataValueName.LevelTwoRedEnemyHealth, 160);
        values.Add(ConfigurationDataValueName.LevelThreeRedEnemyHealth, 210);
        values.Add(ConfigurationDataValueName.LevelFourRedEnemyHealth, 260);
        values.Add(ConfigurationDataValueName.LevelFiveRedEnemyHealth, 310);
        values.Add(ConfigurationDataValueName.CanonLevelOneDamage, 50);
        values.Add(ConfigurationDataValueName.CanonLevelTwoDamage, 75);
        values.Add(ConfigurationDataValueName.CanonLevelThreeDamage, 100);
        values.Add(ConfigurationDataValueName.CanonLevelFourDamage, 125);
        values.Add(ConfigurationDataValueName.CanonLevelFiveDamage, 150);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelOneDamage, 40);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelTwoDamage, 70);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelThreeDamage, 90);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelFourDamage, 100);
        values.Add(ConfigurationDataValueName.MissileLauncherLevelFiveDamage, 130);
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
