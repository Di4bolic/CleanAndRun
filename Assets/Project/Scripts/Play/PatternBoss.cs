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

    public int attackTypeBullet;

    public void AttackDirect()
    {
        this.GetComponent<Animator>().Play("BossAttack");
        float posProj = player.transform.position.y + 1.3f;
        posProj = Mathf.Clamp(posProj, -2.8f, 3.8f);
        var newTransform = new Vector3(transform.position.x, posProj, 0);
        attackTypeBullet = Random.Range(1, 2);
        if (attackTypeBullet==1)
        {
            Instantiate(vomiBoss, newTransform, Quaternion.identity);
        }
        if (attackTypeBullet == 2)
        {
            Instantiate(vomiBossEclair, newTransform, Quaternion.identity);
        }
        animator.SetTrigger("finAttack");
    }
    public void AttackTopSimple()
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = spawnBulletBossTop.transform.position;
        attackTypeBullet = Random.Range(1, 2);
        if (attackTypeBullet == 1)
        {
            Instantiate(vomiBoss, newTransform, Quaternion.identity);
        }
        if (attackTypeBullet == 2)
        {
            Instantiate(vomiBossEclair, newTransform, Quaternion.identity);
        }
        animator.SetTrigger("finAttack");
    }
    public void AttackMidSimple()
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = spawnBulletBossMid.transform.position;
        attackTypeBullet = Random.Range(1, 2);
        if (attackTypeBullet == 1)
        {
            Instantiate(vomiBoss, newTransform, Quaternion.identity);
        }
        if (attackTypeBullet == 2)
        {
            Instantiate(vomiBossEclair, newTransform, Quaternion.identity);
        }
        animator.SetTrigger("finAttack");
    }
    public void AttackBotSimple()
    {
        this.GetComponent<Animator>().Play("BossAttack");
        var newTransform = spawnBulletBossBottom.transform.position;
        attackTypeBullet = Random.Range(1, 3);
        if (attackTypeBullet == 1)
        {
            Instantiate(vomiBoss, newTransform, Quaternion.identity);
        }
        if (attackTypeBullet == 2)
        {
            Instantiate(vomiBossEclair, newTransform, Quaternion.identity);
        }
        animator.SetTrigger("finAttack");
    }

    public void AttackDuoTopMid()
    {
        AttackTopSimple();
        AttackMidSimple();
    }
    public void AttackDuoTopBot()
    {
        AttackTopSimple();
        AttackBotSimple();
    }
    public void AttackDuoMidBot()
    {
        AttackMidSimple();
        AttackBotSimple();
    }
}
