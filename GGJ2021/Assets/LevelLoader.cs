using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  public Animator animator;
  public int levelToLoad;

    public void FadeToLevel (int levelIndex)
    {
      levelToLoad = levelIndex;
      animator.SetTrigger("fadeout");
    }

    public void OnFadeComplete ()
    {
      SceneManager.LoadScene(levelToLoad);
    }
}
