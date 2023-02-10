using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public ManagerManager mM;
    public BossManager bossManager;
    public float lifeBoss;
    public float lifeBossInitial;

    public Animator animator;

    public int damage;
    public string name;

    private void OnTriggerEnter(Collider other)
    {
        //interaction entre les projectile du joueur et le boss
        if (other.gameObject.CompareTag("Projectil"))
        {
            lifeBoss = lifeBoss - damage;
            Destroy(other.gameObject);
            bossManager.UpdateLife();
        }
    }
}
