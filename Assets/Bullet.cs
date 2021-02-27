using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 100;
    public float speed = 20f;
    public Rigidbody2D rb;

    void TheStart(Transform enemyContainer)
    {
        Transform enemy = FindClosestChild(enemyContainer);
        if (enemy != null)
        {
            Vector2 direction = enemy.position - transform.position;
            rb.velocity = direction/direction.magnitude * speed;
            Destroy(gameObject, 10f);
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

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
