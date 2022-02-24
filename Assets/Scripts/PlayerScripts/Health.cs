using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    public static int playerHealth;
    
    void Start()
    {
        playerHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            GameOver();
        }

        if (Vector2.Distance(Enemy.transform.position, Player.transform.position) < 0.2f)
        {
            Invoke(nameof(SelectNewDestination), waitTime);
            patrol = false;
        }
    }


    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
