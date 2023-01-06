using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public ManagerManager mM;
    public AudioSource audioSource;

    public List<Music> musics;
    public Music selectedMusic;

    public float lengthMusic;
    public float interval;
    public string difficulty;

    // Awake is called before Start
    void Awake()
    {
        mM = FindObjectOfType<ManagerManager>();
        selectedMusic = musics[mM.selectedMusicIndex];
        audioSource.clip = selectedMusic.music;
        audioSource.Play(0);

        interval = (60f / selectedMusic.bpm)*12;

        difficulty = selectedMusic.difficulty;

        lengthMusic = selectedMusic.lenght;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
