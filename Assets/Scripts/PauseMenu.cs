using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioSource audioSource;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        audioSource = GetComponent<AudioSource>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            { 
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resume");

        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;

        audioSource.Play();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;

        GameIsPaused = true;

        audioSource.Pause();
    }

    public void LoadMenu()
    {
        Debug.Log("Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
