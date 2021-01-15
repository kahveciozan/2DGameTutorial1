using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private bool followPlayer;
    private float minTreshold_Y = -2.6f;

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (player.position.y < (transform.position.y - minTreshold_Y) )
            followPlayer = false;

        if ( player.position.y > transform.position.y )
            followPlayer = true;

        if (followPlayer)
        {
            Vector3 temporary = transform.position;
            temporary.y = player.position.y;
            transform.position = temporary;
        }

        
    }
}
