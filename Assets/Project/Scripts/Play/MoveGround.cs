using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField]
    private GameObject gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager");        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * gM.GetComponent<ObstacleManager>().speed * Time.deltaTime;

        if (transform.position.x <= -30f)
        {
            transform.position += new Vector3(21.98f*3, 0, 0);
        }
    }
}
