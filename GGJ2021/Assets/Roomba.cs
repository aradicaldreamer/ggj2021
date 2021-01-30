using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    [SerializeField] private string tagToCheck;

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
            Debug.Log(this.gameObject.name + "has found the cat!");
            
        }
    }
}
