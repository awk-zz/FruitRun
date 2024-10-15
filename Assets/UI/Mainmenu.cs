using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectPanel;  // 关卡选择面板
    public GameObject fruitInfoPanel;    // 水果介绍面板
    public GameObject tutorialInfoPanel; // 游戏教学面板

    // 显示关卡选择面板
    public void ShowLevelSelectPanel()
    {
        CloseAllPanels();
        levelSelectPanel.SetActive(true);
    }

    // 显示水果介绍面板
    public void ShowFruitInfoPanel()
    {
        CloseAllPanels();
        fruitInfoPanel.SetActive(true);
    }

    // 显示游戏教学面板
    public void ShowTutorialInfoPanel()
    {
        CloseAllPanels();
        tutorialInfoPanel.SetActive(true);
    }

    // 关闭所有面板
    public void CloseAllPanels()  // 改为 public
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
