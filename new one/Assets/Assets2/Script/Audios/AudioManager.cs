using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public static class AudioManager
{
    #region Fields
    static bool initialized = false;

    static AudioSource audioSource;
    static Dictionary<ClipName, AudioClip> audioClips = 
        new Dictionary<ClipName, AudioClip>();
    #endregion

    #region Properties

    public static bool Initialized
    {
        get { return initialized; }

    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds all the audio clips
    /// </summary>
    /// <param name="source"></param>
    public static void Inialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(ClipName.MenuButtonClick, Resources.Load<AudioClip>("MenuButtonClick"));
        audioClips.Add(ClipName.UpgradeButtonClick, Resources.Load<AudioClip>("UpgradeButtonClick"));
        audioClips.Add(ClipName.CanonShot, Resources.Load<AudioClip>("CanonShot"));
        audioClips.Add(ClipName.LaserShot, Resources.Load<AudioClip>("LaserShot"));
        audioClips.Add(ClipName.MegaLaserShot, Resources.Load<AudioClip>("MegaLaserShot"));
        audioClips.Add(ClipName.MissileLauncher, Resources.Load<AudioClip>("MissileLauncherShot"));
        audioClips.Add(ClipName.GravityLauncherShot, Resources.Load<AudioClip>("GravityLauncherShot"));
        audioClips.Add(ClipName.EnemyExplode, Resources.Load<AudioClip>("EnemyExplode"));
        audioClips.Add(ClipName.BossEnemyShot, Resources.Load<AudioClip>("BossEnemyShot"));

    }

    public static void Play(ClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }


    #endregion
}
