using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject policewillappear;

    private PickUp pickup;
    // Start is called before the first frame update
    void Start()
    {
        policewillappear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pickup.pickup == 5)
        {
            policeWillAppear();
        }
    }

    public void policeWillAppear()
    {
        policewillappear.SetActive(true);
    }
}
