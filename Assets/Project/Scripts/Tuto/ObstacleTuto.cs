using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTuto : MonoBehaviour
{
    public GameObject gMT;
    // Start is called before the first frame update
    void Start()
    {
        gMT = GameObject.Find("GameManagerTuto");
        gMT.GetComponent<GameManagerTuto>().speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * gMT.GetComponent<GameManagerTuto>().speed * Time.deltaTime;
    }
}
