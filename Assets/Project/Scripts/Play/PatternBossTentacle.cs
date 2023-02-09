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

    public void AvionFall()
     //Attaque qui vise directement le joueur en recup�rant sa position
    {
        var newTransform = spawnBulletBossTop.transform.position;
        Instantiate(paperFall, newTransform, Quaternion.identity);
    }

    public void AvionAscending()
     //Attaque qui vise directement le joueur en recup�rant sa position
    {
        var newTransform = spawnBulletBossBottom.transform.position;
        Instantiate(paperAscending, newTransform, Quaternion.identity);
    }

    public void AvionDual(){
        AvionAscending();
        AvionFall();
    }

    public void ProjTop(){
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
        public void ProjMid(){
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
        public void ProjBot(){
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
}
