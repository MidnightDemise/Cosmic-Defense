using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void HandleHomeButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void HandleNextButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        Time .timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Levels);
    }
}
