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
        maxChrono = musicManager.interval;
        chrono = maxChrono;
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

            // Augmentation de pourcentage
            pourcentage += 1 / (musicManager.selectedMusic.lenght / maxChrono);

            chrono = maxChrono;

            if (boss.bossEnCours)
            {
                boss.paternBossAttack();
            }
        }

        // Auglentation de la vitesse des obstacles au fur et � mesure du jeu
        speed = Mathf.Lerp(musicManager.selectedMusic.startSpeed, musicManager.selectedMusic.endSpeed, pourcentage);

        // Si la musique est finie
        if (pourcentage >= 1)
        {
            SceneManager.LoadScene("EndScene");
        }


        if (pourcentage >= 0.6 && boss.bossEnCours==false)
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

    void SpawnAllLevel()
    {
        for (int i = 0; i < (musicManager.lengthMusic/maxChrono); i++)
        {

        }
    }
}
