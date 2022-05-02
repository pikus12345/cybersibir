using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider SFXSlider;
    public Slider MusicSlider;
    public Toggle FullscreenToggle;

    public static float SFX;
    public static float Music;
    public static bool fullscreen;

    public AudioMixer audioMixer;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnSceneLoad()
    {
        //do something
    }
    
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("SettingsManager").Length > 1)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("SettingsManager"))
            {
                if (obj != gameObject)
                {
                    Destroy(obj);
                }
            }
        }
        try
        { Find(); RefreshAndSave(); }
        catch { }
    }
    public void Find()
    {
        SFXSlider = GameObject.FindGameObjectWithTag("SFXSlider").GetComponent<Slider>();
        MusicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
        FullscreenToggle = GameObject.FindGameObjectWithTag("FullscreenToggle").GetComponent<Toggle>();
    }
    public void RefreshAndSave()
    {
        SFX = SFXSlider.value;
        Music = MusicSlider.value;
        fullscreen = FullscreenToggle.isOn;

        PlayerPrefs.SetFloat("SFX", SFX);
        PlayerPrefs.SetFloat("Music", Music);
        if(fullscreen)
            PlayerPrefs.SetInt("Fullscreen", 0);
        else
            PlayerPrefs.SetInt("Fullscreen", 1);
        SetValues();
    }
    public void Load()
    {
        SFX = PlayerPrefs.GetFloat("SFX", 0);
        Music = PlayerPrefs.GetFloat("Music", 0);
        if (PlayerPrefs.GetInt("Fullscreen", 0) == 0)
            fullscreen = false;
        else
            fullscreen = true;
        SetValues();
    }
    public void SetValues()
    {
        SFXSlider.value = SFX;
        audioMixer.SetFloat("SFXVolume", SFX);
        MusicSlider.value = Music;
        audioMixer.SetFloat("MusicVolume", Music);
        FullscreenToggle.isOn = fullscreen;
        Screen.fullScreen = fullscreen;
    }
}
