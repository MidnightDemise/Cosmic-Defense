using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields

    //list for level parameter invokers and listeners
    static List<LevelsMenu> gameStartedEventInvoker = new List<LevelsMenu>();
    static List<UnityAction<Levels>> gameStartedEventListener = new List<UnityAction<Levels>>();

    //list for level complete invokers and listeners
    static List<EnemyManager> levelCompleteEventInvoker = new List<EnemyManager>();
    static List<UnityAction> levelCompleteEventListener = new List<UnityAction>();

    //list for army boss destroyed event
    static List<Boss1Script> armyBossDestroyedEventInvoker = new List<Boss1Script>();
    static List<UnityAction> armyBossDestroyedEventListener = new List<UnityAction>();

    //list for laser boss destroyed event
    static List<LaserBossScript> laserBossDestroyedEventInvoker = new List<LaserBossScript>();
    static List<UnityAction> laserBossDestroyedEventListener = new List<UnityAction>();

    //list for fish boss destroyed event
    static List<ElectricBossScript> fishBossDestroyedEventInvoker = new List<ElectricBossScript>();
    static List<UnityAction> fishBossDestroyedEventListener = new List<UnityAction>();

    //list for level failed event
    static List<SwipeEarth> levelFailedEventInvoker = new List<SwipeEarth>();
    static List<UnityAction> levelFailedEventListener = new List<UnityAction>();

    //list for points added event 
    
    // green ship 
    static List<GreenSip> greenShipPointsAddedEventInvoker = new List<GreenSip>();
    static List<UnityAction<int>> greenShipPointsAddedEventListener = new List<UnityAction<int>>();

    // yellow ship
    static List<yelloShip> yellowShipPointsAddedEventInvoker = new List<yelloShip>();
    static List<UnityAction<int>> yellowShipPointsAddedEventListener = new List<UnityAction<int>>();

    // red ship 
    static List<RedShip> redShipPointsAddedEventInvoker = new List<RedShip>();
    static List<UnityAction<int>> redShipPointsAddedEventListener = new List<UnityAction<int>>();

    // cost handling
    static List<BuildManager> costDeductedEventInvoker = new List<BuildManager>();
    static List<UnityAction<int>> costDeductedEventListener = new List<UnityAction<int>>();


    #endregion

    #region Levels Parameter

    public static void AddGameStartedEventInvoker(LevelsMenu invoker)
    {
        gameStartedEventInvoker.Add(invoker);
        foreach (UnityAction<Levels> listener in gameStartedEventListener)
        {
            invoker.AddGameStartedEventListener(listener);
        }
    }

    public static void AddGameStartedEventListener(UnityAction<Levels> listener)
    {
        gameStartedEventListener.Add(listener);
        foreach (LevelsMenu invoker in gameStartedEventInvoker)
        {
            invoker.AddGameStartedEventListener(listener);
        }
    }

    public static void RemoveGameStartedEventInvoker(LevelsMenu invoker)
    {
        gameStartedEventInvoker.Remove(invoker);
    }

    #endregion

    #region Level Complete

    public static void AddLevelCompleteEventInvoker(EnemyManager invoker)
    {
        levelCompleteEventInvoker.Add(invoker);
        foreach (UnityAction listener in levelCompleteEventListener)
        {
            invoker.AddLevelCompleteEventListener(listener);
        }
    }

    public static void AddLevelCompleteEventListener(UnityAction listener)
    {
        levelCompleteEventListener.Add(listener);
        foreach (EnemyManager invoker in levelCompleteEventInvoker)
        {
            invoker.AddLevelCompleteEventListener(listener);
        }
    }

    public static void RemoveLevelCompleteEventInvoker(EnemyManager invoker)
    {
        levelCompleteEventInvoker.Remove(invoker);
    }

    #endregion

    #region Army Boss Destroyed

    public static void AddArmyBossDestroyedEventInvoker(Boss1Script invoker)
    {
        armyBossDestroyedEventInvoker.Add(invoker);
        foreach (UnityAction listener in armyBossDestroyedEventListener)
        {
            invoker.AddArmyBossDestroyedEventListener(listener);
        }

    }

    public static void AddArmyBossDestroyedEventListener(UnityAction listener)
    {
        armyBossDestroyedEventListener.Add(listener);
        foreach (Boss1Script invoker in armyBossDestroyedEventInvoker)
        {
            invoker.AddArmyBossDestroyedEventListener(listener);
        }
    }

    #endregion

    #region Laser Boss Destroyed

    public static void AddLaserBossDestroyedEventInvoker(LaserBossScript invoker)
    {
        laserBossDestroyedEventInvoker.Add(invoker);
        foreach (UnityAction listener in laserBossDestroyedEventListener)
        {
            invoker.AddLaserBossDestroyedEventListener(listener);
        }

    }

    public static void AddLaserBossDestroyedEventListener(UnityAction listener)
    {
        laserBossDestroyedEventListener.Add(listener);
        foreach (LaserBossScript invoker in laserBossDestroyedEventInvoker)
        {
            invoker.AddLaserBossDestroyedEventListener(listener);
        }
    }

    #endregion

    #region Fish Boss Destroyed

    public static void AddFishBossDestroyedEventInvoker(ElectricBossScript invoker)
    {
        fishBossDestroyedEventInvoker.Add(invoker);
        foreach (UnityAction listener in fishBossDestroyedEventListener)
        {
            invoker.AddFishBossDestroyedEventListener(listener);
        }
    }

    public static void AddFishBossDestroyedEventListener(UnityAction listener)
    {
        fishBossDestroyedEventListener.Add(listener);
        foreach (ElectricBossScript invoker in fishBossDestroyedEventInvoker)
        {
            invoker.AddFishBossDestroyedEventListener(listener);
        }
    }

    #endregion

    #region Level Failed Event

    public static void AddLevelFailedEventInvoker(SwipeEarth invoker)
    {
        levelFailedEventInvoker.Add(invoker);
        foreach(UnityAction listener in levelFailedEventListener)
        {
            invoker.AddLevelFailedEventListener(listener);
        }
    }

    public static void AddLevelFailedEventListener(UnityAction listener)
    {
        levelFailedEventListener.Add(listener);
        foreach(SwipeEarth invoker in levelFailedEventInvoker)
        {
            invoker.AddLevelFailedEventListener(listener);
        }
    }

    #endregion

    #region Green Ship Points Added Event 

    public static void AddGreenShipPointsAddedEventInvoker(GreenSip invoker)
    {
        greenShipPointsAddedEventInvoker.Add(invoker);
        foreach(UnityAction<int> listener in greenShipPointsAddedEventListener)
        {
            invoker.AddGreenShipPointsAddedEventListener(listener);
        }
    }

    public static void AddGreenShipPointsAddedEventListener(UnityAction<int> listener)
    {
        greenShipPointsAddedEventListener.Add(listener);
        foreach(GreenSip invoker in greenShipPointsAddedEventInvoker)
        {
            invoker.AddGreenShipPointsAddedEventListener(listener);
        }
    }

    public static void RemoveGreenShipPointsAddedEventInvoker(GreenSip invoker)
    {
        greenShipPointsAddedEventInvoker.Remove(invoker);
    }

    #endregion

    #region Yellow Ship Points Added Event 


    public static void AddYellowShipPointsAddedEventInvoker(yelloShip invoker)
    {
        yellowShipPointsAddedEventInvoker.Add(invoker);
        foreach(UnityAction<int> listener in yellowShipPointsAddedEventListener)
        {
            invoker.AddYellowShipPointsAddedEventListener(listener);
        }
    }

    public static void AddYellowShipPointsAddedEventListener(UnityAction<int> listener)
    {
        yellowShipPointsAddedEventListener.Add(listener);
        foreach(yelloShip invoker in yellowShipPointsAddedEventInvoker)
        {
            invoker.AddYellowShipPointsAddedEventListener(listener);
        }
    }

    public static void RemoveYellowShipPointsAddedEventInvoker(yelloShip invoker)
    {
        yellowShipPointsAddedEventInvoker.Remove(invoker);
    }

    #endregion

    #region Red Ship Points Added Event

    public static void AddRedShipPointsAddedEventInvoker(RedShip invoker)
    {
        redShipPointsAddedEventInvoker.Add(invoker);
        foreach(UnityAction<int> listener in redShipPointsAddedEventListener)
        {
            invoker.AddRedShipPointsAddedEventListener (listener);
        }
    }

    public static void AddRedShipPointsAddedEventListener(UnityAction<int> listener)
    {
        redShipPointsAddedEventListener.Add(listener);
        foreach(RedShip invoker in redShipPointsAddedEventInvoker)
        {
            invoker.AddRedShipPointsAddedEventListener(listener);
        }
    }

    public static void RemoveRedShipPointsAddedEventInvoker(RedShip invoker)
    {
        redShipPointsAddedEventInvoker.Remove(invoker);
    }

    #endregion

    #region Cost Deducted Event

    public static void AddCostDeductedEventInvoker(BuildManager invoker)
    {
        costDeductedEventInvoker.Add(invoker);
        foreach(UnityAction<int> listener in costDeductedEventListener)
        {
            invoker.AddCostDeductedEventListener(listener);
        }
    }

    public static void AddCostDeductedEventListener(UnityAction<int> listener)
    {
        costDeductedEventListener.Add(listener);
        foreach(BuildManager invoker in costDeductedEventInvoker)
        {
            invoker.AddCostDeductedEventListener (listener);
        }
    }

    #endregion
}
