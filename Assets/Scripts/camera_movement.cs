using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 4.24)
        {
            transform.position += new Vector3(0, 0.003f, 0);
        }

    }

    public void goToLvlSelect()
    {
        transform.position = new Vector3(-2.753f, transform.position.y, transform.position.z);
    }

    public void goToControl()
    {
        transform.position = new Vector3(-10.273f, transform.position.y, transform.position.z);
    }


    public void goback()
    {
        transform.position = new Vector3(-7.056f, 4.24f, -10f);
    }



}
