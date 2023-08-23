using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public int levelToUnlock;
    int numberOfUnlockedLevels;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Play(ClipName.UpgradeButtonClick);
        
    }

    public void HandleHomeButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void HandleNextButtonClicked()
    {
        numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");

        if (numberOfUnlockedLevels <= levelToUnlock)
        {
            PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels + 1);
            Debug.Log(numberOfUnlockedLevels);
        }

        AudioManager.Play(ClipName.MenuButtonClick);
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Levels);
    }
}
