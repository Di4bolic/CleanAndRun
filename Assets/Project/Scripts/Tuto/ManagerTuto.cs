using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerTuto : MonoBehaviour
{
    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;

    public TextMeshProUGUI textJump;
    public TextMeshProUGUI textDoubleJump;
    public TextMeshProUGUI textGarbage;
    public TextMeshProUGUI textShoot;

    public Boss boss;

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

        if (ob3.gameObject.transform.position.x <= -10)
        {
            textGarbage.gameObject.SetActive(false);
            textShoot.gameObject.SetActive(true);
            boss.SpawnBoss();
            boss.vieBoss = 10;
        }


    }
}
