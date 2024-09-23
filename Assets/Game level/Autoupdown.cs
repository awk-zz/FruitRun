using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoUpDown : MonoBehaviour
{
    public float moveSpeed = 2f;  // 移动速度
    public float moveDistance = 3f;  // 移动距离
    public bool loopMovement = true;  // 是否循环移动
    public bool moveTopToBottom = true;  // 初始移动方向，默认为从上到下

    private Vector2 startPosition;  // 起始位置
    private Vector2 endPosition;  // 终点位置
    private bool movingToEnd;  // 标记当前移动方向

    private bool triggered = false;  // 标记是否已被触发
    private Vector2 targetPosition;  // 目标位置（被触发后）

    void Start()
    {
        // 获取当前物体的位置作为起始位置
        startPosition = transform.position;

        // 根据移动方向决定终点位置
        if (moveTopToBottom)
        {
            endPosition = new Vector2(startPosition.x, startPosition.y - moveDistance);  // 向下移动
            movingToEnd = true;  // 初始移动方向为向下
        }
        else
        {
            endPosition = new Vector2(startPosition.x, startPosition.y + moveDistance);  // 向上移动
            movingToEnd = true;  // 初始移动方向为向上
        }
    }

    void Update()
    {
        if (triggered)
        {
            // 当被触发时，移动到目标位置
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 当到达目标位置时停止移动
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                triggered = false;  // 停止移动
            }
        }
        else if (loopMovement)
        {
            // 循环移动的逻辑
            if (movingToEnd)
            {
                transform.position = Vector2.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, endPosition) < 0.1f)
                {
                    movingToEnd = false;  // 到达终点后改变方向
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, startPosition) < 0.1f)
                {
                    movingToEnd = true;  // 到达起点后改变方向
                }
            }
        }
    }

    // 触发移动到指定位置
    public void TriggerMove(Vector2 newPosition)
    {
        triggered = true;
        targetPosition = newPosition;
        loopMovement = false;  // 停止循环移动
    }
}
