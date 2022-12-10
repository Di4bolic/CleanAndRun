using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BoutTir : MonoBehaviour
{
    public Player player;
    public bool clic = false;
    public Boss boss;
    public Transform thierry;
    public Shoot shoot; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (boss.bossEnCours == true)
        {
            thierry.position = new Vector3(7, -2, -1);
        }


        if (Input.touchCount > 0 && boss.bossEnCours == true)
        {
            var tempVector = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Camera.main.nearClipPlane);
            var tempRay = Camera.main.ScreenPointToRay(tempVector);
            Physics.Raycast(tempRay, out var tempObject);
            var tempObjectConverted = tempObject.collider.GetComponent<Tir>();
            Debug.Log(tempObjectConverted);
            if (tempObjectConverted != null)
            {
                shoot.tirJoueur();
            }
        }
    }
}
