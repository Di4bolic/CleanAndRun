using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGarbage : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sR;

    [SerializeField]
    private List<Sprite> listSprites;

    [SerializeField]
    private GameObject feedback;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        sR.sprite = listSprites[Random.Range(0, listSprites.Count)];
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "Pieds" && !player.stun)
        {
            Instantiate(feedback, transform.position - new Vector3(0.8f, -0.2f, 0), Quaternion.identity);      
        }
    }
}
