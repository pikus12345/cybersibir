using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Level
{
    [SerializeField] public string levelTitle;
    [SerializeField] public string levelDescription;
    [SerializeField] public Sprite levelImage;
    [SerializeField] public string levelName;
}

public class LevelManager : MonoBehaviour
{
    
    [SerializeField]public List<Level> levelList = new List<Level>();
    public Image levelImage;
    public Text levelTitle;
    public Text levelDescription;
    [SerializeField]public GameObject closedLevel;
    public Text numberText;

    public static List<string> openedLevels = new List<string>();

    public Button start;

    public Button left, right;

    private int selectedLevel;

    private void Update()
    {
        if (selectedLevel == levelList.Count-1)
            right.interactable = false;
        else
            right.interactable = true;

        if (selectedLevel == 0)
            left.interactable = false;
        else
            left.interactable = true;
        numberText.text = string.Format("{0}/{1}", selectedLevel+1, levelList.Count);
        
        levelTitle.text = levelList[selectedLevel].levelTitle;
        levelImage.sprite = levelList[selectedLevel].levelImage;
        bool isOpened = false;
        foreach(string level in openedLevels)
        {
            if (level.Equals(levelList[selectedLevel].levelName))
            {
                isOpened = true;
                break;
            }
        }
        if (!isOpened & selectedLevel != 0)
        {
            levelDescription.text = "???";
            levelImage.color = Color.grey;
            closedLevel.SetActive(true);
            start.interactable = false;
        }
        else
        {
            levelDescription.text = levelList[selectedLevel].levelDescription;
            levelImage.color = Color.white;
            closedLevel.SetActive(false);
            start.interactable = true;
        }
    }
    public void NextLevel(int i)
    {
        selectedLevel += i;
    }
    public void LoadSelected()
    {
        LoadScene(levelList[selectedLevel].levelName);
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
    public static void setOpened(string name)
    {
        openedLevels.Add(name);
    }
}

