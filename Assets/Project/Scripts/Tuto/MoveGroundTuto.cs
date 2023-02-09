using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundTuto : MonoBehaviour
{
    [SerializeField]
    private GameObject gMT;
    // Start is called before the first frame update
    void Start()
    {
        gMT = GameObject.Find("GameManagerTuto");        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * gMT.GetComponent<GameManagerTuto>().speed * Time.deltaTime;

        if (transform.position.x <= -30f)
        {
            transform.position += new Vector3(21.98f*3, 0, 0);
        }
    }
}
