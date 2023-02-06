using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tolerance : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(1, 0.2f, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Ground" && other.gameObject.tag != "Pieds" && other.gameObject.tag != "Projectile")
        {
            player.transform.position += new Vector3(0, 0.3f, 0);
        }
    }
}
