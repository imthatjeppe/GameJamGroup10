using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeception : MonoBehaviour
{
    public Transform[] deceptions;
    public GameObject Player;
    public GameObject Enemy;

    private EnemyFollowPlayer setDestination;
    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        setDestination = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            TurnOn();
        }
    }

    private void TurnOn()
    {
        setDestination.target = deceptions[0];
        ReachedDeception();
    }

    void ReachedDeception()
    {
        if (Vector2.Distance(setDestination.transform.position, deceptions[0].position) < 2f)
        {

            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, setDestination.speed * Time.deltaTime);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
