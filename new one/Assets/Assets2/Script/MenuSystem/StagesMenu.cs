using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagesMenu : MonoBehaviour
{
    public void HandleReturnButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
