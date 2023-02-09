using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionFallProj : MonoBehaviour
{
    public Transform transformproj;
    public Rigidbody rigidbodyProj;
    public float m_Thrust = 0.01f;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyProj.velocity = Vector3.zero;
        rigidbodyProj.AddForce(-m_Thrust,0, 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
        //supprime le Projectile quand il va trop loin
    {
        if (transformproj.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}

