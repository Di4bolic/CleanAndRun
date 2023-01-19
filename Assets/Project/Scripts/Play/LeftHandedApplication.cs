using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandedApplication : MonoBehaviour
{
    public ManagerManager mM;
    public RectTransform jumpBut;
    public RectTransform shootBut;

    // Start is called before the first frame update
    void Start()
    {
        mM = FindObjectOfType<ManagerManager>();
        Debug.Log(mM.leftHanded);
        if (mM.leftHanded)
        {
            jumpBut.anchorMin = new Vector2(1, 0);
            jumpBut.anchorMax = new Vector2(1, 0);
            jumpBut.anchoredPosition = new Vector3(-178, 75, 0);

            shootBut.anchorMin = new Vector2(0, 0);
            shootBut.anchorMax = new Vector2(0, 0);
            shootBut.anchoredPosition = new Vector3(178, 75, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
