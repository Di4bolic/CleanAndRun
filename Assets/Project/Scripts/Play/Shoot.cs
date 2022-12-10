using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Player player;

    public GameObject projectil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
    }

    public void tirJoueur(){
        if (player.munitionsScore > 0)
            {
                Instantiate(projectil, transform.position, Quaternion.identity);
                player.munitionsScore--;
                player.munitions.text = "Munitions :" + player.munitionsScore.ToString();
            }
        }
    
}
