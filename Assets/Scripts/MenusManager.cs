using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusManager : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public AudioSource background;
    public AudioSource menusMusic;

    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
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

    public void Quit() {
        Application.Quit();
    }
}
