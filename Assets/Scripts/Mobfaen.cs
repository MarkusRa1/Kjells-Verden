using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobfaen : MonoBehaviour
{
    // Start is called before the first frame update

    int NodeCount;
    string name;
    int CurrentNode;
    public Transform[] wayPointList;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;
    public int health = 100;

    // put the points from unity interface

    public void NewStart(Transform[] Nodes)
    {
        NodeCount = 0;
        wayPointList = Nodes;
    }

    // Update is called once per frame
    void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            Walk();
        } 
        else
        {
            Debug.Log("Game Over");
            transform.parent.GetComponent<TaperEnemies>().TaperObject.GetComponent<Taper>().GameOver(Time.realtimeSinceStartup);
            Debug.Log(Time.realtimeSinceStartup);
        }
    }

    void Walk()
    {
        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (transform.position == targetWayPoint.position && currentWayPoint < wayPointList.Length)
        {
            currentWayPoint++;
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
