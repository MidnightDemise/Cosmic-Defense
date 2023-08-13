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

    #endregion

    #region Levels Parameter

    public static void AddGameStartedEventInvoker(LevelsMenu invoker)
    {
        gameStartedEventInvoker.Add(invoker);
        foreach(UnityAction<Levels> listener in gameStartedEventListener)
        {
            invoker.AddGameStartedEventListener(listener);
        }
    }

    public static void AddGameStartedEventListener(UnityAction<Levels> listener)
    {
        gameStartedEventListener.Add(listener);
        foreach(LevelsMenu invoker in gameStartedEventInvoker)
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
        foreach(UnityAction listener in levelCompleteEventListener)
        {
            invoker.AddLevelCompleteEventListener(listener);
        }
    }

    public static void AddLevelCompleteEventListener(UnityAction listener)
    {
        levelCompleteEventListener.Add(listener);
        foreach(EnemyManager invoker in levelCompleteEventInvoker)
        {
            invoker.AddLevelCompleteEventListener(listener);
        }
    }

    public static void RemoveLevelCompleteEventInvoker(EnemyManager invoker)
    {
        levelCompleteEventInvoker.Remove(invoker);
    }

    #endregion
}
