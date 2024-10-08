using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Victory();
        }
    }

    void Victory()
    {
        // 存储玩家当前游玩的关卡索引
        PlayerPrefs.SetInt("CurrentLevelIndex", SceneManager.GetActiveScene().buildIndex);
        // 存储胜利结果
        PlayerPrefs.SetInt("GameResult", 1);  // 1 表示胜利
                                              // 加载结果场景
        SceneManager.LoadScene("ResultScene");
    }

}

