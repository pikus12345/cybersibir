using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Music"))
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

    }

}
