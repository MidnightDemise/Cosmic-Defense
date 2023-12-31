using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public static class AudioManager
{
    #region Fields
    static bool initialized = false;

    static bool bgMusicInitialized = false;

    static AudioSource audioSource;
    static Dictionary<ClipName, AudioClip> audioClips = 
        new Dictionary<ClipName, AudioClip>();
    #endregion

    #region Properties

    public static bool Initialized
    {
        get { return initialized; }

    }

    public static bool BGMusicInitialized
    {
        get { return bgMusicInitialized; }
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
        audioClips.Add(ClipName.CrimsonImCountingOnYou, Resources.Load<AudioClip>("Crimson Im counting on you"));
        audioClips.Add(ClipName.Destroyed, Resources.Load<AudioClip>("Destroyed"));
        audioClips.Add(ClipName.ForDeath, Resources.Load<AudioClip>("For Death"));
        audioClips.Add(ClipName.GalvaShockAttack, Resources.Load<AudioClip>("GalvaShock Attack"));
        audioClips.Add(ClipName.Nooooo, Resources.Load<AudioClip>("Nooooo!"));
        audioClips.Add(ClipName.ThinksHeCanDefeatMe, Resources.Load<AudioClip>("Thinks he can defeat me"));
        audioClips.Add(ClipName.WhatImpossible, Resources.Load<AudioClip>("What...impossible_1"));
        audioClips.Add(ClipName.WaitTillLevel3, Resources.Load<AudioClip>("WaitTillLevel3"));
        audioClips.Add(ClipName.WrymDestroyHim, Resources.Load<AudioClip>("WrymDestroyHim"));
    }

    public static void InitializeBGMusic()
    {
        bgMusicInitialized = true;
    }

    public static void Play(ClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }


    public static void SfxVolume(float volume)
    {
        audioSource.volume = volume;
    }

    #endregion
}
