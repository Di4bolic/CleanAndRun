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

    public GameObject vomiBoss;

    public ObstacleManager om;
    public float respawnEnCours = -1f;
    public float respawnDelay = 1f;

    public bool attackPatern1 = false;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vieBoss <= 0 && bossEnCours == true )
        {
            thierry.position = new Vector3(11, 30, 0);
            bossEnCours =false;
            barreVieFill2.SetActive(false);
            barreVieCadre.SetActive(false);
            barreVieFond.SetActive(false);

            respawnEnCours = Time.time + stunDelay;
        }

        if (bossEnCours == true)
        {
            attackPatern1 = true;
        }
    }


    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Projectil"))
        {
           vieBoss = vieBoss-60;
           Destroy(other.gameObject);
           barreVieFill.fillAmount = barreVieFill.fillAmount - 0.6f;
        }
    }


    public void SpawnBoss()
    {
        if(Time.time >= respawnEnCours)
        {
            vieBoss = 100;
            barreVieFill.fillAmount = 1f;
            thierry.position = new Vector3(6, -4, 0);
            bossEnCours = true;
            munBoss = munBoss + player.NbDechetColl;
            barreVieFill2.SetActive(true);
            barreVieCadre.SetActive(true);
            barreVieFond.SetActive(true);
            this.GetComponent<Animator>().Play("BossIdle");
        }
    }

    public void paternBossAttack()
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = thierry.position + new Vector3(1, 3, 0);
        Instantiate(vomiBoss, newTransform, Quaternion.identity);
        animator.SetTrigger("finAttack");
    }
}
