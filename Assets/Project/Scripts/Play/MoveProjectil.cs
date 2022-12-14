using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectil : MonoBehaviour
{
    float projectilSpeed = 15f;
    float rotationSpeed = 300f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.right * projectilSpeed * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * -rotationSpeed;
        // Destruction du GameObject
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
}
