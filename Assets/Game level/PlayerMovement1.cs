using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // 之前的变量声明
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private int starCount = 0;  // 收集星星数量
    public TMP_Text starText;  // 引用UI组件
    public float fallThreshold = -5f;  // 掉落阈值

    public int maxHealth = 5; //玩家最大生命值
    private int currentHealth; // 玩家当前生命值
    public GameObject[] lifeObjects;

    private int maxJumpCount = 1;  // 默认跳跃次数
    private int jumpCount = 0;  // 跳跃计数

    private enum PlayerState
    {
        Normal,
        Big,
        Small
    }

    private PlayerState currentState = PlayerState.Normal;  // 初始状态
    private Vector3 originalScale; // 保存玩家的初始缩放比例

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        UpdateStarUI();  // 初始化星星UI
        currentHealth = maxHealth;  // 初始化生命值
        UpdateHealthObjects();  // 初始化生命值2D对象
    }

    void Update()
    {
        // 左右移动逻辑
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);  // 向左移动
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);  // 向右移动
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);  // 松开按键时停止水平移动
        }

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
        transform.localScale = originalScale * 0.5f;
        jumpCount = 0;
    }

    // 玩家变大后调用
    public void BecomeBig()
    {
        currentState = PlayerState.Big;
        maxJumpCount = 1;  // 限制为单次跳跃
        transform.localScale = originalScale * 1.5f;
        jumpCount = 0;
    }

    // 玩家恢复正常状态
    public void BecomeNormal()
    {
        currentState = PlayerState.Normal;
        maxJumpCount = 1;  // 限制为单次跳跃
        transform.localScale = originalScale;
        jumpCount = 0;
    }

    public void TakeDamage()
    {
        currentHealth--;  // 减少生命值
        UpdateHealthObjects();  // 更新生命值2D对象的显示

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHealthObjects()
    {
        // 根据当前生命值更新2D对象的显示
        for (int i = 0; i < lifeObjects.Length; i++)
        {
            if (i < currentHealth)
            {
                lifeObjects[i].SetActive(true);  // 启用2D对象
            }
            else
            {
                lifeObjects[i].SetActive(false);  // 禁用2D对象
            }
        }
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
        // 存储失败结果
        PlayerPrefs.SetInt("GameResult", 0);  // 0 表示失败
        // 存储当前关卡名称
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        // 加载结果场景
        SceneManager.LoadScene("ResultScene");
    }
}
