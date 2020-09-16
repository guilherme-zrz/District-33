using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxSpeed = 10f;
    public float deacceleration = 1f;

    private EnemyController enemy;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();                                  
    }                                                                          
    void Update()                                                              
    {                
        movement.x = Input.GetAxisRaw("Horizontal");                            
        movement.y = Input.GetAxisRaw("Vertical");                              
                                                                               
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
       moveCharacter(movement);                                                

       if (rb.velocity.magnitude > maxSpeed)                                   
       {
           rb.velocity = rb.velocity.normalized * maxSpeed;                    
       }

       //Look at mouse's direction
       Vector2 lookDir = mousePos - rb.position;                               
       float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;  
       rb.rotation = angle;                                                    
    }

    void moveCharacter(Vector2 direction)                                       
    {                                                                           
        if (Input.GetKey(KeyCode.W))                                            
        {
            rb.AddForce(direction * moveSpeed);   
        }

        else if (Input.GetKey(KeyCode.A))

        {
            rb.AddForce(direction * moveSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(direction * moveSpeed);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(direction * moveSpeed);
        }

        else
            rb.velocity = rb.velocity * 0.95f;                                  

    }

}
