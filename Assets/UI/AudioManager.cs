using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgmSource;  // 用于播放BGM的音频源
    public AudioSource sfxSource;  // 用于播放音效的音频源

    public AudioClip lobbyBGM;     // 大厅背景音乐
    public AudioClip levelBGM;     // 关卡背景音乐

    private float bgmVolume = 1f;  // BGM的默认音量
    private float sfxVolume = 1f;  // 音效的默认音量

    private void Awake()
    {
        // 单例模式，确保AudioManager在场景切换时保持不变
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

    // 调整BGM音量
    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        bgmSource.volume = bgmVolume;
    }

    // 调整音效音量
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;
    }

    // 播放音效
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
