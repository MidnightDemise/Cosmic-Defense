using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLost : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Play(ClipName.Destroyed);
    }

    public void HandleRetryButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Levels);
    }

    public void HandleQuitButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
