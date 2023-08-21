using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundManager : MonoBehaviour
{
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
}
