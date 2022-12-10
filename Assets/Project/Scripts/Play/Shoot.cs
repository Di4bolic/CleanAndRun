using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public ClicBoutColl cBC;

    public GameObject projectil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cBC.munitionsScore > 0)
        {
            Instantiate(projectil, transform.position, Quaternion.identity);
        }
    }
}
