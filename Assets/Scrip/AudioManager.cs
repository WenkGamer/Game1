using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private void Start()
    {
        // Lấy volume đã lưu nếu có
        float volume = PlayerPrefs.GetFloat("MusicVol_dB", 0f);
        volumeSlider.value = volume;
        SetMusicVolume(volume);
    }

    public void SetMusicVolume(float dB)
    {
        audioMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVol_dB", dB);
    }
}
