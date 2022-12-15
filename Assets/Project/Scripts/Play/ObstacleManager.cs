using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleManager : MonoBehaviour
{
    public MusicManager musicManager;

    // Liste difficulté 1
    public List<GameObject> obstaclesEasy;
    public List<GameObject> obstaclesGarbagesEasy;

    // Liste difficulté 2
    public List<GameObject> obstaclesMedium;
    public List<GameObject> obstaclesGarbagesMedium;

    // Liste difficulté 3
    public List<GameObject> obstaclesHard;
    public List<GameObject> obstaclesGarbagesHard;

    // Les listes qui vont servir de conteneurs pour les listes de spawn aléatoire
    List<GameObject> obstacles;
    List<GameObject> obstaclesGarbages;

    public GameObject spawnPoint;

    float chrono;
    float maxChrono;
    public float maxChronoModif;
    public float speed;
    public float pourcentage = 0f;
    public float division = 15f;

    int randomObstacle;
    int randomObstacleSave;

    int dansCombienUnGarbage;

    public Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        // Définition de la liste d'obstacle en fonction de la difficulté
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
        maxChrono = musicManager.interval * division;
        maxChronoModif = maxChrono;
        chrono = maxChronoModif;
        dansCombienUnGarbage = Random.Range(1, 2);

        speed = musicManager.selectedMusic.startSpeed;
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
            chrono = maxChronoModif;
            dansCombienUnGarbage --;
            if (dansCombienUnGarbage == 0)
            {
                SpawnObstacleGarbage();
                dansCombienUnGarbage = Random.Range(1, 2);
            }
            else
            {
                SpawnObstacle();
            }

            // Augmentation de la fréquence de spawn
            maxChronoModif /= musicManager.selectedMusic.baisseDivision;

            // Augmentation de pourcentage
            pourcentage += musicManager.selectedMusic.lengh / maxChrono;

            if (boss.bossEnCours)
            {
                boss.paternBossAttack();
            }


        }

        // Auglentation de la vitesse des obstacles au fur et à mesure du jeu
        speed = Mathf.Lerp(musicManager.selectedMusic.startSpeed, musicManager.selectedMusic.endSpeed, pourcentage);

        // Si la musique est finie
        if (pourcentage >= 1)
        {
            SceneManager.LoadScene("EndScene");
        }


        if (pourcentage >= 0.1 && boss.bossEnCours==false)
        {
            boss.SpawnBoss();
        }

    }

    void SpawnObstacle()
    {
        randomObstacle = Random.Range(0, obstacles.Count);
        while (randomObstacle == randomObstacleSave)
        {
            randomObstacle = Random.Range(0, obstacles.Count);
        }
        randomObstacleSave = randomObstacle;

        Instantiate(obstacles[randomObstacle], spawnPoint.transform.position, Quaternion.identity);
    }

    void SpawnObstacleGarbage()
    {        
        randomObstacle = Random.Range(0, obstaclesGarbages.Count);
        while (randomObstacle == randomObstacleSave)
        {
            randomObstacle = Random.Range(0, obstaclesGarbages.Count);
        }
        randomObstacleSave = randomObstacle;

        Instantiate(obstaclesGarbages[randomObstacle], spawnPoint.transform.position, Quaternion.identity);
    }
}
