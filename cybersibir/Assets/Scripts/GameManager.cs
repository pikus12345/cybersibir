using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isMenu;
    private void Start()
    {
        SettingsManager.path = Path.Combine(Application.dataPath, "settings.json");
        Screen.fullScreen = SettingsManager.getSettings().fullscreen;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void EndLevel()
    {
        LevelManager.setOpened("Level"+(int.Parse(SceneManager.GetActiveScene().name.Substring(5))+1));
        LoadScene("LevelSelect");
    }
    


}
