using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{

    public float speed;
    public Transform target;
    public GameObject Enemy;

    private Transform playerPos;   
    private PlayerDeception deception;
   
    // Start is called before the first frame update
    void Start()
    {
        target = playerPos;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }


    public void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
    
