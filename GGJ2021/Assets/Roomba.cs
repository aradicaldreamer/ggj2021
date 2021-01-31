using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Roomba : MonoBehaviour
{
    [SerializeField] private string tagToCheck;
    [FMODUnity.EventRef] public string eventName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(tagToCheck))
        {
            // Launch Game Over Event here
            //Debug.Log(this.gameObject.name + "has found the cat!");
            GameOver();
        }
    }

    public void GameOver()
    {
        FMODUnity.RuntimeManager.PlayOneShot(eventName, transform.position);
        SceneManager.LoadScene("GameOver");
    }
}
