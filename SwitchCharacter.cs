using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public PlayerController player;
    public DollController doll;   
    public Shooting shooting;

    private Transform playerTransform;
    private Transform target;
    private Collider2D playerCollider;
    private Rigidbody2D playerRB, dollRB;

    public bool isPlayerEnabled;
    public bool isDollEnabled;

    public float coolDown = 2;
    public float coolDownTimer;
    public float speed;
    public float distance;

    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        dollRB = doll.GetComponent<Rigidbody2D>();

        playerCollider = player.GetComponent<Collider2D>();

        doll.enabled = true;
        player.enabled = false;
        shooting.enabled = false;

        isPlayerEnabled = false;
        isDollEnabled = true;

        playerTransform = player.GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Doll").GetComponent<Transform>();
    }

    void Update()
    {

        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && coolDownTimer == 0)
        {
            if (isPlayerEnabled)
            {
                dollSwitch();
                coolDownTimer = coolDown;
            }

            else if (isPlayerEnabled == false)
            {
                playerSwitch();
                coolDownTimer = coolDown;
            }
        }

        if (isPlayerEnabled == false)
        {

            if (Vector2.Distance(playerTransform.position, target.position) > distance)
            {
                playerCollider.enabled = false;
                playerTransform.position = Vector2.MoveTowards(playerTransform.position, target.position, speed * Time.deltaTime);
            }

        }

        else
        {
            playerCollider.enabled = true;
        }

    }

    void playerSwitch()
    {
        shooting.enabled = true;
        player.enabled = true;
        isPlayerEnabled = true;

        doll.enabled = false;
        isDollEnabled = false;
    }

    void dollSwitch()
    {
        shooting.enabled = false;
        player.enabled = false;
        isPlayerEnabled = false;
        speed = 10f;

        playerRB.velocity = Vector2.zero;

        doll.enabled = true;
        isDollEnabled = true;
    }
}
