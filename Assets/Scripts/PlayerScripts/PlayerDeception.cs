using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeception : MonoBehaviour
{
    public Transform[] deceptions;
    public GameObject Player;

    private EnemyFollowPlayer setDestination;
    private bool inRange;
    private bool deceptioned;

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
            Invoke(nameof(TurnOff), 8);
        }
    }

    private void TurnOn()
    {
        setDestination.target = deceptions[0];
    }

    private void TurnOff()
    {
        setDestination.target = deceptions[1];
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
