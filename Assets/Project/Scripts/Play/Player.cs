using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using TMPro;

public class Player : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        maxSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1 && cooldownSaut==false && nbSaut>0 && Time.time> stunEnCours)
        {
            var tempVector = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Camera.main.nearClipPlane);
            var tempRay = Camera.main.ScreenPointToRay(tempVector);
            Physics.Raycast(tempRay, out var tempObject);
            var tempObjectConverted = tempObject.collider.GetComponent<EcranSaut>();
            if (tempObjectConverted != null)
            {
           
                cooldownSaut = true;
                nbSaut = nbSaut - 1;
                //thierry.position = new Vector3(thierry.position.x, thierry.position.y+3, thierry.position.z);

                //if(nbSaut == 0 && )
                m_Rigidbody.velocity = Vector3.zero;
                m_Rigidbody.AddForce(0, m_Thrust, 0, ForceMode.Impulse);
            }
        }

        if (Input.touchCount == 0 && cooldownSaut == true)
        {
            cooldownSaut = false;
        }

        if (Time.time > stunEnCours)
        {

            m_Rigidbody.GetComponent<Renderer>().material.color = Color.white;
        }

    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")) {
            m_Rigidbody.velocity = Vector3.zero;
            nbSaut = 2;
        }
        if(other.gameObject.CompareTag("Collectible")) {
            Destroy(other.gameObject);
            NbDechetColl = NbDechetColl + 1;

            // Gestion UI
            garbagesScore++;
            munitionsScore += 3;
            garbages.text = "Garbages :" + garbagesScore.ToString();
            munitions.text = "Munitions :" + munitionsScore.ToString();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            stun = true;
            stunEnCours = Time.time + stunDelay;

            m_Rigidbody.GetComponent<Renderer>().material.color = Color.red;
        }
    }
        /*private void OnCollisionStay(Collision other) {
            Debug.Log("collision");
            if(other.gameObject.CompareTag("Collectible")) {
                Debug.Log("collision");
                Destroy(other.gameObject);
                //if(clicBouton.clic==true){
                    //Destroy(other.gameObject);
                    //clicBouton.clic=false;
                //}
            }
        }*/

        /*public void Jump(){

            if (Input.touchCount >= 1 && cooldownSaut==false && nbSaut>0)
            {
                var tempVector = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, Camera.main.nearClipPlane);
                var tempRay = Camera.main.ScreenPointToRay(tempVector);
                Physics.Raycast(tempRay, out var tempObject);
                var tempObjectConverted = tempObject.collider.GetComponent<BoutColl>();
                Debug.Log(tempObjectConverted);
                if (tempObjectConverted != null)
                {
                    cooldownSaut = true;
                    nbSaut = nbSaut - 1;
                    //thierry.position = new Vector3(thierry.position.x, thierry.position.y+3, thierry.position.z);

                    //if(nbSaut == 0 && )
                    m_Rigidbody.velocity = Vector3.zero;
                    m_Rigidbody.AddForce(0, m_Thrust, 0, ForceMode.Impulse);
                }
            }

            if (Input.touchCount == 0 && cooldownSaut == true)
            {
                cooldownSaut = false;
            }
        }*/
    }