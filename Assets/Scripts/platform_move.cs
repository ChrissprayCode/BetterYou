using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_move : MonoBehaviour
{
    private Vector3 velocity = new Vector3(0,2,0);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "player")
        {
            collision.collider.transform.SetParent(transform);
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "platform_top")
        {
            //Debug.Log("TOP");
            velocity = new Vector3(0, -2, 0);
        }
        else if (collision.gameObject.tag == "platform_bot")
        {
            //Debug.Log("KILLME");
            velocity = new Vector3(0, 2, 0);
        }
        else if (collision.gameObject.tag == "test")
        {
            //Debug.Log("KILLME");
            velocity = new Vector3(0, -2, 0);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.collider.transform.SetParent(null);
        }
 
    }

    private void FixedUpdate()
    {

            transform.position += (velocity * Time.deltaTime);

    }
}
