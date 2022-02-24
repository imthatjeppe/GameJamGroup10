using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
    }

    private void facePlayer()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition = Camera.main.ScreenToWorldPoint(playerPosition);

        Vector2 direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);

        transform.up = direction;
    }
}
