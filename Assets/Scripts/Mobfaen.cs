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
            Debug.Log("Walk");
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            Walk();
        } 
        else
        {
            Debug.Log("Game Over");
        }
    }

    void Walk()
    {
        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }
}
