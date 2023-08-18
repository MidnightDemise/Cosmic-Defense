using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
