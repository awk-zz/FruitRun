using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private enum PlayerState 
    {
        Normal, 
        Big, 
        Small
    }
    
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private int starCount = 0;  // 收集星星数量
    public TMP_Text starText;  // 引用UI组件
    public float fallThreshold = -5f;  // 掉落阈值
    public GameObject gameOverUI;  // 失败UI

    private int maxJumpCount = 1;  // 默认跳跃次数
    private int jumpCount = 0;  // 跳跃计数

    private PlayerState currentState = PlayerState.Normal;  // 初始状态

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateStarUI();  // 初始化星星UI

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);  // 隐藏GameOverUI
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        // 自动向右移动

        if (transform.position.y < fallThreshold)
        {
            GameOver();
        }   

        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            Jump();  // 调用跳跃方法
        }
    }

    bool CanJump()
    {
        // 普通和变大状态只能跳一次
        if (currentState != PlayerState.Small && jumpCount >= maxJumpCount)
        {
            return false;  // 跳跃次数达到限制，不能再跳
        }

        // 变小状态下允许无限跳跃
        return true;
    }
       
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);  // 重置速度，防止多次叠加
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpCount++;  // 增加跳跃计数
        isGrounded = false;  // 设置为不在地面上
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // 设置为在地面上
            jumpCount = 0;  // 重置跳跃计数
        }
    }

    // 玩家变小后调用
    public void BecomeSmall()
    {
        currentState = PlayerState.Small;
        maxJumpCount = int.MaxValue;  // 允许无限跳跃
        transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        jumpCount = 0; 
    }

    // 玩家变大后调用
    public void BecomeBig()
    {
        currentState = PlayerState.Big;
        maxJumpCount = 1;  // 限制为单次跳跃
        transform.localScale = new Vector3(2f, 2f, 1f);
        jumpCount = 0; 
    }

    // 玩家恢复正常状态
    public void BecomeNormal()
    {
        currentState = PlayerState.Normal;
        maxJumpCount = 1;  // 限制为单次跳跃
        transform.localScale = new Vector3(1f, 1f, 1f);
        jumpCount = 0; 
    }

    public void AddStar()
    {
        starCount++;
        UpdateStarUI();  // 收集星星时更新UI
    }

    private void UpdateStarUI()
    {
        starText.text = "Stars: " + starCount.ToString();
    }

    void GameOver()
    {
        // 激活失败UI
        gameOverUI.SetActive(true);
        // 暂停游戏
        Time.timeScale = 0f;
    }
}