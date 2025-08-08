using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public GameObject Slide;
    public GameObject MenuScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("MusicVol_dB", 0f);
        volumeSlider.value = volume;
        SetMusicVolume(volume);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void start()
    {
        SceneManager.LoadScene(1);
    }

    public void Setting()
    {
        /*bool isOpen = false;
        isOpen = !isOpen;
        if (isOpen)
        {
            Slide.SetActive(true);
        }
        else 
        { 
            Slide.SetActive(false); 
        }*/
        if (Slide.activeSelf)
        {
            Slide.SetActive(false);
            Debug.Log("Lần 2: Tắt Slide");
        }
        else
        {
            Slide.SetActive(true);
            Debug.Log("Lần 1: Mở Slide");
        }

    }
    public void SetMusicVolume(float dB)
    {
        audioMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVol_dB", dB);
    }

    public void ScreenMenu()
    {
        MenuScreen.SetActive(true);
    }

    #region Screen
    public void Screen1()
    {

    }
    public void Screen2()
    {

    }
    public void Screen3()
    {

    }
    public void Screen4()
    {

    }
    public void Screen5()
    {

    }
    public void ExitMenuScreen()
    {
        MenuScreen.SetActive(false);
    }
    #endregion
}
