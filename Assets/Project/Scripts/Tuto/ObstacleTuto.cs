using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTuto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= -25)
        {
            transform.position += Vector3.left * 4 * Time.deltaTime;
        }
    }

}
