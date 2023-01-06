using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PiedJoueur : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            player.m_Rigidbody.velocity = Vector3.zero;
            player.nbSaut = 2;
        }
    }
}
