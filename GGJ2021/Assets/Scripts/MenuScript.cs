using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
  
  [FMODUnity.EventRef] public string musicTrackEvent;

  public FMOD.Studio.EventInstance backgroundMusic;

  void Start()
  {
        if (musicTrackEvent != null)
        {
          backgroundMusic = FMODUnity.RuntimeManager.CreateInstance(musicTrackEvent);
          FMOD.Studio.EventDescription backgroundMusicEventDescription;
          backgroundMusic.getDescription(out backgroundMusicEventDescription);

          backgroundMusic.start();
        }
  }

  public void PlayGame ()
  {
    backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    SceneManager.LoadScene("Game");
  }

  public void QuitGame()
  {
    Debug.Log("QUIT!");
    backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    Application.Quit();
  }

  public void GOtoMain ()
  {
    backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    SceneManager.LoadScene("Mainmenu");
  }
}
