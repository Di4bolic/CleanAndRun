using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManager : MonoBehaviour
{
    public GameObject gM;

    public Collider2D col;

    bool onCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (onCollision)
        {
            transform.position += Vector3.left * gM.GetComponent<ObstacleManager>().speed;
        }
        else
        {
            transform.position += Vector3.left * gM.GetComponent<ObstacleManager>().speed * 1.3f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onCollision = true;
    }
}
