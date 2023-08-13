using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioSource : MonoBehaviour
{
    private void Awake()
    {
        if (!AudioManager.Initialized)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Inialize(audioSource);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
