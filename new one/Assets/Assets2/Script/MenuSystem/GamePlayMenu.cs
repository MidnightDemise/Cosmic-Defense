using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayMenu : MonoBehaviour
{
    public void HandleQuitButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void HandleRestartButtonClick()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
