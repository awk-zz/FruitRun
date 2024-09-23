using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float moveSpeed = 2f;  // 移动速度
    public float moveDistance = 3f;  // 移动距离
    public bool loopMovement = true;  // 是否循环移动
    public bool moveLeftToRight = true;  // 初始移动方向，默认为从左到右

    private Vector2 startPosition;  // 起始位置
    private Vector2 endPosition;  // 终点位置
    private bool movingToEnd;  // 标记当前移动方向

    private Rigidbody2D rb;  // 平台的Rigidbody2D

    void Start()
    {
        // 获取当前物体的位置作为起始位置
        startPosition = transform.position;

        // 获取Rigidbody2D组件
        rb = GetComponent<Rigidbody2D>();

        // 初始化为Kinematic
        rb.bodyType = RigidbodyType2D.Kinematic;

        // 根据移动方向决定终点位置
        if (moveLeftToRight)
        {
            endPosition = new Vector2(startPosition.x + moveDistance, startPosition.y);  // 向右移动
            movingToEnd = true;  // 初始移动方向为向右
        }
        else
        {
            endPosition = new Vector2(startPosition.x - moveDistance, startPosition.y);  // 向左移动
            movingToEnd = false;  // 初始移动方向为向左
        }
    }

    void FixedUpdate()
    {
        if (loopMovement)
        {
            // 循环移动的逻辑
            if (movingToEnd)
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, endPosition, moveSpeed * Time.fixedDeltaTime));
                if (Vector2.Distance(transform.position, endPosition) < 0.1f)
                {
                    movingToEnd = false;  // 到达终点后改变方向
                }
            }
            else
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.fixedDeltaTime));
                if (Vector2.Distance(transform.position, startPosition) < 0.1f)
                {
                    movingToEnd = true;  // 到达起点后改变方向
                }
            }
        }
        else
        {
            rb.MovePosition(rb.position + new Vector2(moveLeftToRight ? moveSpeed : -moveSpeed, 0) * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}