
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
    private bool isSlideOpen;
    public Button pauseButton;       // nút pause
    public Sprite pauseSprite;       // sprite khi đang chơi (hiện nút Pause)
    public Sprite playSprite;        // sprite khi đang pause (hiện nút Play)
    public GameObject Music;
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
        isSlideOpen = !isSlideOpen;
        Slide.SetActive(isSlideOpen);

        if (isSlideOpen)
        {
            Slide.SetActive(false);
            
        }
        else
        {
            Slide.SetActive(true);
           
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
        SceneManager.LoadScene(1);
    }
    public void Screen2()
    {
        SceneManager.LoadScene(2);
    }
    public void Screen3()
    {
        SceneManager.LoadScene(3);
    }
    public void Screen4()
    {
        SceneManager.LoadScene(4);
    }
    public void Screen5()
    {
        SceneManager.LoadScene(5);
    }
    public void ExitMenuScreen()
    {
        MenuScreen.SetActive(false);
    }
    #endregion

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if(currentIndex < totalScenes)
        {
            SceneManager.LoadScene(currentIndex+1);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }

        Time.timeScale = 1;
    }
    public void TogglePause()
    {
        if (isSlideOpen)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Pause()
    {
        Slide.SetActive(true);
        Time.timeScale = 0;
        isSlideOpen = true;
        Music.SetActive(false);

        // đổi sprite nút sang Play
        pauseButton.image.sprite = playSprite;
    }

    public void Resume()
    {
        Slide.SetActive(false);
        Time.timeScale = 1;
        isSlideOpen = false;
        Music.SetActive(true);

        // đổi sprite nút sang Pause
        pauseButton.image.sprite = pauseSprite;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
