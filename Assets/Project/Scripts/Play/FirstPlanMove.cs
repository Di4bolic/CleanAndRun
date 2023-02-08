using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlanMove : MonoBehaviour
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
        transform.position += Vector3.left * gM.GetComponent<ObstacleManager>().speed * 1.5f * Time.deltaTime;

        // Destruction du GameObject
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
