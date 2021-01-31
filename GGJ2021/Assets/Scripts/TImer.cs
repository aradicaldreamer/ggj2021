using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TImer : MonoBehaviour
{
   public GameObject textDisplay;
   public int seconds = 0;
   public bool takingAway = false;
   public TMP_Text timeprefs;
   public TMP_Text besttimeprefs;
    // Start is called before the first frame update
    void Start()
    {
        //timeprefs.text  = PlayerPrefs.GetInt("Time", 0).ToString();
        //besttimeprefs.text  = PlayerPrefs.GetInt("BestTime", 0).ToString();
        textDisplay.GetComponent<TMP_Text>().text = ""+seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && seconds > -1)
        {
          StartCoroutine(TimeTake());
        }
        PlayerPrefs.SetInt("Time", seconds);
        if (seconds > PlayerPrefs.GetInt("BestTime",0))
        {
          PlayerPrefs.SetInt("BestTime", seconds);
          //besttimeprefs.text = seconds.ToString();
        }
        GameOver();
    }

    IEnumerator TimeTake()
    {
      takingAway = true;
      yield return new WaitForSeconds(1);
      seconds +=1;
      if (seconds < 10) {
        textDisplay.GetComponent<TMP_Text>().text = "0"+ seconds;
      }
      else{
      textDisplay.GetComponent<TMP_Text>().text = ""+seconds;
    }
      takingAway = false;
    }

    public void GameOver()
    {
      if (Input.GetKeyDown("space")) {
      SceneManager.LoadScene("GameOver");
    }
    }
}
