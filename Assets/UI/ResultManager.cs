using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public GameObject victoryPanel;  // ����ʤ��Panel
    public GameObject gameOverPanel; // ����ʧ��Panel

    void Start()
    {
        // �����Ϸ����������ݽ����ʾ��Ӧ��Panel
        if (PlayerPrefs.GetInt("GameResult") == 1)
        {
            victoryPanel.SetActive(true);  // ��ʾʤ��Panel
            gameOverPanel.SetActive(false);  // ����ʧ��Panel
        }
        else
        {
            victoryPanel.SetActive(false);  // ����ʤ��Panel
            gameOverPanel.SetActive(true);  // ��ʾʧ��Panel
        }
    }

    // ���ش�����ť�Ĺ���
    public void ReturnToLobby()
    {
        Time.timeScale = 1f;  // �ָ���Ϸʱ��
        SceneManager.LoadScene("MainMenu");  // ���ش�������
    }

    // ��һ�ذ�ť�Ĺ���
    public void LoadNextLevel()
    {
        Time.timeScale = 1f;  // �ָ���Ϸʱ��
        string nextLevel = GetNextLevel();  // ��ȡ��һ������
        if (!string.IsNullOrEmpty(nextLevel))
        {
            Debug.Log("������һ��: " + nextLevel);  // �����һ���ؿ������ƣ����ԣ�
            SceneManager.LoadScene(nextLevel);  // ������һ��
        }
        else
        {
            Debug.Log("û����һ�أ������Ѿ������һ��");  // �����ʾ��Ϣ�����ԣ�
        }
    }

    // ������ս��ť�Ĺ���
    public void RetryLevel()
    {
        Time.timeScale = 1f;  // �ָ���Ϸʱ��
        string currentScene = PlayerPrefs.GetString("CurrentLevel");  // ��ȡ��ǰ�ؿ�����
        SceneManager.LoadScene(currentScene);  // ���¼��ص�ǰ�ؿ�
    }

    // ��ȡ��һ�ص�����
    private string GetNextLevel()
    {
        // ��PlayerPrefs�ж�ȡ�����ɵĹؿ�����
        int currentIndex = PlayerPrefs.GetInt("CurrentLevelIndex", -1);

        if (currentIndex == -1)
        {
            Debug.Log("û���ҵ���ǰ�ؿ��������޷�������һ��");
            return null;
        }

        // �����ǰ�ؿ��������е���
        Debug.Log("��ǰ����Ĺؿ�����: " + currentIndex);
        Debug.Log("Build Settings �еĳ�������: " + SceneManager.sceneCountInBuildSettings);

        // ȷ����ǰ�ؿ��������һ��ʵ�ʹؿ�
        if (currentIndex >= 0 && currentIndex < SceneManager.sceneCountInBuildSettings - 2) // ���� ResultScene
        {
            // ��ȡ��һ�ص�����
            int nextSceneIndex = currentIndex + 1;
            // ��Build Settings�л�ȡ��һ�ص�·������ȡ����
            string nextScenePath = SceneUtility.GetScenePathByBuildIndex(nextSceneIndex);
            string nextSceneName = System.IO.Path.GetFileNameWithoutExtension(nextScenePath);
            Debug.Log("��һ������: " + nextSceneName);  // ���������Ϣ
            return nextSceneName;
        }

        Debug.Log("û����һ�أ������Ѿ������һ��");  // �������
        return null;  // ���û����һ��
    }

}