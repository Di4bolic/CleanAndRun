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
    private bool stun = false;
    private float stunDelay = 1f;
    private float stunRunning = -1f;
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

    void Start()
    {
        // Trouve le mM
        mM = FindObjectOfType<ManagerManager>();
    }

    void Update()
    {
        //gère les actions du boss
        if (lifeBossCurrent <= 0 && bossAlive == true)
        {
            transformBossCurrent.position = new Vector3(11, 30, 0);
            bossAlive = false;
            lifeBarFIll2.SetActive(false);
            lifeBarBorder.SetActive(false);
            lifeBarBack.SetActive(false);

            respawnCurrent = Time.time + respawnDelay;
            NbBossKilled = NbBossKilled + 1;
            mM.nbrBossKilled = NbBossKilled;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //interaction entre les projectile du joueur et le boss
        if (other.gameObject.CompareTag("Projectil"))
        {
            lifeBossCurrent = lifeBossCurrent - currentBoss.GetComponent<Boss>().damage;
            Destroy(other.gameObject);
            lifeBarFIll.fillAmount = lifeBossCurrent / 100;
        }
    }


    public void SpawnBoss()
    {

        spawnBossAlea = Random.Range(1, 3);
        if (spawnBossAlea == 1)
        {
            currentBoss = binBoss;
        }
        else
        {
            currentBoss = tentacleBoss;
                //Instantiate(tentacleBoss, new Vector3(3, -4, 0), Quaternion.identity) as GameObject;
        }
        //initialise un boss avec ses stats propre
        if (Time.time >= respawnCurrent)
        {
            lifeBossCurrent = currentBoss.GetComponent<Boss>().lifeBossInitial;
            transformBossCurrent = currentBoss.GetComponent<Transform>();
            //lifeBossCurrent = lifeBossCurrentInitial;
            lifeBarFIll.fillAmount = 1f;
            //transformBossCurrent.position = new Vector3(3, -4, 0);
            Debug.Log("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
            currentBoss.SetActive(true);
            bossAlive = true;
            lifeBarFIll2.SetActive(true);
            lifeBarBorder.SetActive(true);
            lifeBarBack.SetActive(true);
            //this.GetComponent<Animator>().Play("BossIdle");
        }
    }

    public void HideBoss()
    //Place le boss en dehors de l'écran pour le cacher
    {
        //transformBossCurrent.position = new Vector3(23, -3, 0);
        bossAlive = true;
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
        this.GetComponent<Animator>().Play("BossIdle");
    }
}
