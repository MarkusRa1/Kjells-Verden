using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public int damage = 100;
    public float speed = 10f;
    public Rigidbody2D rb;
    private Transform enemyContainer1;

    void TheStart(Transform enemyContain)
    {
        enemyContainer1 = enemyContain;
        Transform target = FindClosestChild(enemyContainer1);

        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            rb.velocity = direction / direction.magnitude * speed;
            Destroy(gameObject, 50f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Transform target = FindClosestChild(enemyContainer1);

        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            rb.velocity = direction / direction.magnitude * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    Transform FindClosestChild(Transform enemyContainer)
    {
        if (enemyContainer.childCount == 0)
            return null;

        Transform closestEnemy = enemyContainer.GetChild(0);
        Vector2 bulletPos = transform.position;
        Vector2 enemyPos = closestEnemy.position;
        float closestEnemyMagnitude = (bulletPos - enemyPos).magnitude;

        foreach (Transform enemy in enemyContainer)
        {
            enemyPos = enemy.position;
            float enemyMagnitude = (bulletPos - enemyPos).magnitude;
            if (enemyMagnitude < closestEnemyMagnitude)
            {
                closestEnemy = enemy;
                closestEnemyMagnitude = enemyMagnitude;
            }
        }
        return closestEnemy;
    }


    // Virker ikke!!!!
    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    Debug.Log(hitInfo.name);
    //
    //    Enemy enemy = hitInfo.GetComponent<Enemy>();
    //    //Debug.Log()
    //    if (enemy != null)
    //    {
    //        enemy.TakeDamage(damage);
    //        Destroy(gameObject);
    //    }
    //}
}
