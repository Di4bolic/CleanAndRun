using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    public ManagerManager mM;

    public Transform transformBossCurrent;
    public Player player;
    public bool bossAlive = false;
    public float lifeBossCurrent;
    public float lifeBossCurrentInitial;

    public Image lifeBarFIll;
    public GameObject lifeBarFIll2;
    public GameObject lifeBarBorder;
    public GameObject lifeBarBack;
    public GameObject lifeBarDisplay;

    public GameObject sputumBoss;
    public GameObject sputumBossFast;

    public ObstacleManager om;
    public float respawnCurrent = -1f;
    public float respawnDelay = 1f;

    public Animator animator;

    public int NbBossKilled = 0;

    public int damage;

    public int spawnBossAlea;

    public GameObject binBoss;
    public GameObject tentacleBoss;

    public GameObject currentBoss;
    public string nameBossCurrent;

    void Start()
    {
        // Trouve le mM
        mM = FindObjectOfType<ManagerManager>();
    }

    void Update()
    {
        //g�re les actions du boss
        if (lifeBossCurrent <= 0 && bossAlive == true)
        {
            //transformBossCurrent.position = new Vector3(11, 30, 0);
            currentBoss.SetActive(false);
            bossAlive = false;
            lifeBarFIll2.SetActive(false);
            lifeBarBorder.SetActive(false);
            lifeBarBack.SetActive(false);

            respawnCurrent = Time.time + respawnDelay;
            NbBossKilled = NbBossKilled + 1;
            mM.nbrBossKilled = NbBossKilled;
        }
    }


    public void UpdateLife()
    {
        Debug.Log("rererererererrerererrererrrrerrerererrerererrerererrererrere");
        lifeBossCurrent = currentBoss.GetComponent<Boss>().lifeBoss;
        Debug.Log(lifeBossCurrent);
        lifeBarFIll.fillAmount = (lifeBossCurrent *100/lifeBossCurrentInitial)/100;
        Debug.Log(lifeBossCurrent *100/lifeBossCurrentInitial/100);
    }


    public void SpawnBoss()
    {

        spawnBossAlea = Random.Range(1, 3);
        if (spawnBossAlea == 0)
        {
            currentBoss = binBoss;
        }
        else
        {
            currentBoss = tentacleBoss;
        }
        //initialise un boss avec ses stats propre
        if (Time.time >= respawnCurrent)
        {
            nameBossCurrent = currentBoss.GetComponent<Boss>().name;
            lifeBossCurrent = currentBoss.GetComponent<Boss>().lifeBossInitial;
            lifeBossCurrentInitial = currentBoss.GetComponent<Boss>().lifeBossInitial;
            currentBoss.GetComponent<Boss>().lifeBoss=currentBoss.GetComponent<Boss>().lifeBossInitial;
            transformBossCurrent = currentBoss.GetComponent<Transform>();
            lifeBarFIll.fillAmount = 1f;
            currentBoss.SetActive(true);
            bossAlive = true;
            lifeBarFIll2.SetActive(true);
            lifeBarBorder.SetActive(true);
            lifeBarBack.SetActive(true);
            //this.GetComponent<Animator>().Play("BossIdle");
        }
    }

    public void HideBoss()
    //Place le boss en dehors de l'�cran pour le cacher
    {
        //transformBossCurrent.position = new Vector3(23, -3, 0);
        lifeBarFIll2.SetActive(false);
        lifeBarBorder.SetActive(false);
        lifeBarBack.SetActive(false);
        currentBoss.SetActive(false);
    }

    public void ViewBoss()
    //Place le boss en face pour le rendre visible
    {
        //transformBossCurrent.position = new Vector3(3, -4, 0);
        //GetComponent<Rigidbody>().AddForce(-20, 0, 0, ForceMode.Impulse);
        currentBoss.SetActive(true);
        lifeBarFIll2.SetActive(true);
        lifeBarBorder.SetActive(true);
        lifeBarBack.SetActive(true);
        //this.GetComponent<Animator>().Play("BossIdle");
    }
}
