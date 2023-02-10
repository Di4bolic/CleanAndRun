using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBossTentacle : MonoBehaviour
{

    public GameObject spawnBulletBossTop;
    public GameObject spawnBulletBossMid;
    public GameObject spawnBulletBossBottom;

    public GameObject brokenGlass;
    public GameObject paper;
    public GameObject paperFall;
    public GameObject paperAscending;
    public GameObject sodaBottle;
    public GameObject cigaret;


    public Player player;
    public Boss boss;

    public Animator animator;

    public void AttackDirect()
     //Attaque qui vise directement le joueur en recup�rant sa position
    {
        float posProj = player.transform.position.y + 1.3f;
        posProj = Mathf.Clamp(posProj, -2.8f, 3.8f);
        var newTransform = new Vector3(boss.transform.position.x+1, posProj, player.transform.position.z);
        var typeOfProj = Random.Range(1, 4);
        if(typeOfProj==1){
            Instantiate(brokenGlass, newTransform, Quaternion.identity);
        }
        if(typeOfProj==2){
            Instantiate(sodaBottle, newTransform, Quaternion.identity);
        }
        if(typeOfProj==3){
            Instantiate(cigaret, newTransform, Quaternion.identity);
        }
    }

    public void AttackTentacleTopSimple(){
        var newTransform = spawnBulletBossTop.transform.position;
        var typeOfProj = Random.Range(1, 4);
        if(typeOfProj==1){
            Instantiate(brokenGlass, newTransform, Quaternion.identity);
        }
        if(typeOfProj==2){
            Instantiate(sodaBottle, newTransform, Quaternion.identity);
        }
        if(typeOfProj==3){
            Instantiate(cigaret, newTransform, Quaternion.identity);
        }
    }
        public void AttackTentacleMidSimple(){
        var newTransform = spawnBulletBossMid.transform.position;
        var typeOfProj = Random.Range(1, 4);
        if(typeOfProj==1){
            Instantiate(brokenGlass, newTransform, Quaternion.identity);
        }
        if(typeOfProj==2){
            Instantiate(sodaBottle, newTransform, Quaternion.identity);
        }
        if(typeOfProj==3){
            Instantiate(cigaret, newTransform, Quaternion.identity);
        }
    }
        public void  AttackTentacleBotSimple(){
        var newTransform = spawnBulletBossBottom.transform.position;
        var typeOfProj = Random.Range(1, 4);
        if(typeOfProj==1){
            Instantiate(brokenGlass, newTransform, Quaternion.identity);
        }
        if(typeOfProj==2){
            Instantiate(sodaBottle, newTransform, Quaternion.identity);
        }
        if(typeOfProj==3){
            Instantiate(cigaret, newTransform, Quaternion.identity);
        }
    }

    public void AttackTentacleDuoTopMid()
    //Attaque qui fait apparaitre un projectile sur le spawner du haut et du milieu
    {
        AttackTentacleTopSimple();
        //Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        AttackTentacleMidSimple();
    }

    public void AttackTentacleDuoTopBot()
    //Attaque qui fait apparaitre un projectile sur le spawner du haut et du bas
    {
        AttackTentacleTopSimple();
        //Debug.Log("???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????");
        AttackTentacleBotSimple();
    }

    public void AttackTentacleDuoMidBot()
    //Attaque qui fait apparaitre un projectile sur le spawner du milieu et du bas
    {
        AttackTentacleMidSimple();
        //Debug.Log("............................................................................................................................");
        AttackTentacleBotSimple();
    }
}
