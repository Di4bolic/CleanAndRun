using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGarbages : MonoBehaviour
{
    public GameObject garbagePrefab;
    public GameObject spawnPoint;

    float chrono;

    // Start is called before the first frame update
    void Start()
    {
        chrono = 5f + Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (chrono > 0)
        {
            chrono -= Time.deltaTime;
        }
        else
        {
            chrono = 5f + Random.Range(0, 5);
            SpawnGarbage();
        }
    }

    void SpawnGarbage()
    {
        Instantiate(garbagePrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
