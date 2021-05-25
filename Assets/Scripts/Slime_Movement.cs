using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Movement : MonoBehaviour
{

    public Animator animator;

    public float move_speed;
    public bool move_right;

    void Update()
    {

        if (move_right)
        {
            transform.Translate(2 * Time.deltaTime * move_speed, 0, 0);
            transform.localScale = new Vector2(-8, 8);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * move_speed, 0, 0);
            transform.localScale = new Vector2(8, 8);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("turn"))
        {
            //Debug.Log("HIT TURNZONE");
            if (move_right)
            {
                move_right = false;
                //Debug.Log("HIT RIGHT WALL");
            }
            else
            {
                move_right = true;
               // Debug.Log("HIT LEFT WALL");
            }
        }
    }

}
