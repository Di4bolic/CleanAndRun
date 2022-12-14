using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Descente : MonoBehaviour
{
    public Player player;
    public Rigidbody m_Rigidbody;
    public float m_Thrust;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void JumpDown()
    {
        //m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.AddForce(0, -m_Thrust, 0, ForceMode.Impulse);
    }
}
