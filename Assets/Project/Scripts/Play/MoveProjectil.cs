using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectil : MonoBehaviour
{
    float rotationSpeed = 300f;
    public Rigidbody m_Rigidbody;
    public float m_Thrustx = 0.01f;
    public float m_Thrusty = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody.AddForce(m_Thrustx, m_Thrusty, 0, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

        //transform.position += Vector3.right * projectilSpeed * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * -rotationSpeed;
        // Destruction du GameObject
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
}
