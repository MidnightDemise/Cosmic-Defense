using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Slider musicSlider;

    [SerializeField]
    Slider sfxSlider;

    public BGSoundManager bgSoundManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleBackButtonClicked()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        Time.timeScale = 1;
    }
    public void HandlePauseButtonClickEvent()
    {
        AudioManager.Play(ClipName.MenuButtonClick);
        Time.timeScale = 0;
    }

    public void MusicVolume()
    {
        
    }

    public void SfxVolume()
    {
        
    }
}
