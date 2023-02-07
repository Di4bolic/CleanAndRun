using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToleranceHead : MonoBehaviour
{
    public Player player;
    public bool inGroundContact = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(1, 1.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Entre dans ground");
            inGroundContact = true;
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Sort du ground");
            inGroundContact = false;
        }
    }
}
