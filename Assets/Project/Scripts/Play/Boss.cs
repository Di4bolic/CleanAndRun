using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public ManagerManager mM;
    public float lifeBoss;
    public float lifeBossInitial;

    public GameObject sputumBoss;
    public GameObject sputumBossFast;

    public Animator animator;

    public int damage;
}
