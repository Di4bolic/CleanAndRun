using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        stunEnCours = Time.time + stunDelay;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > stunEnCours && bossEnCours == false)
        {
            thierry.position = new Vector3(11, -1, 0);
            bossEnCours = true;
            munBoss = munBoss+player.NbDechetColl;
            Debug.Log(munBoss);
        }
    }
}
