using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBoss : MonoBehaviour
{

    public GameObject spawnBulletBossTop;
    public GameObject spawnBulletBossMid;
    public GameObject spawnBulletBossBottom;

    public GameObject vomiBoss;
    public GameObject vomiBossEclair;

    public Player player;
    public Boss boss;

    public Animator animator;

    public void AttackDirect()
    {
        this.GetComponent<Animator>().Play("BossAttack");
        float posProj = player.transform.position.y + 1.3f;
        posProj = Mathf.Clamp(posProj, -2.8f, 3.8f);
        var newTransform = new Vector3(transform.position.x, posProj, 0);
        animator.SetTrigger("finAttack");
    }
    public void AttackTopSimple()
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = spawnBulletBossTop.transform.position;
        Instantiate(vomiBoss, newTransform, Quaternion.identity);
        animator.SetTrigger("finAttack");
    }
    public void AttackMidSimple()
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = spawnBulletBossMid.transform.position;
        Instantiate(vomiBoss, newTransform, Quaternion.identity);
        animator.SetTrigger("finAttack");
    }
    public void AttackBotSimple()
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = spawnBulletBossBottom.transform.position;
        Instantiate(vomiBoss, newTransform, Quaternion.identity);
        animator.SetTrigger("finAttack");
    }

    public void AttackDuoTopMid()
    {
        AttackTopSimple();
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        AttackMidSimple();
    }
    public void AttackDuoTopBot()
    {
        AttackTopSimple();
        Debug.Log("???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????");
        AttackBotSimple();
    }
    public void AttackDuoMidBot()
    {
        AttackMidSimple();
        Debug.Log("............................................................................................................................");
        AttackBotSimple();
    }
}
