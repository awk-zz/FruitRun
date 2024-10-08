using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider bgmVolumeSlider;  // BGM ����������
    public Slider sfxVolumeSlider;  // ��Ч����������

    private void Start()
    {
        // ��ʼ����������ֵΪ��ǰ������ֵ
        bgmVolumeSlider.value = AudioManager.instance.bgmSource.volume;
        sfxVolumeSlider.value = AudioManager.instance.sfxSource.volume;

        // ��ӻ������ļ����¼�������ʵʱ��������
        bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    // ���� BGM ����
    public void SetBGMVolume(float volume)
    {
        AudioManager.instance.SetBGMVolume(volume);
    }

    // ������Ч����
    public void SetSFXVolume(float volume)
    {
        AudioManager.instance.SetSFXVolume(volume);
    }
}
