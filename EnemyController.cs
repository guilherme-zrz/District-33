using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public int HitPoints;
    public bool enemyMove;
    SpriteRenderer sprite;
    AIPath path;

    void Start()
    {
        enemyMove = false;
        HitPoints = 3;
        sprite = GetComponent<SpriteRenderer>();
        path = GetComponent<AIPath>();
    }

    void Update()
    {
        if (HitPoints <= 0)
        {
            Destroy(gameObject);
            
        }

        if (enemyMove)
        {
            path.canMove = true;
        }

        else if (!enemyMove)
        {
            path.canMove = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            enemyMove = true;
            HitPoints = HitPoints - 1;
            sprite.color = new Color(1, 1, 1, 1);

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Wait");
        sprite.color = new Color(1, 0.5f, 0.5f, 1);
    }

}

