using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public float fallDelay = 0.1f;  // 延迟掉落的时间
    private Rigidbody2D rb;
    private bool hasPlayerStepped = false;  // 检测玩家是否已经踩上

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;  // 初始时禁用物理模拟，保持障碍物静止
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasPlayerStepped)
        {
            hasPlayerStepped = true;  // 玩家第一次踩上障碍物
            Invoke("StartFalling", fallDelay);  // 延迟掉落
        }
    }

    void StartFalling()
    {
        rb.isKinematic = false;  // 启用物理模拟
        rb.gravityScale = 1;  // 确保重力被应用
    }
}
