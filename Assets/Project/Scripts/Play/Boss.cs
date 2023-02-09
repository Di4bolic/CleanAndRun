using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public ManagerManager mM;

    public Transform transformBoss;
    public Player player;
    public bool bossAlive=false;
    private bool stun = false;
    private float stunDelay = 1f;
    private float stunRunning = -1f;
    public float lifeBoss;
    public float lifeBossInitial;
    //public int munBoss = 0;

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

    public int NbBossKilled=0;

    public int damage;

    void Start()
    {
        // Trouve le mM
        mM = FindObjectOfType<ManagerManager>();
    }

    void Update()
    {
        //gère les actions du boss
        if (lifeBoss <= 0 && bossAlive == true )
        {
            transformBoss.position = new Vector3(11, 30, 0);
            bossAlive =false;
            lifeBarFIll2.SetActive(false);
            lifeBarBorder.SetActive(false);
            lifeBarBack.SetActive(false);

            respawnCurrent = Time.time + respawnDelay;
            NbBossKilled=NbBossKilled+1;
            mM.nbrBossKilled = NbBossKilled;
        }
    }


    private void OnTriggerEnter(Collider other){
        //interaction entre les projectile du joueur et le boss
        if (other.gameObject.CompareTag("Projectil"))
        {
           lifeBoss = lifeBoss - damage;
           Destroy(other.gameObject);
           lifeBarFIll.fillAmount = lifeBoss / 100;
        }
    }


    public void SpawnBoss()
    {
        //initialise un boss avec ses stats propre
        if(Time.time >= respawnCurrent)
        {
            lifeBoss = 100;
            lifeBossInitial = 100;
            lifeBarFIll.fillAmount = 1f;
            transformBoss.position = new Vector3(3, -4, 0);
            //GetComponent<Rigidbody>().AddForce(-20, 0, 0, ForceMode.Impulse);
            bossAlive = true;
            lifeBarFIll2.SetActive(true);
            lifeBarBorder.SetActive(true);
            lifeBarBack.SetActive(true);
            this.GetComponent<Animator>().Play("BossIdle");
        }
    }

    public void HideBoss()
    //Place le boss en dehors de l'écran pour le cacher
    {
        transformBoss.position = new Vector3(23, -3, 0);
        bossAlive = true;
        lifeBarFIll2.SetActive(false);
        lifeBarBorder.SetActive(false);
        lifeBarBack.SetActive(false);
    }

    public void ViewBoss()
    //Place le boss en face pour le rendre visible
    {
        transformBoss.position = new Vector3(3, -4, 0);
        //GetComponent<Rigidbody>().AddForce(-20, 0, 0, ForceMode.Impulse);
        lifeBarFIll2.SetActive(true);
        lifeBarBorder.SetActive(true);
        lifeBarBack.SetActive(true);
        this.GetComponent<Animator>().Play("BossIdle");
    }

    public void PaternBossAttackFast()
     //Pattern dans lequel le boss tire un projectile rouge dans la direction du joueur en reprenant ses coordonnées
    {
        this.GetComponent<Animator>().Play("BossAttack");
        float posProj = player.transform.position.y + 1.3f;
        posProj = Mathf.Clamp(posProj, -2.8f, 3.8f);
        var newTransform = new Vector3(transform.position.x, posProj, transformBoss.position.z);
        Instantiate(sputumBossFast, newTransform, Quaternion.identity);
        animator.SetTrigger("finAttack");
    }
}
