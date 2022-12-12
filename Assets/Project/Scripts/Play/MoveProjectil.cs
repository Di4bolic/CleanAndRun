using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectil : MonoBehaviour
{
    public float projectilSpeed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(10, 10);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.right* projectilSpeed;
        // Destruction du GameObject
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
}