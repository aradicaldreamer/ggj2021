using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CollisionAudio : MonoBehaviour
{
    [SerializeField] private string tagToCompare;
    [FMODUnity.EventRef] public string eventName;

    //FMOD.Studio.EventInstance collisionEventInstance;
    
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
        if (col.gameObject.CompareTag("Cat"))
        {
            // Launch sound event with audioEventToLaunch
            FMODUnity.RuntimeManager.PlayOneShot(eventName, transform.position);
            //Debug.Log("YAY!");
            
        }
    }

    // void OnCollisionExit2D(Collision2D col)
    // {
    //     if (col.gameObject.CompareTag(tagToCompare))
    //     {
    //         // Launch sound event with audioEventToLaunch
    //         Debug.Log("NAY!");
    //     }
    // }
}
