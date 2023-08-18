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
    int enemyHealth = 50;
    int levelOneEnemyHealth = 60;
    int levelTwoEnemyHealth = 70;
    int levelThreeEnemyHealth = 80;
    int levelFourEnemyHealth = 90;
    int levelFiveEnemyHealth = 100;

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
        values.Add(ConfigurationDataValueName.MegaLaserLevelOneDamage, 120);
        values.Add(ConfigurationDataValueName.MegaLaserLevelTwoDamage, 220);
        values.Add(ConfigurationDataValueName.MegaLaserLevelThreeDamage, 320);

    }

    #endregion
}
