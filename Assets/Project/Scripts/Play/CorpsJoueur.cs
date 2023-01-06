using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using TMPro;

public class CorpsJoueur : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            player.stun = true;
            player.stunEnCours = Time.time + player.stunDelay;

            //m_Rigidbody.GetComponent<Renderer>().material.color = Color.red;
            //animator.SetTrigger("Stun");
            player.GetComponent<Animator>().Play("playerStun");
        }

        if (other.gameObject.CompareTag("Collectible") && player.stun == false)
        {
            Destroy(other.gameObject);
            player.NbDechetColl = player.NbDechetColl + 1;

            // Gestion UI
            player.garbagesScore++;
            player.munitionsScore += 3;
            player.garbages.text = "Garbages : " + player.garbagesScore.ToString();
            player.munitions.text = "Munitions : " + player.munitionsScore.ToString();

            // Nombre de déchêts mis à jour dans le mM
            player.mM.recoltedGarbages = player.garbagesScore;
        }
    }
}
