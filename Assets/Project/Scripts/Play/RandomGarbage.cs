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

    // Start is called before the first frame update
    void Start()
    {
        sR.sprite = listSprites[Random.Range(0, listSprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(feedback, transform.position, Quaternion.identity);
    }
}
