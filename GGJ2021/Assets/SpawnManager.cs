using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private bool isSpawning = true;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject roombaContainer;
    [SerializeField] private GameObject roombaPrefab;
    [SerializeField] private float spawnRate = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoombas());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoombas()
    {
        yield return new WaitForSeconds(1.0f);
        while (isSpawning)
        {
            GameObject newRoomba = Instantiate<GameObject>(roombaPrefab, spawnPoints[Random.Range(0,spawnPoints.Length)].position, Quaternion.identity);
            newRoomba.transform.parent = roombaContainer.transform;
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void ToggleSpawning()
    {
        isSpawning = !isSpawning;
    }
}
