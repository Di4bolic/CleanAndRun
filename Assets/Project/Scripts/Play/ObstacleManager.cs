using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleManager : MonoBehaviour
{
    public MusicManager musicManager;

    public GameObject bgEasy;
    public GameObject bgMedium;
    public GameObject bgHard;

    // Liste difficult� 1
    public List<GameObject> obstaclesEasy;
    public List<GameObject> obstaclesGarbagesEasy;

    // Liste difficult� 2
    public List<GameObject> obstaclesMedium;
    public List<GameObject> obstaclesGarbagesMedium;

    // Liste difficult� 3
    public List<GameObject> obstaclesHard;
    public List<GameObject> obstaclesGarbagesHard;

    // Les listes qui vont servir de conteneurs pour les listes de spawn al�atoire
    List<GameObject> obstacles;
    List<GameObject> obstaclesGarbages;

    public GameObject spawnPoint;
    public float decalage = 0f;

    float chrono;
    float maxChrono;
    public float speed;
    public float pourcentage = 0f;

    int randomObstacle;
    int randomObstacleSave;

    int dansCombienUnGarbage;

    public Boss boss;
    public PatternBoss patternBoss;
    public PatternBossTentacle patternBossTentacle;
    public BossManager bossManager;

    public int attackChoice;

    public int nbEncounter=0;

    // Start is called before the first frame update
    void Start()
    {
        // D�finition de la liste d'obstacle en fonction de la difficult�
        if (musicManager.selectedMusic.difficulty == "Easy")
        {
            bgEasy.SetActive(true);
            obstacles = obstaclesEasy;
            obstaclesGarbages = obstaclesGarbagesEasy;
        }
        else if (musicManager.selectedMusic.difficulty == "Medium")
        {
            bgMedium.SetActive(true);
            obstacles = obstaclesMedium;
            obstaclesGarbages = obstaclesGarbagesMedium;
        }
        else
        {
            bgHard.SetActive(true);
            obstacles = obstaclesHard;
            obstaclesGarbages = obstaclesGarbagesHard;
        }

        // Chrono
        maxChrono = musicManager.interval;
        chrono = maxChrono;

        // Vitesse
        speed = musicManager.selectedMusic.startSpeed;

        // Construction du level
        SpawnAllLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (chrono > 0)
        {
            chrono -= Time.deltaTime;
        }
        else
        {
            //if (boss.transform.position.x<=4){
              //  boss.GetComponent<Rigidbody>().velocity= new Vector3(0, 0, 0);
                //Debug.Log("..............................................");
            //}

            // Augmentation de pourcentage
            pourcentage += 1 / (musicManager.selectedMusic.lenght / maxChrono);

            chrono = maxChrono;
//if (boss.bossAlive && pourcentage >= 0.6)
            if (bossManager.bossAlive && pourcentage >= 0.6)
            {
                if (bossManager.nameBossCurrent=="bin"){
            
                    if (musicManager.selectedMusic.difficulty == "Easy")
                    {

                        attackChoice = Random.Range(1, 101);

                        if(attackChoice <= 25)
                        {
                            patternBoss.AttackTopSimple();
                        }
                        if (attackChoice > 25 && attackChoice <= 35)
                        {
                            patternBoss.AttackMidSimple();
                        }
                        if (attackChoice > 35 && attackChoice <= 60)
                        {
                            patternBoss.AttackBotSimple();
                        }
                        if (attackChoice > 60 && attackChoice <= 75)
                        {
                            patternBoss.AttackDuoTopMid();
                        }
                        if (attackChoice > 75 && attackChoice <= 90)
                        {
                            patternBoss.AttackDuoMidBot();
                        }
                        if (attackChoice > 90)
                        {
                            patternBoss.AttackDuoTopBot();
                        }
                    }

                    if (musicManager.selectedMusic.difficulty == "Medium")
                    {

                        attackChoice = Random.Range(1, 101);

                        if (attackChoice <= 18)
                        {
                            patternBoss.AttackTopSimple();
                        }
                        if (attackChoice > 18 && attackChoice <= 31)
                        {
                            patternBoss.AttackMidSimple();
                        }
                        if (attackChoice > 31 && attackChoice <= 49)
                        {
                            patternBoss.AttackBotSimple();
                        }
                        if (attackChoice > 49 && attackChoice <= 67)
                        {
                            patternBoss.AttackDuoTopMid();
                        }
                        if (attackChoice > 67 && attackChoice <= 85)
                        {
                            patternBoss.AttackDuoMidBot();
                        }
                        if (attackChoice > 85)
                        {
                            patternBoss.AttackDuoTopBot();
                        }
                    }

                    if (musicManager.selectedMusic.difficulty == "Hard")
                    {
                        attackChoice = Random.Range(1, 101);

                        if (attackChoice <= 8)
                        {
                            patternBoss.AttackTopSimple();
                        }
                        if (attackChoice > 8 && attackChoice <= 22)
                        {
                            patternBoss.AttackMidSimple();
                        }
                        if (attackChoice > 22 && attackChoice <= 30)
                        {
                            patternBoss.AttackBotSimple();
                        }
                        if (attackChoice > 30 && attackChoice <= 55)
                        {
                            patternBoss.AttackDuoTopMid();
                        }
                        if (attackChoice > 55 && attackChoice <= 80)
                        {
                            patternBoss.AttackDuoMidBot();
                        }
                        if (attackChoice > 80)
                        {
                            patternBoss.AttackDuoTopBot();
                        }
                    }
                }else{
                        if (musicManager.selectedMusic.difficulty == "Easy")
                        {

                        attackChoice = Random.Range(1, 101);

                        if(attackChoice <= 25)
                        {
                            patternBossTentacle.AttackTentacleTopSimple();
                        }
                        if (attackChoice > 25 && attackChoice <= 35)
                        {
                            patternBossTentacle.AttackTentacleMidSimple();
                        }
                        if (attackChoice > 35 && attackChoice <= 60)
                        {
                            patternBossTentacle.AttackTentacleBotSimple();
                        }
                        if (attackChoice > 60 && attackChoice <= 75)
                        {
                            patternBossTentacle.AttackTentacleDuoTopMid();
                        }
                        if (attackChoice > 75 && attackChoice <= 90)
                        {
                            patternBossTentacle.AttackTentacleDuoMidBot();
                        }
                        if (attackChoice > 90)
                        {
                            patternBossTentacle.AttackTentacleDuoTopBot();
                        }
                    }

                    if (musicManager.selectedMusic.difficulty == "Medium")
                    {

                        attackChoice = Random.Range(1, 101);

                        if (attackChoice <= 18)
                        {
                            patternBossTentacle.AttackTentacleTopSimple();
                        }
                        if (attackChoice > 18 && attackChoice <= 31)
                        {
                            patternBossTentacle.AttackTentacleMidSimple();
                        }
                        if (attackChoice > 31 && attackChoice <= 49)
                        {
                            patternBossTentacle.AttackTentacleBotSimple();
                        }
                        if (attackChoice > 49 && attackChoice <= 67)
                        {
                            patternBossTentacle.AttackTentacleDuoTopMid();
                        }
                        if (attackChoice > 67 && attackChoice <= 85)
                        {
                            patternBossTentacle.AttackTentacleDuoMidBot();
                        }
                        if (attackChoice > 85)
                        {
                            patternBossTentacle.AttackTentacleDuoTopBot();
                        }
                    }

                    if (musicManager.selectedMusic.difficulty == "Hard")
                    {
                        attackChoice = Random.Range(1, 101);

                        if (attackChoice <= 8)
                        {
                            patternBossTentacle.AttackTentacleTopSimple();
                        }
                        if (attackChoice > 8 && attackChoice <= 22)
                        {
                            patternBossTentacle.AttackTentacleMidSimple();
                        }
                        if (attackChoice > 22 && attackChoice <= 30)
                        {
                            patternBossTentacle.AttackTentacleBotSimple();
                        }
                        if (attackChoice > 30 && attackChoice <= 55)
                        {
                            patternBossTentacle.AttackTentacleDuoTopMid();
                        }
                        if (attackChoice > 55 && attackChoice <= 80)
                        {
                            patternBossTentacle.AttackTentacleDuoMidBot();
                        }
                        if (attackChoice > 80)
                        {
                            patternBossTentacle.AttackTentacleDuoTopBot();
                        }
                    }
                }
            }
        }

        // Augmentation de la vitesse
        speed = Mathf.Lerp(musicManager.selectedMusic.startSpeed, musicManager.selectedMusic.endSpeed, pourcentage);

        // Si la musique est finie
        if (pourcentage >= 1)
        {
            SceneManager.LoadScene("EndScene");
        }

        if (pourcentage >= 0.6 && bossManager.bossAlive==true)
        {
            bossManager.ViewBoss();
        }

        if (pourcentage >= 0.6 && bossManager.bossAlive == false)
        {
            bossManager.SpawnBoss();
        }

        if (musicManager.selectedMusic.difficulty == "Easy" || musicManager.selectedMusic.difficulty == "Medium")
        {
            if (pourcentage >= 0.2 && nbEncounter == 0)
            {
                bossManager.SpawnBoss();
                nbEncounter++;
                StartCoroutine(CoroutineTempBoss());
            }

            if (pourcentage >= 0.4 && nbEncounter == 1)
            {
                if (bossManager.bossAlive==false){
                    bossManager.SpawnBoss();
                }else{
                    bossManager.ViewBoss();
                }
                nbEncounter++;
                StartCoroutine(CoroutineTempBoss());
            }
        }
        else if (musicManager.selectedMusic.difficulty == "Hard")
        {
            if (pourcentage >= 0.15 && nbEncounter == 0)
            {
                bossManager.SpawnBoss();
                nbEncounter++;
                Debug.Log("pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp");
                StartCoroutine(CoroutineTempBoss());
            }

            if (pourcentage >= 0.30 && nbEncounter == 1)
            {
                if (bossManager.bossAlive==false){
                    bossManager.SpawnBoss();
                }else{
                    bossManager.ViewBoss();
                }
                nbEncounter++;
                Debug.Log("pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp");
                StartCoroutine(CoroutineTempBoss());
            }

            if (pourcentage >= 0.45 && nbEncounter == 2)
            {
                if (bossManager.bossAlive==false){
                    bossManager.SpawnBoss();
                }else{
                    bossManager.ViewBoss();
                }
                nbEncounter++;
                Debug.Log("pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp");
                StartCoroutine(CoroutineTempBoss());
            }
        }

    }

    public IEnumerator CoroutineTempBoss()
    {
        yield return new WaitForSeconds(2);
        if (bossManager.nameBossCurrent=="bin"){
            patternBoss.AttackDirectFast();
        }else{
            patternBossTentacle.AttackDirect();
        }

        yield return new WaitForSeconds(2);
        if (bossManager.nameBossCurrent=="bin"){
            patternBoss.AttackDirectFast();
        }else{
            patternBossTentacle.AttackDirect();
        }
        yield return new WaitForSeconds(1);
        Debug.Log("tteteteteteteterterteteteteeetetettetetetetetetetetetettetetetetetetetetetettetet");
        bossManager.HideBoss();
    }

    void SpawnObstacle(float _decalage)
    {
        randomObstacle = Random.Range(0, obstacles.Count);
        while (randomObstacle == randomObstacleSave)
        {
            randomObstacle = Random.Range(0, obstacles.Count);
        }
        randomObstacleSave = randomObstacle;

        Instantiate(obstacles[randomObstacle], spawnPoint.transform.position + new Vector3(_decalage, 0, 0), Quaternion.identity);
    }

    void SpawnObstacleGarbage(float _decalage)
    {        
        randomObstacle = Random.Range(0, obstaclesGarbages.Count);
        while (randomObstacle == randomObstacleSave)
        {
            randomObstacle = Random.Range(0, obstaclesGarbages.Count);
        }
        randomObstacleSave = randomObstacle;

        Instantiate(obstaclesGarbages[randomObstacle], spawnPoint.transform.position + new Vector3(_decalage, 0, 0), Quaternion.identity);
    }

    void SpawnAllLevel()
    {
        for (int i = 0; i < (musicManager.lengthMusic/maxChrono); i++)
        {
            SpawnObstacle(decalage);
            // Décalage de la taille des obstacles
            decalage += 18f;
            // Décalage de l'espace entre les obstacles
            decalage += 18f;
            SpawnObstacleGarbage(decalage);
            // Décalage de la taille des obstacles
            decalage += 18f;
            // Décalage de l'espace entre les obstacles
            decalage += 18f;
        }
    }
}
