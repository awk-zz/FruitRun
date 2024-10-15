using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public float fallDelay = 0.1f;  // �ӳٵ����ʱ��
    private Rigidbody2D rb;
    private bool hasPlayerStepped = false;  // �������Ƿ��Ѿ�����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;  // ��ʼʱ��������ģ�⣬�����ϰ��ﾲֹ
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasPlayerStepped)
        {
            hasPlayerStepped = true;  // ��ҵ�һ�β����ϰ���
            Invoke("StartFalling", fallDelay);  // �ӳٵ���
        }
    }

    void StartFalling()
    {
        rb.isKinematic = false;  // ��������ģ��
        rb.gravityScale = 1;  // ȷ��������Ӧ��
    }
}
