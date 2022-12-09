using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClicBoutColl : MonoBehaviour
{
    public Player player;
    public bool clic=false;
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
            var tempObjectConverted = tempObject.collider.GetComponent<BoutColl>();
            if (tempObjectConverted != null)
            { 
                clic=true;
                Debug.Log("boot");
                Debug.Log(clic);
                Debug.Log("boot");


                var tempVector2 = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                var tempRay2 = Camera.main.ScreenPointToRay(tempVector2);
                Physics.Raycast(tempRay, out var tempObject2);
                var tempObjectConverted2 = tempObject2.collider.GetComponent<Dechet>();
                Debug.Log(tempObjectConverted2);
                if (tempObjectConverted2 != null)
                {
                    Destroy(tempObjectConverted2);
                    Debug.Log("detruuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuir");
                }
            }
        }
        
                //if (player.OnCollisionStay())
                /*
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
                }*/

    }

    /*public void Collecte(){
        if (Input.touchCount > 0)
        {
            var tempVector = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Camera.main.nearClipPlane);
            var tempRay = Camera.main.ScreenPointToRay(tempVector);
            Physics.Raycast(tempRay, out var tempObject);
            var tempObjectConverted = tempObject.collider.GetComponent<BoutColl>();
            if (tempObjectConverted != null)
            { 
                clic=true;
                Debug.Log("boot");
                Debug.Log(clic);
                Debug.Log("boot");
            }
        }
    }*/
}
