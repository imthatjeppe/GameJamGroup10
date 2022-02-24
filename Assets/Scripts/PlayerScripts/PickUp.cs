using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public float timer = 30;
    public float pickup = 0;
    public TextMeshProUGUI textpickup;
    public Text timerForHelp;
    private EnemyFollowPlayer enemySpeed;
    private Appear policeWillCome;
    private void Start()
    {
        enemySpeed = FindObjectOfType<EnemyFollowPlayer>();
        policeWillCome = FindObjectOfType<Appear>();
    }

    private void Update()
    {
        if(pickup == 5)
        {
            timer -= 1 * Time.deltaTime;
        }
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
            Invoke(nameof(loadVictory), timer);
            enemySpeed.speed = 3;
            timerForHelp.text = timer.ToString() + "seconds until help arrives";
            
        }
    }

    private void loadVictory()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
        Debug.Log("next scene loads");
    }
    

}
