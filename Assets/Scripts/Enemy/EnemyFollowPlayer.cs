using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{

    public float speed;

    private Transform target;
    private Transform deceptions;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        deceptions = GameObject.FindGameObjectWithTag("Deception").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }


    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void playerDeception()
    {
        //work In Progress
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = Vector2.MoveTowards(transform.position, deceptions.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerDeception();
    }
}
