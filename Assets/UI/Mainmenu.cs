using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectPanel;  // �ؿ�ѡ�����
    public GameObject fruitInfoPanel;    // ˮ���������
    public GameObject tutorialInfoPanel; // ��Ϸ��ѧ���

    // ��ʾ�ؿ�ѡ�����
    public void ShowLevelSelectPanel()
    {
        CloseAllPanels();
        levelSelectPanel.SetActive(true);
    }

    // ��ʾˮ���������
    public void ShowFruitInfoPanel()
    {
        CloseAllPanels();
        fruitInfoPanel.SetActive(true);
    }

    // ��ʾ��Ϸ��ѧ���
    public void ShowTutorialInfoPanel()
    {
        CloseAllPanels();
        tutorialInfoPanel.SetActive(true);
    }

    // �ر��������
    public void CloseAllPanels()  // ��Ϊ public
    {
        levelSelectPanel.SetActive(false);
        fruitInfoPanel.SetActive(false);
        tutorialInfoPanel.SetActive(false);
    }
    public void ExitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
