using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsClick : MonoBehaviour
{
    public GameObject optionsButtons;
    public GameObject maskGris;

    bool isActive = false;
    bool isMoving = false;

    Vector3 newPosOptionsButtons;
    Vector3 oldPosOptionsButtons;

    bool doMove = false;

    float pourcentage;
    float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        optionsButtons.transform.position += new Vector3(0, 1200, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (doMove)
        {
            optionsButtons.transform.position = Vector3.Lerp(oldPosOptionsButtons, newPosOptionsButtons, pourcentage);
            pourcentage += speed;
            speed /= 1.05f;

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

    public void MoveOptionsButtons()
    {
        if (isMoving == false)
        {
            oldPosOptionsButtons = optionsButtons.transform.position;

            if (isActive)
            {
                newPosOptionsButtons = optionsButtons.transform.position + new Vector3(0, 1200, 0);
                maskGris.SetActive(false);
            }
            else
            {
                newPosOptionsButtons = optionsButtons.transform.position + new Vector3(0, -1200, 0);
                maskGris.SetActive(true);
            }

            doMove = true;
            isMoving = true;
        }
    }
}
