using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenusManager : MonoBehaviour {

    public GameObject pauseMenu;
    public AudioSource background;
    public AudioSource menusMusic;
    public Button muteButton;
    public Sprite musicOnImage;
    public Sprite musicOffImage;
    private bool muted;
    private bool GameIsPaused;

    private void Start()
    {
        muted = false;
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            ControlMusic();
        }
    }

    public void PauseMenu()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

   public void Resume() {
        background.UnPause();
        menusMusic.Pause();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
   }

    public void Pause() {
        background.Pause();
        menusMusic.Play();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        background.Play();
        menusMusic.Stop();
        //gameoverMenu.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ControlMusic()
    {
        if (muted)
        {
            UnMute();
        }
        else
        {
            Mute();
        }
    }

    public void Mute()
    {
        muteButton.GetComponent<Image>().sprite = musicOffImage;
        muted = true;
        AudioListener.volume = 0.0f;
    }

    public void UnMute()
    {
        muteButton.GetComponent<Image>().sprite = musicOnImage;
        muted = false;
        AudioListener.volume = 1.0f;
    }
}
