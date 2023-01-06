using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Music : ScriptableObject
{
    public AudioClip music;
    public float bpm;
    public float lenght;
    public float startSpeed;
    public float endSpeed;
    public string difficulty;
    public string titre;
}
