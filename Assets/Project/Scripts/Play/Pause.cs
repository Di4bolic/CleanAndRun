using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (isPaused)
        {
            pauseButton.text = "|>";
            Time.timeScale = 1;
            aS.Play();
            isPaused = false;
        }
        else
        {
            pauseButton.text = "| |";
            Time.timeScale = 0;
            aS.Pause();
            isPaused = true;
        }
        

    }
}
