using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollController : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Vector2 direction;
    public float knockbackAmount = 2.0f;

    public Rigidbody2D rb, enemyrb;
    public GameController gameControl;
    public EnemyController enemy;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            gameControl.dollDamage();
            Debug.Log("Player was damaged");
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
