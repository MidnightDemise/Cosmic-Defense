using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public int levelToUnlock;
    int numberOfUnlockedLevels;

    bool audioPlayed = false;

    // Start is called before the first frame update
    void Start()
    {

        if (!audioPlayed)
        {
            if (LevelsUtils.LevelOne)
            {
                
                AudioManager.Play(ClipName.WaitTillLevel3);
            }
            else if (LevelsUtils.LevelTwo)
            {
                AudioManager.Play(ClipName.WrymDestroyHim);
            }
            else if (LevelsUtils.LevelThree)
            {
                AudioManager.Play(ClipName.CrimsonImCountingOnYou);
            }
            else if (LevelsUtils.LevelFour)
            {
                AudioManager.Play(ClipName.GalvaShockAttack);
            }
            else if (LevelsUtils.LevelFive)
            {
                AudioManager.Play(ClipName.Nooooo);
            }
        }
        else
        {
            AudioManager.Play(ClipName.UpgradeButtonClick);
            audioPlayed = true;
        }
        
        
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
