using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectPanel;  // 关卡选择面板
    public GameObject settingsPanel;     // 设置面板
    public TMP_Text levelDescriptionText; // 引用关卡描述文本
    public GameObject startLevelButton;  // 引用开始游戏按钮
    public GameObject bgmToggleButton;   // BGM开关按钮

    private string selectedLevelName;    // 保存选择的关卡名称
    private bool isBGMOn = true;         // 用于记录BGM状态，默认为开启

    private string[] levelDescriptions = new string[5]  // 关卡描述数组
    {
        "Level 1: This is the beginner level, perfect for learning the basics.",
        "Level 2: A bit more challenging, test your skills here.",
        "Level 3: Watch out! Enemies are getting stronger.",
        "Level 4: Only for advanced players. Are you ready?",
        "Level 5: The ultimate challenge awaits you!"
    };

    private string[] levelNames = new string[5]  // 关卡名称数组
    {
        "Level1",
        "Level2",
        "Level3",
        "Level4",
        "Level5"
    };

    private void Start()
    {
        // 如果BGM初始是开启的，播放大厅的BGM
        if (isBGMOn)
        {
            AudioManager.instance.PlayLobbyBGM();  // 播放大厅背景音乐
        }
    }

    // 开始游戏
    public void StartGame()
    {
        CloseAllPanels();  // 确保其他面板关闭
        levelSelectPanel.SetActive(true);  // 显示关卡选择面板
    }

    // 切换关卡描述并显示开始游戏按钮
    public void DisplayLevelDescription(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelDescriptions.Length)
        {
            levelDescriptionText.text = levelDescriptions[levelIndex];  // 更新描述文本
            selectedLevelName = levelNames[levelIndex];  // 保存选择的关卡名称
            startLevelButton.SetActive(true);  // 显示“开始游戏”按钮
        }
    }

    // 加载所选关卡
    public void LoadSelectedLevel()
    {
        if (!string.IsNullOrEmpty(selectedLevelName))
        {
            SceneManager.LoadScene(selectedLevelName);  // 直接加载场景
        }
    }

    // 打开设置面板
    public void OpenSettings()
    {
        CloseAllPanels();  // 确保其他面板关闭
        settingsPanel.SetActive(true);  // 显示设置面板
    }

    // 关闭设置面板
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);  // 隐藏设置面板
    }

    // 关闭关卡选择面板
    public void CloseLevelSelect()
    {
        levelSelectPanel.SetActive(false);  // 隐藏关卡选择面板
    }

    // 退出游戏
    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    // BGM 开关按钮的功能
    public void ToggleBGM()
    {
        if (isBGMOn)
        {
            AudioManager.instance.StopBGM();  // 停止BGM
            isBGMOn = false;  // 更新BGM状态为关闭
        }
        else
        {
            AudioManager.instance.PlayLobbyBGM();  // 播放BGM
            isBGMOn = true;  // 更新BGM状态为开启
        }
    }

    // 关闭所有面板
    private void CloseAllPanels()
    {
        levelSelectPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
}
