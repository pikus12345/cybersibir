using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Toggle FullscreenToggle;


    public AudioMixer audioMixer;

    public static string path;

    private void Start()
    {
        
        settingsData data = getSettings();
        FullscreenToggle.isOn = data.fullscreen;
        MusicSlider.value = data.music;
        SFXSlider.value = data.sfx;
    }
    public void RefreshData()
    {
        
    }
    public void saveSettings()
    {
        settingsData data = new settingsData();
        data.sfx = SFXSlider.value;
        data.music = MusicSlider.value;
        data.fullscreen = FullscreenToggle.isOn;
        File.WriteAllText(path, JsonUtility.ToJson(data));
    }
    public static settingsData getSettings()
    {
        return JsonUtility.FromJson<settingsData>(File.ReadAllText(path));
    }

}
public class settingsData
{
    public float sfx;
    public float music;
    public bool fullscreen;
}