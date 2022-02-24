using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight : MonoBehaviour
{
    private float rotationSpeedFloat;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        // use this line for instant-rotation
        transform.rotation = targetRotation;

        // use this line for rotation over time
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeedFloat);
    }
}
