using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public GameObject victoryPanel;  // 引用胜利Panel
    public GameObject gameOverPanel; // 引用失败Panel

    void Start()
    {
        // 检查游戏结果，并根据结果显示对应的Panel
        if (PlayerPrefs.GetInt("GameResult") == 1)
        {
            victoryPanel.SetActive(true);  // 显示胜利Panel
            gameOverPanel.SetActive(false);  // 隐藏失败Panel
        }
        else
        {
            victoryPanel.SetActive(false);  // 隐藏胜利Panel
            gameOverPanel.SetActive(true);  // 显示失败Panel
        }
    }

    // 返回大厅按钮的功能
    public void ReturnToLobby()
    {
        Time.timeScale = 1f;  // 恢复游戏时间
        SceneManager.LoadScene("MainMenu");  // 加载大厅场景
    }

    // 下一关按钮的功能
    public void LoadNextLevel()
    {
        Time.timeScale = 1f;  // 恢复游戏时间
        string nextLevel = GetNextLevel();  // 获取下一关名称
        if (!string.IsNullOrEmpty(nextLevel))
        {
            Debug.Log("加载下一关: " + nextLevel);  // 输出下一个关卡的名称（调试）
            SceneManager.LoadScene(nextLevel);  // 加载下一关
        }
        else
        {
            Debug.Log("没有下一关，可能已经是最后一关");  // 输出提示信息（调试）
        }
    }

    // 重新挑战按钮的功能
    public void RetryLevel()
    {
        Time.timeScale = 1f;  // 恢复游戏时间
        string currentScene = PlayerPrefs.GetString("CurrentLevel");  // 获取当前关卡名称
        SceneManager.LoadScene(currentScene);  // 重新加载当前关卡
    }

    // 获取下一关的名称
    private string GetNextLevel()
    {
        // 从PlayerPrefs中读取玩家完成的关卡索引
        int currentIndex = PlayerPrefs.GetInt("CurrentLevelIndex", -1);

        if (currentIndex == -1)
        {
            Debug.Log("没有找到当前关卡索引，无法加载下一关");
            return null;
        }

        // 输出当前关卡索引进行调试
        Debug.Log("当前游玩的关卡索引: " + currentIndex);
        Debug.Log("Build Settings 中的场景总数: " + SceneManager.sceneCountInBuildSettings);

        // 确保当前关卡不是最后一个实际关卡
        if (currentIndex >= 0 && currentIndex < SceneManager.sceneCountInBuildSettings - 2) // 忽略 ResultScene
        {
            // 获取下一关的索引
            int nextSceneIndex = currentIndex + 1;
            // 从Build Settings中获取下一关的路径并提取名称
            string nextScenePath = SceneUtility.GetScenePathByBuildIndex(nextSceneIndex);
            string nextSceneName = System.IO.Path.GetFileNameWithoutExtension(nextScenePath);
            Debug.Log("下一关名称: " + nextSceneName);  // 输出调试信息
            return nextSceneName;
        }

        Debug.Log("没有下一关，可能已经是最后一关");  // 调试输出
        return null;  // 如果没有下一关
    }

}