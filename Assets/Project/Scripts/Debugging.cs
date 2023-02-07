using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour
{
    public void Log(string s)
    {
        Debug.LogWarning(s);
    }
}
