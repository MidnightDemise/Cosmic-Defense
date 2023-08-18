using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch(name)
        {
            case MenuName.Levels:
                SceneManager.LoadScene("LevelsMenu");
                break;

            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.LevelCompleteScreen:
                SceneManager.LoadScene("LevelCompleteScreen");
                break;
            case MenuName.LevelFailedScreen:
                SceneManager.LoadScene("LevelFailedScreen");
                break;
            case MenuName.Stages:
                SceneManager.LoadScene("Stages");
                break;
        }
    }
}
