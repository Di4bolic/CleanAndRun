using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTuto : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x >= -25)
        {
            transform.position += Vector3.left * 4 * Time.deltaTime;
        }
    }

}
