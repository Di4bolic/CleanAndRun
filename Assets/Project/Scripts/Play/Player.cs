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

    bool cooldownJump = false;
    int nbJump=2;
    public Transform transformPlayer;
    public Rigidbody playerRigidbody;
    public float m_Thrust = 0.01f;
    public bool stun=false;
    public float stunDelay = 1f;
    public float stunCurrent = -1f;
    public float maxSpeed;

    public Animator animator;

    public SpriteRenderer spriteRenderer;
    public Sprite newSpriteJump1;
    public Sprite newSpriteJump2;

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

        playerRigidbody = GetComponent<Rigidbody>();
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


        if (Input.touchCount == 0 && cooldownJump == true)
        {
            cooldownJump = false;
        }

        if (Time.time > stunCurrent)
        {
            //animator.ResetTrigger("");
            //animator.SetTrigger("Run");
            stun = false;
            animator.SetTrigger("Run");
            //this.GetComponent<Animator>().Play("RunAnim");
            //playerRigidbody.GetComponent<Renderer>().material.color = Color.white;

        }
    }

    private void OnCollisionEnter(Collision other) {
        //Detecte le sol et réagit
        if(other.gameObject.CompareTag("Ground")) {
            playerRigidbody.velocity = Vector3.zero;
            nbJump = 2;

            if (stun==false)
            {
                animator.SetTrigger("Run");
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Detect les differents collision et interaction possible lié aux collisions
        if (other.gameObject.CompareTag("Obstacle"))
        {
            shakeDuration = 0.2f;
            stun = true;
            stunCurrent = Time.time + stunDelay;

            //playerRigidbody.GetComponent<Renderer>().material.color = Color.red;
            //animator.SetTrigger("Stun");
            //this.GetComponent<Animator>().Play("playerStun");
            animator.SetTrigger("Stun");
        }

        if (other.gameObject.CompareTag("Collectible") && stun == false)
        {
            Destroy(other.gameObject);

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
        //Gere le saut du joueur et ses différents paramètres 
        if (cooldownJump == false && nbJump > 0 && Time.time > stunCurrent)
        {
            cooldownJump = true;
            nbJump = nbJump - 1;
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(0, m_Thrust, 0, ForceMode.Impulse);
            if (nbJump==1){
                //this.GetComponent<Animator>().Play("playerJump1");
                animator.SetTrigger("Jump1");
            }
            if (nbJump==0){
                animator.SetTrigger("Jump2");
                //this.GetComponent<Animator>().Play("playerJump2");
            }
        }
    }
}