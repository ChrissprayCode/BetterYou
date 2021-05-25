using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow_player : MonoBehaviour
{
    public float xMax = 5f;
    public float xMin = 5f;
    public float yMax = 5f;
    public float yMin = 5f;

    public Transform player;

    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, xMin, xMax), Mathf.Clamp(player.position.y, yMin, yMax), transform.position.z);
    }

}

//transform.position = new Vector3(Mathf.Clamp(player.position.x, -2.5f, 50f), Mathf.Clamp(player.position.y, -25f, 2.22f), transform.position.z)