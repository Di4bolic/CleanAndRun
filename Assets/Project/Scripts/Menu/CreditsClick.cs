using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsClick : MonoBehaviour
{
    public GameObject creditsButtons;
    public GameObject maskGris;

    bool isActive = false;
    bool isMoving = false;

    Vector3 newPosCreditsButtons;
    Vector3 oldPosCreditsButtons;

    bool doMove = false;

    float pourcentage;
    float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        creditsButtons.transform.position += new Vector3(0, 1200, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (doMove)
        {
            creditsButtons.transform.position = Vector3.Lerp(oldPosCreditsButtons, newPosCreditsButtons, pourcentage);
            pourcentage += speed;
            speed /= 1.001f;

            if (pourcentage >= 1)
            {
                doMove = false;
                isMoving = false;
                pourcentage = 0;
                speed = 0.05f;

                if (isActive)
                {
                    isActive = false;
                }
                else
                {
                    isActive = true;
                }
            }
        }
    }

    public void MoveCreditsButtons()
    {
        if (isMoving == false)
        {
            oldPosCreditsButtons = creditsButtons.transform.position;

            if (isActive)
            {
                newPosCreditsButtons = creditsButtons.transform.position + new Vector3(0, 1200, 0);
                maskGris.SetActive(false);
            }
            else
            {
                newPosCreditsButtons = creditsButtons.transform.position + new Vector3(0, -1200, 0);
                maskGris.SetActive(true);
            }

            doMove = true;
            isMoving = true;
        }
    }
}
