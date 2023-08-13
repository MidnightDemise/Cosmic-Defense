using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void HandlePlayButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Levels);
    }
}
