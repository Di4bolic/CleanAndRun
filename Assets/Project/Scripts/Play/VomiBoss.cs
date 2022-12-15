using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomiBoss : MonoBehaviour
{
    public Transform thierry;
    public Rigidbody m_Rigidbody;
    public float m_Thrust = 0.01f;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.AddForce(-m_Thrust,0, 0, ForceMode.Impulse);
        this.GetComponent<Animator>().Play("vomiBoss");
    }

    // Update is called once per frame
    void Update()
    {
        if (thierry.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
