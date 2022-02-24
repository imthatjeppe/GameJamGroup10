using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{

    private float pickup = 0;

    public TextMeshProUGUI textpickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickuptarget"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Pickup"))
        {
            pickup++;
            textpickup.text = pickup.ToString();

            Destroy(other.gameObject);
        }

        if (pickup == 5)
        {
            SceneManager.LoadScene(sceneBuildIndex: 2);
            Debug.Log("next scene loads");
        }

    }
    

}
