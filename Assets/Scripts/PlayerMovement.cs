using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public Transform respawnPoint;
    public Rigidbody2D rb;
    public float hopForce;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool isDead = false;
    bool onChest = false;
    bool openChest = false;
    GameObject slime;
    GameObject coin;
    [SerializeField] private GameObject chestUI;
    [SerializeField] private GameObject endUI;
    [SerializeField] private GameObject coinUI;
    [SerializeField] private GameObject tipUI;
    [SerializeField] private GameObject warningUI;

    private void Start()
    {
        chestUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x > 0 && screenPos.x < Screen.width && isDead == false)
        {

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && onChest)
        {
            Debug.Log("E PRESSED");
            openChest = true;
            Time.timeScale = 0;
            AudioListener.pause = true;
            chestUI.SetActive(false);
            endUI.SetActive(true);
            coinUI.SetActive(false);
            
        }
        if (openChest && Input.GetKeyDown(KeyCode.Tab))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Application.OpenURL("https://cs2s.yorkdc.net/~christopher.spray/DISS/questionnaire.php");
            warningUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            Application.OpenURL("https://cs2s.yorkdc.net/~christopher.spray/DISS/debrief.php");
        }
    }

    public void OnLanding()
    {
       animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike" || collision.gameObject.tag == "slime")
        {
            Debug.Log("PLAYER HIT SPIKES");
            animator.SetBool("HitSpike", true);
            StartCoroutine(DeathTimer());
            isDead = true;
        }
        else if(collision.gameObject.tag == "slime_kill_zone")
        {
           slime = collision.transform.parent.gameObject;
           Destroy(slime);
            slimeHop();
        }
        else if (collision.gameObject.tag == "coin")
        {
            coin = collision.transform.parent.gameObject;
            Destroy(coin);
        }
        else if (collision.gameObject.tag == "Chest")
        {
            onChest = true;
            chestUI.SetActive(true);  
        }
        else if (collision.gameObject.tag == "Tip")
        {
            tipUI.SetActive(true);
            StartCoroutine(tipTimer());
        }
        else if (collision.gameObject.tag == "Respawn")
        {
            respawnPoint = collision.transform;
        }

    }


    void slimeHop()
    {
        rb.AddForce(new Vector2(0f, hopForce));
    }


    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5);
        transform.position = new Vector3(respawnPoint.position.x, respawnPoint.position.y, transform.position.z);
        animator.SetBool("HitSpike", false);
        isDead = false;
    }

    IEnumerator tipTimer()
    {
        yield return new WaitForSeconds(3);
        tipUI.SetActive(false);

    }
}
