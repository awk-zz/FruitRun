using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public float fadeDuration = 2f;  // 渐隐消失的时间
    public int maxAttacks = 2;  // 最大攻击次数
    private int attackCount = 0;  // 当前攻击次数
    private bool isFading = false;  // 是否正在消失
    private SpriteRenderer spriteRenderer;  // 幽灵的SpriteRenderer用于控制渐隐
    private PlayerMovement player;  // 引用玩家对象
    public float attackCooldown = 1.5f;  // 攻击冷却时间
    private float lastAttackTime;  // 记录上一次攻击时间

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>();  // 获取玩家对象
    }

    void Update()
    {
        if (isFading)
        {
            FadeOut();  // 如果正在消失，执行渐隐逻辑
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;  // 更新攻击时间

            if (player != null)
            {
                if (player.GetCurrentState() == PlayerMovement.PlayerState.Big)
                {
                    // 玩家处于变大状态时无视攻击，并让幽灵立即进入消失流程
                    attackCount++;
                    if (attackCount >= 1)
                    {
                        StartFading();
                    }
                }
                else
                {
                    // 玩家处于正常或变小状态时，幽灵攻击玩家
                    player.TakeDamage();  // 扣除玩家的血量
                    attackCount++;

                    // 当攻击达到最大次数后，幽灵停止移动并渐隐消失
                    if (attackCount >= maxAttacks)
                    {
                        StartFading();
                    }
                }
            }
        }
    }

    void StartFading()
    {
        isFading = true;  // 开始消失
        GetComponent<AutoMove>().enabled = false;  // 停止幽灵的自动移动
    }

    void FadeOut()
    {
        Color color = spriteRenderer.color;
        color.a -= Time.deltaTime / fadeDuration;  // 每帧减少透明度
        spriteRenderer.color = color;

        if (color.a <= 0)
        {
            Destroy(gameObject);  // 当透明度降为0时销毁幽灵对象
        }
    }
}
