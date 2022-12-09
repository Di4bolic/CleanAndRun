using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsClick : MonoBehaviour
{
    public GameObject optionsButtons;
    public GameObject menuButtons1;
    public GameObject menuButtons2;

    bool isActive = false;
    bool isMoving = false;

    Vector3 newPosOptionsButtons;
    Vector3 oldPosOptionsButtons;

    Vector3 newPosMenuButtons1;
    Vector3 oldPosMenuButtons1;

    Vector3 newPosMenuButtons2;
    Vector3 oldPosMenuButtons2;

    bool doMove = false;

    float pourcentage;
    float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        optionsButtons.transform.position += new Vector3(0, 300, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (doMove)
        {
            optionsButtons.transform.position = Vector3.Lerp(oldPosOptionsButtons, newPosOptionsButtons, pourcentage);
            menuButtons1.transform.position = Vector3.Lerp(oldPosMenuButtons1, newPosMenuButtons1, pourcentage);
            menuButtons2.transform.position = Vector3.Lerp(oldPosMenuButtons2, newPosMenuButtons2, pourcentage);
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
            oldPosMenuButtons1 = menuButtons1.transform.position;
            oldPosMenuButtons2 = menuButtons2.transform.position;

            if (isActive)
            {
                newPosOptionsButtons = optionsButtons.transform.position + new Vector3(0, 300, 0);
                newPosMenuButtons1 = menuButtons1.transform.position + new Vector3(300, 0, 0);
                newPosMenuButtons2 = menuButtons2.transform.position + new Vector3(300, 0, 0);
            }
            else
            {
                newPosOptionsButtons = optionsButtons.transform.position + new Vector3(0, -300, 0);
                newPosMenuButtons1 = menuButtons1.transform.position + new Vector3(-300, 0, 0);
                newPosMenuButtons2 = menuButtons2.transform.position + new Vector3(-300, 0, 0);
            }

            doMove = true;
            isMoving = true;
        }
    }
}
