using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject victoryUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Victory();
        }
    }
    void Victory()
    {
        victoryUI.SetActive(true);
        Time.timeScale = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
       if (victoryUI != null)
        {
            victoryUI.SetActive(false);  // 隐藏Victory UI
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
