using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBoss : MonoBehaviour
{

    public GameObject spawnBulletBossTop;
    public GameObject spawnBulletBossMid;
    public GameObject spawnBulletBossBottom;

    public GameObject sputumBoss;
    public GameObject sputumBossFast;

    public Player player;
    public Boss boss;

    public Animator animator;

    public void AttackDirectFast()
     //Attaque qui vise directement le joueur en recupérant sa position
    {
        this.GetComponent<Animator>().Play("BossAttack");
        float posProj = player.transform.position.y + 1.3f;
        posProj = Mathf.Clamp(posProj, -2.8f, 3.8f);
        var newTransform = new Vector3(boss.transform.position.x+1, posProj, player.transform.position.z);
        Instantiate(sputumBossFast, newTransform, Quaternion.identity);
        animator.SetTrigger("finAttack");
    }

    public void AttackTopSimple()
    //Attaque qui fait apparaitre un projectile sur le spawner du haut
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = spawnBulletBossTop.transform.position;
        Instantiate(sputumBoss, newTransform, Quaternion.identity);
        animator.SetTrigger("finAttack");
    }

    public void AttackMidSimple()
    //Attaque qui fait apparaitre un projectile sur le spawner du milieu
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = spawnBulletBossMid.transform.position;
        Instantiate(sputumBoss, newTransform, Quaternion.identity);
        animator.SetTrigger("finAttack");
    }

    public void AttackBotSimple()
    //Attaque qui fait apparaitre un projectile sur le spawner du bas
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = spawnBulletBossBottom.transform.position;
        Instantiate(sputumBoss, newTransform, Quaternion.identity);
        animator.SetTrigger("finAttack");
    }

    public void AttackDuoTopMid()
    //Attaque qui fait apparaitre un projectile sur le spawner du haut et du milieu
    {
        AttackTopSimple();
        //Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        AttackMidSimple();
    }

    public void AttackDuoTopBot()
    //Attaque qui fait apparaitre un projectile sur le spawner du haut et du bas
    {
        AttackTopSimple();
        //Debug.Log("???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????");
        AttackBotSimple();
    }

    public void AttackDuoMidBot()
    //Attaque qui fait apparaitre un projectile sur le spawner du milieu et du bas
    {
        AttackMidSimple();
        //Debug.Log("............................................................................................................................");
        AttackBotSimple();
    }
}
