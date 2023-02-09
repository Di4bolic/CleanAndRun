using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerTuto : MonoBehaviour
{
    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;

    public GameObject garbage1;
    public GameObject garbage2;

    public TextMeshProUGUI textJump;
    public TextMeshProUGUI textDoubleJump;
    public TextMeshProUGUI textGarbage;
    public TextMeshProUGUI textShoot;

    public Boss boss;
    public Player player;

    public bool finTuto = false;

    // Start is called before the first frame update
    void Start()
    {
        textJump.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (ob1.gameObject.transform.position.x <= -10)
        {
            textJump.gameObject.SetActive(false);
            textDoubleJump.gameObject.SetActive(true);
        }

        if (ob2.gameObject.transform.position.x <= -10)
        {
            textDoubleJump.gameObject.SetActive(false);
            textGarbage.gameObject.SetActive(true);
        }


        if (player.munitionsScore<=0 && ob3.gameObject.transform.position.x <= -15 && finTuto == false)
        {
            //ob3.transform.position.x =83;
            ob3.transform.position = new Vector3(25, -1, 0);
            garbage1.transform.position = new Vector3(22, -0, 0);
            garbage2.transform.position = new Vector3(29, -0, 0);
        }

        if (ob3.gameObject.transform.position.x <= -15 && player.munitionsScore >= 0 && finTuto == false)
        {
            textGarbage.gameObject.SetActive(false);
            textShoot.gameObject.SetActive(true);
            boss.SpawnBoss();
        }

        if (boss.vieBoss <= 0){
            finTuto = true;
            Debug.Log("test");
        }
    }
}
