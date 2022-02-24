using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{

    private float pickup = 0;
    public TextMeshProUGUI textpickup;
    private EnemyFollowPlayer enemySpeed;
    private Appear policeWillCome;
    private void Start()
    {
        enemySpeed = FindObjectOfType<EnemyFollowPlayer>();
        policeWillCome = FindObjectOfType<Appear>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickuptarget"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Pickup"))
        {
            pickup++;
            textpickup.text = pickup.ToString() + "out of 5 items";

            Destroy(other.gameObject);
        }

        if (pickup == 5)
        {
            Invoke(nameof(loadVictory), 30);
            enemySpeed.speed = 3;
            policeWillCome.policeWillAppear();
        }
    }

    private void loadVictory()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
        Debug.Log("next scene loads");
    }
    

}
