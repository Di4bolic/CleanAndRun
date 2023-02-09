using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Player player;

    public GameObject projectil;

    public void FirePlayer(){
        //Le joueur crer un projectile qui part en arc de cercle et qui peut blesser le boss
        if (player.munitionsScore > 0 && player.stun==false)
        {
            var newTransform = transform.position + new Vector3(1.5f, 1.5f, 0);
            Instantiate(projectil, newTransform, Quaternion.identity);
            player.munitionsScore--;
            player.munitions.text = player.munitionsScore.ToString();
        }
    }
    
}
