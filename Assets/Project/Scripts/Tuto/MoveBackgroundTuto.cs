using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundTuto : MonoBehaviour
{
    public GameManagerTuto gMT;
    private float lengthOfMusic;

    [SerializeField]
    private Transform finMove;

    private Vector3 oldPos;

    private float pourcentage = 0f;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        lengthOfMusic = gMT.duration;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(oldPos, finMove.position, pourcentage);
        pourcentage += Time.deltaTime/lengthOfMusic;
    }
}
