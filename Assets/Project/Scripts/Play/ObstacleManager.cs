using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleManager : MonoBehaviour
{
    public MusicManager musicManager;

    // Liste Spawn 1
    public List<GameObject> obstacles0;
    public List<GameObject> obstaclesGarbages0;

    // Liste Spawn 2
    public List<GameObject> obstacles1;
    public List<GameObject> obstaclesGarbages1;

    // Liste Spawn 3
    public List<GameObject> obstacles2;
    public List<GameObject> obstaclesGarbages2;
    //public Animator animator;
    // Les listes qui vont servir de conteneurs pour les listes de spawn aléatoire
    List<GameObject> obstacles;
    List<GameObject> obstaclesGarbages;

    public List<GameObject> spawnPoints;

    float chrono;
    float maxChrono;
    public float speed;
    public float pourcentage = 0f;

    int randomObstacle;
    int randomObstacleSave;
    int randomSpawn;
    int randomSpawnSave;

    int dansCombienUnGarbage;

    public Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        //animator.SetTrigger("");
        maxChrono = musicManager.interval;
        chrono = maxChrono;
        dansCombienUnGarbage = Random.Range(4, 8);

        speed = musicManager.selectedMusic.startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(maxChrono);
        if (chrono > 0)
        {
            chrono -= Time.deltaTime;
        }
        else
        {
            chrono = maxChrono;
            dansCombienUnGarbage --;
            if (dansCombienUnGarbage == 0)
            {
                SpawnObstacleGarbage();
                dansCombienUnGarbage = Random.Range(4, 8);
            }
            else
            {
                SpawnObstacle();
            }

            // Augmentation de pourcentage
            pourcentage += 1 / (musicManager.selectedMusic.lengh / maxChrono);

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
        randomSpawn = Random.Range(0, spawnPoints.Count);
        while (randomSpawn == randomSpawnSave)
        {
            randomSpawn = Random.Range(0, spawnPoints.Count);
        }
        randomSpawnSave = randomSpawn;

        if (randomSpawn == 0)
        {
            obstacles = obstacles0;
        }
        else if (randomSpawn == 1)
        {
            obstacles = obstacles1;
        }
        else
        {
            obstacles = obstacles2;
        }

        randomObstacle = Random.Range(0, obstacles.Count);
        while (randomObstacle == randomObstacleSave)
        {
            randomObstacle = Random.Range(0, obstacles.Count);
        }
        randomObstacleSave = randomObstacle;

        Instantiate(obstacles[randomObstacle], spawnPoints[randomSpawn].transform.position, Quaternion.identity);
    }

    void SpawnObstacleGarbage()
    {
        randomSpawn = Random.Range(0, spawnPoints.Count);
        while (randomSpawn == randomSpawnSave)
        {
            randomSpawn = Random.Range(0, spawnPoints.Count);
        }
        randomSpawnSave = randomSpawn;

        if (randomSpawn == 0)
        {
            obstaclesGarbages = obstaclesGarbages0;
        }
        else if (randomSpawn == 1)
        {
            obstaclesGarbages = obstaclesGarbages1;
        }
        else
        {
            obstaclesGarbages = obstaclesGarbages2;
        }

        randomObstacle = Random.Range(0, obstaclesGarbages.Count);
        while (randomObstacle == randomObstacleSave)
        {
            randomObstacle = Random.Range(0, obstaclesGarbages.Count);
        }
        randomObstacleSave = randomObstacle;

        Instantiate(obstaclesGarbages[randomObstacle], spawnPoints[randomSpawn].transform.position, Quaternion.identity);
    }
}
