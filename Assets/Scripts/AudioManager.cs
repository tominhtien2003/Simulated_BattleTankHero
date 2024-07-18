using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region singleton
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }
    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;
    }

    [SerializeField] List<Sound> soundVFX, soundMusic;
    [SerializeField] AudioSource vfxAudioSource, musicAudioSource;
    public void PlayMusic(string name)
    {
        Sound sound = soundMusic.Find(x => x.name == name);

        if (sound != null)
        {
            musicAudioSource.clip = sound.clip;

            musicAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Music sound not found: " + name);
        }
    }
    public void PlayVFX(string name)
    {
        Sound sound = soundVFX.Find(x => x.name == name);

        if (sound != null)
        {
            vfxAudioSource.clip = sound.clip;

            vfxAudioSource.PlayOneShot(sound.clip);
        }
        else
        {
            Debug.LogWarning("VFX sound not found: " + name);
        }
    }
}
