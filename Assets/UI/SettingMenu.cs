using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider bgmVolumeSlider;  // BGM 音量滑动条
    public Slider sfxVolumeSlider;  // 音效音量滑动条

    private void Start()
    {
        // 初始化滑动条的值为当前的音量值
        bgmVolumeSlider.value = AudioManager.instance.bgmSource.volume;
        sfxVolumeSlider.value = AudioManager.instance.sfxSource.volume;

        // 添加滑动条的监听事件，用于实时调整音量
        bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    // 调整 BGM 音量
    public void SetBGMVolume(float volume)
    {
        AudioManager.instance.SetBGMVolume(volume);
    }

    // 调整音效音量
    public void SetSFXVolume(float volume)
    {
        AudioManager.instance.SetSFXVolume(volume);
    }
}
