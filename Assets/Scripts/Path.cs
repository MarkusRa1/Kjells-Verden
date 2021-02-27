using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject PrefabMonster;
    Node [] PathNode;
    Transform[] children;

    public float MoveSpeed;
    public Transform EnemiesCollection;


    // Start is called before the first frame update
    void Start()
    {
        PathNode = GetComponentsInChildren<Node> ();
        children = GetComponentsInChildren<Transform> ();
        MoveSpeed = 0.1F;
        //SpawnMonster();
        InvokeRepeating("SpawnMonster", 0, 0.5f);
    }

    public void AddMobfaen(GameObject mobfaen) {
        Mobfaen mob = mobfaen.GetComponent<Mobfaen>();
        mob.transform.parent = EnemiesCollection;

    }
/*
    // check current node and have Mob move towards it
    void CheckNode(Mobfaen mob){
        Timer = 0;
        mob.SetCurrentPositionHolder(PathNode[mob.GetNodeCount()].transform.position);
    }
*/
    void SpawnMonster()
    {
        GameObject enemy = Instantiate(PrefabMonster, children[0].position, transform.rotation);
        Mobfaen mob = enemy.GetComponent<Mobfaen>();
        mob.NewStart(children);
        AddMobfaen(enemy);
    }


}
