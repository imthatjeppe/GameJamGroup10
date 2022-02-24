using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject FollowPlayer;

    private float followSpeed = 2.0f;

    void Update()
    {
        FollowPlayerPosition();
    }

    public void FollowPlayerPosition()
    {
        float interpolation = followSpeed * Time.deltaTime;

        Vector3 position = transform.position;
        position.y = Mathf.Lerp(transform.position.y, FollowPlayer.transform.position.y, interpolation);
        position.x = Mathf.Lerp(transform.position.x, FollowPlayer.transform.position.x, interpolation);

        transform.position = position;
    }
}
