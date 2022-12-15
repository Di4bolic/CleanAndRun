using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClick : MonoBehaviour
{
    public GameObject musicsButtons;

    bool isActive = false;
    bool isMoving = false;

    Vector3 newPosMusicsButtons;
    Vector3 oldPosMusicsButtons;

    bool doMove = false;

    float pourcentage;
    float speed = 0.05f;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        musicsButtons.transform.position += new Vector3(0, 300, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (doMove)
        {
            musicsButtons.transform.position = Vector3.Lerp(oldPosMusicsButtons, newPosMusicsButtons, pourcentage);
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

    public void MoveMusicsButtons()
    {
        if (isMoving == false)
        {
            oldPosMusicsButtons = musicsButtons.transform.position;

            if (isActive)
            {
                newPosMusicsButtons = musicsButtons.transform.position + new Vector3(0, 300, 0);
            }
            else
            {
                newPosMusicsButtons = musicsButtons.transform.position + new Vector3(0, -300, 0);
            }

            doMove = true;
            isMoving = true;
        }
    }
}
