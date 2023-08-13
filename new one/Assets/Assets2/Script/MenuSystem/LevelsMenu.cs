using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelsMenu : MonoBehaviour
{
    #region Fields

    GameStartedEvent gameStartedEvent;

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        gameStartedEvent = new GameStartedEvent();
        EventManager.AddGameStartedEventInvoker(this);
    }

    public void StartLevelOne()
    {
        gameStartedEvent.Invoke(Levels.LevelOne);
    }

    public void StartLevelTwo()
    {
        gameStartedEvent.Invoke(Levels.LevelTwo);
    }

    public void StartLevelThree()
    {
        gameStartedEvent.Invoke(Levels.LevelThree);
    }

    public void StartLevelFour()
    {
        gameStartedEvent.Invoke(Levels.LevelFour);
    }

    public void StartLevelFive()
    {
        gameStartedEvent.Invoke(Levels.LevelFive);
    }

    public void AddGameStartedEventListener(UnityAction<Levels> listener)
    {
        gameStartedEvent.AddListener(listener);
    }
}
