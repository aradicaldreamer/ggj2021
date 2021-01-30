using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TImer : MonoBehaviour
{
   public GameObject textDisplay;
   public int secondsLeft = 0;
   public bool takingAway = false;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<TMP_Text>().text = "Time: " + secondsLeft+"s";
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > -1)
        {
          StartCoroutine(TimeTake());
        }
    }

    IEnumerator TimeTake()
    {
      takingAway = true;
      yield return new WaitForSeconds(1);
      secondsLeft +=1;
      if (secondsLeft < 10) {
        textDisplay.GetComponent<TMP_Text>().text = "Time: 0"+ secondsLeft+"s";
      }
      else{
      textDisplay.GetComponent<TMP_Text>().text = "Time: "+ secondsLeft +"s";
    }
      takingAway = false;
    }
}
