using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int health = 3;

    public int maxHealth = 3;

    private bool canDamage = true;

    public TextMeshProUGUI healthText;
    public Transform player, doll;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        doll = GameObject.FindGameObjectWithTag("Doll").GetComponent<Transform>();

    }

    void Update()
    {
        healthText.text = "Health: " + health;
    }

    public void dollDamage()
    {
        if (canDamage)
        {
            health -= 1;
            StartCoroutine(Wait());

            if (health <= 0)
            {
                killDoll();
            }
        }

    }

    void killDoll()
    {
        Destroy(doll.gameObject);
        Destroy(player.gameObject);
    }

    IEnumerator Wait()
    {
        canDamage = false;
        yield return new WaitForSeconds(1f);
        Debug.Log("Wait");
        canDamage = true;
    }



}
