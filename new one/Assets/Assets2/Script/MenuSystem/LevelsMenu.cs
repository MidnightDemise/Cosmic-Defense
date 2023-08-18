using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelsMenu : MonoBehaviour
{
    #region Fields

    GameStartedEvent gameStartedEvent;

    //handling bosses


    #endregion



    // Start is called before the first frame update
    void Start()
    {
        gameStartedEvent = new GameStartedEvent();
        EventManager.AddGameStartedEventInvoker(this);
    }

    public void StartLevelOne()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Levels.LevelOne);
    }

    public void StartLevelTwo()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Levels.LevelTwo);
    }

    public void StartLevelThree()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Levels.LevelThree);
    }

    public void StartLevelFour()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Levels.LevelFour);
    }

    public void StartLevelFive()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Levels.LevelFive);
    }

    public void HandleBackButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void AddGameStartedEventListener(UnityAction<Levels> listener)
    {
        gameStartedEvent.AddListener(listener);
    }
}
