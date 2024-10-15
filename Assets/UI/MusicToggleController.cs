using UnityEngine;
using UnityEngine.UI;

public class MusicToggleController : MonoBehaviour
{
    public AudioSource bgmSource;  // 引用已有的背景音乐 AudioSource
    public Toggle musicToggle;     // 音乐开关的 Toggle

    void Start()
    {
        // 初始化 Toggle 的初始状态为 AudioSource 当前的 mute 状态
        musicToggle.isOn = !bgmSource.mute;  // 如果音频没有静音，Toggle 处于勾选状态

        // 监听 Toggle 的状态变化，控制音轨的静音
        musicToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // 当 Toggle 状态发生变化时调用
    private void OnToggleValueChanged(bool isOn)
    {
        bgmSource.mute = !isOn;  // 勾选时取消静音，取消勾选时静音
    }
}
