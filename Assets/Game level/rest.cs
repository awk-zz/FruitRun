using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    // 当其他碰撞体进入触发器时触发
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰撞体是否为玩家
        if (other.CompareTag("Player"))
        {
            // 获取玩家的PlayerMovement组件
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                // 调用玩家恢复正常形态的方法
                player.BecomeNormal();
            }
        }
    }
}