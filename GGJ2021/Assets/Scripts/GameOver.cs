using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
  public TMP_Text timeText;
  public TMP_Text besttimeText;
    // Start is called before the first frame update
    void Awake()
    {
      Cursor.visible = true;
      timeText.text = "Time: " + PlayerPrefs.GetInt("Time",0).ToString()+"s";
      besttimeText.text = "Best Time: " + PlayerPrefs.GetInt("BestTime",0).ToString()+"s";
    }

}
