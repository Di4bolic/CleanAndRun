using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHanded : MonoBehaviour
{
    public ManagerManager mM;
    public Image check;

    // Start is called before the first frame update
    void Start()
    {
        mM = FindObjectOfType<ManagerManager>();
        if (mM.leftHanded)
        {
            check.gameObject.SetActive(true);
        }
        else
        {
            check.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        if (mM.leftHanded)
        {
            mM.leftHanded = false;
            check.gameObject.SetActive(false);
        }
        else
        {
            mM.leftHanded = true;
            check.gameObject.SetActive(true);
        }
    }
}
