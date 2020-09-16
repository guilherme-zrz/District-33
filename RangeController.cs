using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    public EnemyController enemy;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Doll"))
        {
            enemy.enemyMove = true;
        }

    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Doll"))
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        this.enemy.enemyMove = false;
    }
}
