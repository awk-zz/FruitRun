using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // 如果你使用的是TextMeshPro的文本组件

public class LevelSelect : MonoBehaviour
{
    public TMP_Text levelDescriptionText;  // 引用关卡描述文本
    public GameObject startGameButton;     // 引用“开始游戏”按钮
    private string selectedLevelName;      // 保存选中的关卡名称

    private string[] levelNames = new string[]  // 关卡名称数组
    {
        "Level1",
        "Level2",
        "Level3",
        "Level4",
        "Level5"
    };

    private string[] levelDescriptions = new string[]  // 关卡描述数组
    {
        "Learn how to cleverly use the shrinking ability to overcome obstacles.",
        "Master the art of growing bigger to break through barriers.",
        "Face enemies and distinguish between different types of stars, making careful choices.",
        "Navigate through the level using teleportation portals.",
        "The ultimate challenge—push your limits and claim victory!"
    };

    // 更新关卡描述并显示开始按钮
    public void SelectLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelDescriptions.Length)
        {
            levelDescriptionText.text = levelDescriptions[levelIndex];  // 更新描述文本
            selectedLevelName = levelNames[levelIndex];  // 保存选择的关卡名称
            startGameButton.SetActive(true);  // 显示“开始游戏”按钮
        }
    }

    // 加载选中的关卡
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(selectedLevelName))
        {
            SceneManager.LoadScene(selectedLevelName);  // 通过关卡名称加载场景
        }
        else
        {
            Debug.LogError("No level selected!");
        }
    }
}
