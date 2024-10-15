using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // �����ʹ�õ���TextMeshPro���ı����

public class LevelSelect : MonoBehaviour
{
    public TMP_Text levelDescriptionText;  // ���ùؿ������ı�
    public GameObject startGameButton;     // ���á���ʼ��Ϸ����ť
    private string selectedLevelName;      // ����ѡ�еĹؿ�����

    private string[] levelNames = new string[]  // �ؿ���������
    {
        "Level1",
        "Level2",
        "Level3",
        "Level4",
        "Level5"
    };

    private string[] levelDescriptions = new string[]  // �ؿ���������
    {
        "Learn how to cleverly use the shrinking ability to overcome obstacles.",
        "Master the art of growing bigger to break through barriers.",
        "Face enemies and distinguish between different types of stars, making careful choices.",
        "Navigate through the level using teleportation portals.",
        "The ultimate challenge��push your limits and claim victory!"
    };

    // ���¹ؿ���������ʾ��ʼ��ť
    public void SelectLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelDescriptions.Length)
        {
            levelDescriptionText.text = levelDescriptions[levelIndex];  // ���������ı�
            selectedLevelName = levelNames[levelIndex];  // ����ѡ��Ĺؿ�����
            startGameButton.SetActive(true);  // ��ʾ����ʼ��Ϸ����ť
        }
    }

    // ����ѡ�еĹؿ�
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(selectedLevelName))
        {
            SceneManager.LoadScene(selectedLevelName);  // ͨ���ؿ����Ƽ��س���
        }
        else
        {
            Debug.LogError("No level selected!");
        }
    }
}
