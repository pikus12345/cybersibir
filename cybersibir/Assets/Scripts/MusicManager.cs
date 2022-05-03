using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource audioSource;
    public AudioClip[] clips;
    public bool isInGame;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Music"))
            {
                if (obj != gameObject)
                {
                    Destroy(obj);
                }
            }
        }
        settingsData data = SettingsManager.getSettings();
        audioMixer.SetFloat("SFXVolume", data.sfx);
        audioMixer.SetFloat("MusicVolume", data.music);
        isInGame = SceneManager.GetActiveScene().name.Substring(0, 5).Equals("Level");
        try
        {
            if (!audioSource.isPlaying | (isInGame))
            {
                if (!isInGame)
                {
                    audioSource.clip = clips[0];
                    audioSource.Play();
                    return;
                }
                if (isInGame & (audioSource.clip.name.Equals("Cybersibir") || audioSource.clip == null))
                {
                    audioSource.clip = clips[Random.Range(1, clips.Length)];
                    audioSource.Play();
                }
                
            }
        }
        catch { }

    }
}
