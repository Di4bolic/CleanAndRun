using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseUIValues : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Player>().munitions.text = (player.GetComponent<Player>().munitionsScore + 1).ToString();
    }
}
