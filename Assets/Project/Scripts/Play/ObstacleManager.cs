using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleManager : MonoBehaviour
{
    public MusicManager musicManager;

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

    // Start is called before the first frame update
    void Start()
    {
        // D�finition de la liste d'obstacle en fonction de la difficult�
        if (musicManager.selectedMusic.difficulty == "Easy")
        {
            obstacles = obstaclesEasy;
            obstaclesGarbages = obstaclesGarbagesEasy;
        }
        else if (musicManager.selectedMusic.difficulty == "Medium")
        {
            obstacles = obstaclesMedium;
            obstaclesGarbages = obstaclesGarbagesMedium;
        }
        else
        {
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
        // debug
        Debug.Log("Voici l'avancement du level : " + pourcentage);

        if (chrono > 0)
        {
            chrono -= Time.deltaTime;
        }
        else
        {

            // Augmentation de pourcentage
            pourcentage += 1 / (musicManager.selectedMusic.lenght / maxChrono);

            chrono = maxChrono;

            if (boss.bossEnCours && pourcentage >= 0.6)
            {
                boss.paternBossAttack();
            }
        }

        // Augmentation de la vitesse
        speed = Mathf.Lerp(musicManager.selectedMusic.startSpeed, musicManager.selectedMusic.endSpeed, pourcentage);

        // Si la musique est finie
        if (pourcentage >= 1)
        {
            SceneManager.LoadScene("EndScene");
        }


        if (pourcentage >= 0.6 && boss.bossEnCours==true)
        {
            boss.ViewBoss();
        }
        
        if (musicManager.selectedMusic.difficulty == "Easy" || musicManager.selectedMusic.difficulty == "Medium")
        {
            if (pourcentage >= 0.2 && boss.nbEncounter == 0)
            {
                boss.SpawnBoss();
                boss.nbEncounter++;
                StartCoroutine(CoroutineTempBoss());
            }

            if (pourcentage >= 0.4 && boss.nbEncounter == 1)
            {
                boss.ViewBoss();
                boss.nbEncounter++;
                StartCoroutine(CoroutineTempBoss());
            }
        }
        else if (musicManager.selectedMusic.difficulty == "Hard")
        {
            if (pourcentage >= 0.15 && boss.nbEncounter == 0)
            {
                boss.SpawnBoss();
                boss.nbEncounter++;
                StartCoroutine(CoroutineTempBoss());
            }

            if (pourcentage >= 0.30 && boss.nbEncounter == 1)
            {
                boss.ViewBoss();
                boss.nbEncounter++;
                StartCoroutine(CoroutineTempBoss());
            }

            if (pourcentage >= 0.45 && boss.nbEncounter == 2)
            {
                boss.ViewBoss();
                boss.nbEncounter++;
                StartCoroutine(CoroutineTempBoss());
            }
        }

    }

    public IEnumerator CoroutineTempBoss()
    {
        yield return new WaitForSeconds(2);
        boss.paternBossAttackEclair();

        yield return new WaitForSeconds(2);
        boss.paternBossAttackEclair();

        yield return new WaitForSeconds(1);
        boss.HideBoss();
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
        for (int i = 0; i < (musicManager.lengthMusic/maxChrono-1); i++)
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
