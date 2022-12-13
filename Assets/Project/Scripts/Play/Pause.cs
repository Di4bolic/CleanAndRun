using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{
    public AudioSource aS;
    public TextMeshProUGUI pauseButton;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        aS.Pause();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        aS.Play();            
    }

    public void Restart()
    {
        SceneManager.LoadScene("PlayingScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
