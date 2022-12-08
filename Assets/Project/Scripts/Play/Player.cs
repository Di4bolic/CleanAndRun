using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool cooldownSaut = false;
    int nbSaut=2;
    public Transform thierry;
    public Rigidbody m_Rigidbody;
    public float m_Thrust = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount >= 1 && cooldownSaut==false && nbSaut>0)
        {
            cooldownSaut = true;
            nbSaut = nbSaut - 1;
            //thierry.position = new Vector3(thierry.position.x, thierry.position.y+3, thierry.position.z);

            //if(nbSaut == 0 && )
            m_Rigidbody.velocity = Vector3.zero;
            m_Rigidbody.AddForce(0, m_Thrust, 0, ForceMode.Impulse);
        }

        if (Input.touchCount == 0 && cooldownSaut == true)
        {
            cooldownSaut = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        nbSaut = 2;
    }
}