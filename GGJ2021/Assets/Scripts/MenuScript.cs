using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Playgame ()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void GOtoMain ()
    {
      SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
      Debug.Log("QUIT!");
      Application.Quit();
    }

}
