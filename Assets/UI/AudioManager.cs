using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgmSource;  // ���ڲ���BGM����ƵԴ
    public AudioSource sfxSource;  // ���ڲ�����Ч����ƵԴ

    public AudioClip lobbyBGM;     // ������������
    public AudioClip levelBGM;     // �ؿ���������

    private float bgmVolume = 1f;  // BGM��Ĭ������
    private float sfxVolume = 1f;  // ��Ч��Ĭ������

    private void Awake()
    {
        // ����ģʽ��ȷ��AudioManager�ڳ����л�ʱ���ֲ���
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayLobbyBGM()
    {
        bgmSource.clip = lobbyBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlayLevelBGM()
    {
        bgmSource.clip = levelBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // ����BGM����
    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        bgmSource.volume = bgmVolume;
    }

    // ������Ч����
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;
    }

    // ������Ч
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
