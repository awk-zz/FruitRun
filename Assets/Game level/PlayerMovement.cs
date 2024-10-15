using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;  // 引用Animator组件
    private bool isGrounded = true;
    private int starCount = 0;  // 收集星星数量
    public TMP_Text starText;  // 引用UI组件
    public float fallThreshold = -5f;  // 摔落阈值

    public int maxHealth = 5; // 玩家最大生命值
    private int currentHealth; // 玩家当前生命值
    public GameObject[] lifeObjects;  // 用于显示玩家生命值的2D对象

    private int maxJumpCount = 1;  // 默认跳跃次数（正常和变大状态）
    private int jumpCount = 0;  // 跳跃计数
    private bool facingRight = true; // 控制角色的朝向

    // 音效引用
    public AudioClip jumpSound;
    public AudioClip growSound;
    public AudioClip shrinkSound;
    public AudioClip portalSound;
    public AudioClip collectStarSound;
    public AudioClip takeDamageSound;
    private AudioSource audioSource;

    public enum PlayerState
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
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();  // 初始化音源
        originalScale = transform.localScale;
        UpdateStarUI();  // 初始化星星UI
        currentHealth = maxHealth;  // 初始化生命值
        UpdateHealthObjects();  // 初始化生命值2D对象
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");  // 获取水平输入

        // 左右移动逻辑
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 更新动画参数
        animator.SetFloat("Speed", Mathf.Abs(moveInput));  // 根据水平输入更新Speed参数

        // 翻转角色方向
        if (moveInput > 0 && !facingRight)
        {
            Flip();  // 向右移动时如果角色面朝左，则翻转
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();  // 向左移动时如果角色面朝右，则翻转
        }

        // 更新跳跃状态
        animator.SetBool("IsJumping", !isGrounded);  // 跳跃动画切换

        // 摔落检测
        if (transform.position.y < fallThreshold)
        {
            GameOver();  // 玩家摔落死亡
        }

        // 跳跃逻辑
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            Jump();  // 调用跳跃方法
        }
    }

    bool CanJump()
    {
        // 检查当前状态是否可以跳跃
        if (jumpCount < maxJumpCount)
        {
            return true;  // 如果跳跃次数小于允许的最大跳跃次数，允许跳跃
        }

        return false;  // 否则不允许跳跃
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // 执行跳跃
        isGrounded = false;  // 设置为不在地面上
        jumpCount++;  // 增加跳跃计数

        // 播放跳跃音效
        audioSource.PlayOneShot(jumpSound);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // 确认角色着地
            jumpCount = 0;  // 重置跳跃计数
        }
    }

    // 角色翻转方向
    void Flip()
    {
        facingRight = !facingRight;  // 切换角色朝向标志
        Vector3 scaler = transform.localScale;  // 获取当前缩放比例
        scaler.x *= -1;  // 翻转X轴
        transform.localScale = scaler;  // 应用翻转
    }

    // 玩家变小后调用
    public void BecomeSmall()
    {
        currentState = PlayerState.Small;
        maxJumpCount = 2;  // 允许二段跳
        transform.localScale = new Vector3(Mathf.Abs(originalScale.x) * 0.5f, originalScale.y * 0.5f, originalScale.z);

        // 保持角色朝向
        if (!facingRight)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        jumpCount = 0;  // 重置跳跃计数

        // 播放变小音效
        audioSource.PlayOneShot(shrinkSound);
    }

    // 玩家变大后调用
    public void BecomeBig()
    {
        currentState = PlayerState.Big;
        maxJumpCount = 1;  // 限制为单次跳跃
        transform.localScale = new Vector3(Mathf.Abs(originalScale.x) * 1.5f, originalScale.y * 1.5f, originalScale.z);

        // 保持角色朝向
        if (!facingRight)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        jumpCount = 0;  // 重置跳跃计数

        // 播放变大音效
        audioSource.PlayOneShot(growSound);
    }

    // 玩家恢复正常状态
    public void BecomeNormal()
    {
        currentState = PlayerState.Normal;
        maxJumpCount = 1;  // 限制为单次跳跃
        transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        // 保持角色朝向
        if (!facingRight)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        jumpCount = 0;
    }

    // 受伤逻辑
    public void TakeDamage()
    {
        // 只有在正常状态和变小状态下才能受到伤害
        if (currentState != PlayerState.Big)
        {
            currentHealth--;  // 减少生命值
            UpdateHealthObjects();  // 更新生命值2D对象的显示

            // 播放受伤音效
            audioSource.PlayOneShot(takeDamageSound);

            if (currentHealth <= 0)
            {
                GameOver();
            }
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

        // 播放吃星星音效
        audioSource.PlayOneShot(collectStarSound);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Portal"))
        {
            // 播放传送音效
            audioSource.PlayOneShot(portalSound);
        }
    }
    public PlayerState GetCurrentState()
    {
        return currentState;  // 返回当前的玩家状态
    }

}
