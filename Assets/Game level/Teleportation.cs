using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform targetPortal;  // 目标传送门的位置
    public bool isRandomTeleport = false;  // 是否随机传送
    public Transform[] randomTargets;  // 随机传送目标位置
    private bool isTeleporting = false;  // 防止多次传送

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isTeleporting)
        {
            StartCoroutine(TeleportPlayer(other));
        }
    }

    private IEnumerator TeleportPlayer(Collider2D player)
    {
        isTeleporting = true;  // 传送开始

        if (isRandomTeleport && randomTargets.Length > 0)
        {
            int randomIndex = Random.Range(0, randomTargets.Length);
            player.transform.position = randomTargets[randomIndex].position;
        }
        else if (targetPortal != null)
        {
            player.transform.position = targetPortal.position;  // 修正了 transform 和 position 之间的空格
        }

        yield return new WaitForSeconds(1f);
        isTeleporting = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
