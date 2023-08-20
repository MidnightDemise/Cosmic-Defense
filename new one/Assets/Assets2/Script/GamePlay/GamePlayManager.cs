using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddLevelCompleteEventListener(HandleWaveSurvivedEvent);

        EventManager.AddArmyBossDestroyedEventListener(HandleWaveSurvivedEvent);
        
        EventManager.AddLaserBossDestroyedEventListener(HandleWaveSurvivedEvent);
        
        EventManager.AddFishBossDestroyedEventListener(HandleWaveSurvivedEvent);

        EventManager.AddLevelFailedEventListener(HandleLevelFailedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleWaveSurvivedEvent()
    {
        EndLevel();
    }

    public void HandleLevelFailedEvent()
    {
        MenuManager.GoToMenu(MenuName.LevelFailedScreen);
    }

    public void EndLevel()
    {
        MenuManager.GoToMenu(MenuName.LevelCompleteScreen);
    }
}
