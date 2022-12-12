using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Descente : MonoBehaviour
{
    public Player player;
    public Rigidbody m_Rigidbody;
    public float m_Thrust = 0.01f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var tempVector = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Camera.main.nearClipPlane);
            var tempRay = Camera.main.ScreenPointToRay(tempVector);
            Physics.Raycast(tempRay, out var tempObject);
            var tempObjectConverted = tempObject.collider.GetComponent<JumpDown>();
            if (tempObjectConverted != null)
            {
                //m_Rigidbody.velocity = Vector3.zero;
                m_Rigidbody.AddForce(0, -m_Thrust, 0, ForceMode.Impulse);
            }
        }
    }
}
