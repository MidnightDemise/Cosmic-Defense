using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        Application.Quit();
    }

    public void HandlePlayButtonOnClickEvent()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Levels);
    }

    public void HandleStagesButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Stages);
    }

    public void HandleInfoButtonClick()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Info);
        
    }

    public void HandleWeaponsButtonClick()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Weapons);
    }
}
