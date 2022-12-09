using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicManager : MonoBehaviour
{
    public Player player;
    public ClicBoutColl UIColl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      /*  if (Input.touchCount > 0)
        {
            var tempVector = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Camera.main.nearClipPlane);
            var tempRay = Camera.main.ScreenPointToRay(tempVector);
            Physics.Raycast(tempRay, out var tempObject);
            var tempObjectConverted = tempObject.collider.GetComponent<BoutColl>();
            if (tempObjectConverted != null)
            { 
                UIColl.Collecte();
                Debug.Log("collecte");
            }else{
                player.Jump();
                Debug.Log("jump");
            }
        }
    */}
}
