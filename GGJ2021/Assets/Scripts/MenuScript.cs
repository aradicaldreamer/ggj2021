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
<<<<<<< Updated upstream
    backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
    backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
=======
>>>>>>> Stashed changes
    SceneManager.LoadScene("Mainmenu");
  }
}
