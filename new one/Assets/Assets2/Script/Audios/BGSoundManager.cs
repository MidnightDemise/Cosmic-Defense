using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource musicAudioSource;

    private void Awake()
    {
        if (!AudioManager.BGMusicInitialized)
        {
            
            DontDestroyOnLoad(gameObject);
            AudioManager.InitializeBGMusic();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MusicVolume(float volume)
    {
        musicAudioSource.volume = volume;
    }
}
