using UnityEngine;
using UnityEngine.UI;

public class MusicToggleController : MonoBehaviour
{
    public AudioSource bgmSource;  // �������еı������� AudioSource
    public Toggle musicToggle;     // ���ֿ��ص� Toggle

    void Start()
    {
        // ��ʼ�� Toggle �ĳ�ʼ״̬Ϊ AudioSource ��ǰ�� mute ״̬
        musicToggle.isOn = !bgmSource.mute;  // �����Ƶû�о�����Toggle ���ڹ�ѡ״̬

        // ���� Toggle ��״̬�仯����������ľ���
        musicToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // �� Toggle ״̬�����仯ʱ����
    private void OnToggleValueChanged(bool isOn)
    {
        bgmSource.mute = !isOn;  // ��ѡʱȡ��������ȡ����ѡʱ����
    }
}
