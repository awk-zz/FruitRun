using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    public AutoUpDown targetObstacle;  // 引用要控制的障碍物
    public Vector2 triggerPosition;  // 触发后障碍物要移动到的位置

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetObstacle.TriggerMove(triggerPosition);  // 触发障碍物移动
        }
    }
}
