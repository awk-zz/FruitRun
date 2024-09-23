using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   
    public string targetScene;

   
    public void SwitchScene()
    {
        SceneManager.LoadScene("GAMELEVEL1");
    }
}