using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using TMPro;

public class Player : MonoBehaviour
{
    // Transform of the GameObject you want to shake
    public Transform transformCam;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.5f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;


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
    //public ClicBoutColl clicBouton;
    public bool stun=false;
    public float stunDelay = 1f;
    public float stunEnCours = -1f;
    public int NbDechetColl = 0;
    public float maxSpeed;


    public Animator animator;


    public SpriteRenderer spriteRenderer;
    public Sprite newSpriteSaut1;
    public Sprite newSpriteSaut2;

    void Awake()
    {
        if (transformCam == null)
        {
            transformCam = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        initialPosition = transformCam.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Trouve le mM
        mM = FindObjectOfType<ManagerManager>();

        m_Rigidbody = GetComponent<Rigidbody>();
        maxSpeed = 0.01f;

        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transformCam.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transformCam.localPosition = initialPosition;
        }



        if (Input.touchCount == 0 && cooldownSaut == true)
        {
            cooldownSaut = false;
        }

        if (Time.time > stunEnCours)
        {
            //animator.ResetTrigger("");
            //animator.SetTrigger("Run");
            stun = false;
            animator.SetTrigger("Run");
            //this.GetComponent<Animator>().Play("RunAnim");
            //m_Rigidbody.GetComponent<Renderer>().material.color = Color.white;

        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")) {
            m_Rigidbody.velocity = Vector3.zero;
            nbSaut = 2;

            if (stun==false)
            {
                animator.SetTrigger("Run");
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            shakeDuration = 0.2f;
            stun = true;
            stunEnCours = Time.time + stunDelay;

            //m_Rigidbody.GetComponent<Renderer>().material.color = Color.red;
            //animator.SetTrigger("Stun");
            //this.GetComponent<Animator>().Play("playerStun");
            animator.SetTrigger("Stun");
        }

        if (other.gameObject.CompareTag("Collectible") && stun == false)
        {
            Destroy(other.gameObject);
            NbDechetColl = NbDechetColl + 1;

            // Gestion UI
            garbagesScore++;
            munitionsScore += 1;
            garbages.text = garbagesScore.ToString();
            munitions.text = munitionsScore.ToString();

            // Nombre de d�ch�ts mis � jour dans le mM
            mM.recoltedGarbages = garbagesScore;
        }

        if (other.gameObject.CompareTag("ProjectilThunder"))
        {
            Destroy(other.gameObject);
            // Gestion UI
            munitionsScore -= 3;
            if(munitionsScore<0){
                munitionsScore=0;
            }
            munitions.text = munitionsScore.ToString();

        }
    }   

    public void JumpPlayer(){
        if (cooldownSaut == false && nbSaut > 0 && Time.time > stunEnCours)
        {
            cooldownSaut = true;
            nbSaut = nbSaut - 1;
            m_Rigidbody.velocity = Vector3.zero;
            m_Rigidbody.AddForce(0, m_Thrust, 0, ForceMode.Impulse);
            if (nbSaut==1){
                //this.GetComponent<Animator>().Play("playerJump1");
                animator.SetTrigger("Jump1");
            }
            if (nbSaut==0){
                animator.SetTrigger("Jump2");
                //this.GetComponent<Animator>().Play("playerJump2");
            }
        }
    }
}