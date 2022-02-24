using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{

    public float speed;
    public Transform target;
    public GameObject Enemy;
    public Animator animator;

    private Transform playerPos;   
    private PlayerDeception deception;
    private PlayerMovement Hiding;

    // Start is called before the first frame update
    void Start()
    {
        target = playerPos;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Hiding = FindObjectOfType<PlayerMovement>();
        deception = FindObjectOfType<PlayerDeception>();
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

    public void StopFollowPlayer()
    {
        if (Hiding.isHidden)
        {
            target = deception.deceptions[2];
        }
    }

    public void ReturnToFollowPlayer()
    {
        if (!Hiding.isHidden)
        {
            target = deception.deceptions[1];
        }
    }
}
    
