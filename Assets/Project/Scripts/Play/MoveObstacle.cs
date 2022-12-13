using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public GameObject gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*gM.GetComponent<ObstacleManager>().speed*Time.deltaTime;

        // Destruction du GameObject
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
