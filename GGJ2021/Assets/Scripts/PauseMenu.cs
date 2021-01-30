using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

  public static bool GameIsPaused = false;
  public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
      }

    public void Resume()
    {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;  // between 1 and 0 can be used to create slow motion
      GameIsPaused = false;
    }

    public void Pause()
    {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }
    public void LoadMenu()
    {
      Time.timeScale = 1f;
      SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
      Debug.Log("QUIT!");
      Application.Quit();
    }

}
