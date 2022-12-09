using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoixMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var tempVector = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Camera.main.nearClipPlane);
            var tempRay = Camera.main.ScreenPointToRay(tempVector);
            Physics.Raycast(tempRay, out var tempObject);
            var tempObjectConverted = tempObject.collider.GetComponent<MenuPiece>();
            if (tempObjectConverted != null)
            {
                if (tempObjectConverted.action == "Run")
                {
                   SceneManager.LoadScene("SampleScene");
                }
                if (tempObjectConverted.action == "Musique")
                {
                    SceneManager.LoadScene("MusiqueChoix");
                }
                if (tempObjectConverted.action == "Inventaire")
                {
                    SceneManager.LoadScene("Inventaire");
                }
            }


        }
    }
}
