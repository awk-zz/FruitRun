using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioSource bgmSource;  // ±≥æ∞“Ù¿÷“Ù‘¥

    // øÿ÷∆±≥æ∞“Ù¿÷µƒ≤•∑≈◊¥Ã¨
    public void ToggleBGM(bool isOn)
    {
        if (isOn)
        {
            // ª÷∏¥≤•∑≈±≥æ∞“Ù¿÷
            if (!bgmSource.isPlaying)
            {
                bgmSource.Play();
            }
        }
        else
        {
            // ‘›Õ£±≥æ∞“Ù¿÷
            if (bgmSource.isPlaying)
            {
                bgmSource.Pause();
            }
        }
    }
}
