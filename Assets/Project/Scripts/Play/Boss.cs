using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Transform thierry;
    public Player player;
    public bool bossEnCours=false;
    public bool stun = false;
    public float stunDelay = 1f;
    public float stunEnCours = -1f;
    public int vieBoss = 100;
    public int munBoss = 0;

    public Image barreVieFill;
    public GameObject barreVieFill2;
    public GameObject barreVieCadre;
    public GameObject barreVieFond;
    public GameObject barreVieAffichage;

    public ObstacleManager om;
    // Start is called before the first frame update
    void Start()
    {
        stunEnCours = Time.time + stunDelay;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.time > stunEnCours && bossEnCours == false)
        {
            thierry.position = new Vector3(11, -1, 0);
            bossEnCours = true;
            munBoss = munBoss + player.NbDechetColl;
            barreVieFill2.SetActive(true);
            barreVieCadre.SetActive(true);
            barreVieFond.SetActive(true);
        }*/

        if (vieBoss <= 0 && bossEnCours == true)
        {
            thierry.position = new Vector3(11, 30, 0);
            bossEnCours =false;
            barreVieFill2.SetActive(false);
            barreVieCadre.SetActive(false);
            barreVieFond.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Projectil"))
        {
           vieBoss = vieBoss-5;
           Destroy(other.gameObject);
           barreVieFill.fillAmount = barreVieFill.fillAmount - 0.5f;
        }
    }


    public void SpawnBoss()
    {
        vieBoss = 100;
        barreVieFill.fillAmount = 1f;
        thierry.position = new Vector3(11, -1, 0);
        bossEnCours = true;
        munBoss = munBoss + player.NbDechetColl;
        barreVieFill2.SetActive(true);
        barreVieCadre.SetActive(true);
        barreVieFond.SetActive(true);
    }

}
