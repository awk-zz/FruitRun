using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public float fadeDuration = 2f;  // ������ʧ��ʱ��
    public int maxAttacks = 2;  // ��󹥻�����
    private int attackCount = 0;  // ��ǰ��������
    private bool isFading = false;  // �Ƿ�������ʧ
    private SpriteRenderer spriteRenderer;  // �����SpriteRenderer���ڿ��ƽ���
    private PlayerMovement player;  // ������Ҷ���
    public float attackCooldown = 1.5f;  // ������ȴʱ��
    private float lastAttackTime;  // ��¼��һ�ι���ʱ��

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>();  // ��ȡ��Ҷ���
    }

    void Update()
    {
        if (isFading)
        {
            FadeOut();  // ���������ʧ��ִ�н����߼�
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;  // ���¹���ʱ��

            if (player != null)
            {
                if (player.GetCurrentState() == PlayerMovement.PlayerState.Big)
                {
                    // ��Ҵ��ڱ��״̬ʱ���ӹ�����������������������ʧ����
                    attackCount++;
                    if (attackCount >= 1)
                    {
                        StartFading();
                    }
                }
                else
                {
                    // ��Ҵ����������С״̬ʱ�����鹥�����
                    player.TakeDamage();  // �۳���ҵ�Ѫ��
                    attackCount++;

                    // �������ﵽ������������ֹͣ�ƶ���������ʧ
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
        isFading = true;  // ��ʼ��ʧ
        GetComponent<AutoMove>().enabled = false;  // ֹͣ������Զ��ƶ�
    }

    void FadeOut()
    {
        Color color = spriteRenderer.color;
        color.a -= Time.deltaTime / fadeDuration;  // ÿ֡����͸����
        spriteRenderer.color = color;

        if (color.a <= 0)
        {
            Destroy(gameObject);  // ��͸���Ƚ�Ϊ0ʱ�����������
        }
    }
}
