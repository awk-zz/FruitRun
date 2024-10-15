using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioSource bgmSource;  // ����������Դ

    // ���Ʊ������ֵĲ���״̬
    public void ToggleBGM(bool isOn)
    {
        if (isOn)
        {
            // �ָ����ű�������
            if (!bgmSource.isPlaying)
            {
                bgmSource.Play();
            }
        }
        else
        {
            // ��ͣ��������
            if (bgmSource.isPlaying)
            {
                bgmSource.Pause();
            }
        }
    }
}
