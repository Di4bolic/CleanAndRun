using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Music : ScriptableObject
{
    public AudioClip music;
    public float bpm;
    public float lengh;
    public float startSpeed;
    public float endSpeed;
    public string difficulty;
    public float baisseDivision;
    public string titre;
}
