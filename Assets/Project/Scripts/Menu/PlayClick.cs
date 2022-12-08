using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClick : MonoBehaviour
{
    public GameObject buttons;

    bool active = false;
    float pourcentage = 0f;
    float x = 0.01f;
    Vector3 newPos;

    bool lanceAugmente = false;

    // Start is called before the first frame update
    void Start()
    {
        if (active == false)
        {
            buttons.transform.position -= new Vector3(0, -500, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lanceAugmente == true)
        {
            AugmentePourcentage();
        }
    }

    public void MoveButtons()
    {
        if (active)
        {
            newPos = buttons.transform.position - new Vector3(0, -500, 0);
        }
        else
        {
            newPos = buttons.transform.position - new Vector3(0, 500, 0);
        }

        lanceAugmente = true;

        if (active)
        {
            active = false;
        }
        else
        {
            active = true;
        }
    }

    void AugmentePourcentage()
    {
        if (pourcentage < 1)
        {
            buttons.transform.position = Vector3.Lerp(buttons.transform.position, newPos, pourcentage);
            pourcentage += x;
            x /= 1.1f;
        }
        else
        {
            lanceAugmente = false;
            pourcentage = 0;
        }
    }
}
