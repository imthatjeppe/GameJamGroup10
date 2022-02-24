using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Slider Staminabar;
    public Animator animator;

    public bool isHidden;
    public float speed = 5;

    private float startSpeed = 5;
    private float sprint = 8;
    private float currentStamina = 100;

    private EnemyFollowPlayer randomMoveSpots;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = 100;
        randomMoveSpots = FindObjectOfType<EnemyFollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void movement()
    {
       
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(x, y).normalized * Time.deltaTime * speed;
        transform.Translate(movement);

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            speed = sprint;
            LoseStamina(15);
        }
        else
        {
            speed = startSpeed;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            GainStamina(2);
        }
    }
    private void LoseStamina(float LoseStamina)
    {
        currentStamina -= LoseStamina * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0, 100);
        Staminabar.value = currentStamina;
    }

    private void GainStamina(float GainStamina)
    {
        LoseStamina(-GainStamina);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            isHidden = true;
            randomMoveSpots.StopFollowPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            isHidden = false;
            randomMoveSpots.ReturnToFollowPlayer();
        }
    }
}
