using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomiBoss : MonoBehaviour
{
    public Transform transformSputum;
    public Rigidbody sputumRigidbody;
    public float m_Thrust = 0.01f;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sputumRigidbody.velocity = Vector3.zero;
        sputumRigidbody.AddForce(-m_Thrust,0, 0, ForceMode.Impulse);
        this.GetComponent<Animator>().Play("vomiBoss");
    }

    // Update is called once per frame
    void Update()
        //fais bouger le crachat
    {
        if (transformSputum.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
