using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using TMPro;

public class Player : MonoBehaviour
{
    // Manager Manager
    public ManagerManager mM;

    // Gestion UI
    public TextMeshProUGUI garbages;
    public TextMeshProUGUI munitions;
    public int garbagesScore = 0;
    public int munitionsScore = 0;

    bool cooldownSaut = false;
    int nbSaut=2;
    public Transform thierry;
    public Rigidbody m_Rigidbody;
    public float m_Thrust = 0.01f;
    public ClicBoutColl clicBouton;
    public bool stun=false;
    public float stunDelay = 1f;
    public float stunEnCours = -1f;
    public int NbDechetColl = 0;
    public float maxSpeed;


    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // Trouve le mM
        mM = FindObjectOfType<ManagerManager>();

        m_Rigidbody = GetComponent<Rigidbody>();
        maxSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0 && cooldownSaut == true)
        {
            cooldownSaut = false;
        }

        if (Time.time > stunEnCours)
        {
            //animator.ResetTrigger("");
            //animator.SetTrigger("Run");
            stun = false;
            this.GetComponent<Animator>().Play("RunAnim");
            m_Rigidbody.GetComponent<Renderer>().material.color = Color.white;
        }
      
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")) {
            m_Rigidbody.velocity = Vector3.zero;
            nbSaut = 2;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            stun = true;
            stunEnCours = Time.time + stunDelay;

            m_Rigidbody.GetComponent<Renderer>().material.color = Color.red;
            //animator.SetTrigger("Stun");
            this.GetComponent<Animator>().Play("playerStun");
        }

        if (other.gameObject.CompareTag("Collectible") && stun == false)
        {
            Destroy(other.gameObject);
            NbDechetColl = NbDechetColl + 1;

            // Gestion UI
            garbagesScore++;
            munitionsScore += 3;
            garbages.text = "Garbages : " + garbagesScore.ToString();
            munitions.text = "Munitions : " + munitionsScore.ToString();

            // Nombre de déchêts mis à jour dans le mM
            mM.recoltedGarbages = garbagesScore;
        }
    }   

    public void JumpPlayer(){
        if (Input.touchCount >= 1 && cooldownSaut == false && nbSaut > 0 && Time.time > stunEnCours)
        {
                cooldownSaut = true;
                nbSaut = nbSaut - 1;

                m_Rigidbody.velocity = Vector3.zero;
                m_Rigidbody.AddForce(0, m_Thrust, 0, ForceMode.Impulse);
        }
    }
}