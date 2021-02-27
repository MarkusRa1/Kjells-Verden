using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject PrefabMonster;
    Node [] PathNode;
    ArrayList Mobs;
    public GameObject Mobfaen;
    public float MoveSpeed;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPositionHolder;
    public Transform EnemiesCollection;

    int MobCount;

    // Start is called before the first frame update
    void Start()
    {
        MobCount = 0;
        PathNode = GetComponentsInChildren<Node> ();
        Mobs = new ArrayList();
        MoveSpeed = 0.1F;
        SpawnMonster();
    }

    public void AddMobfaen(GameObject mobfaen) {
        MobCount++;
        Mobfaen mob = mobfaen.GetComponent<Mobfaen>();
        mob.SetCurrentPositionHolder(PathNode[0].transform.position);
        mob.SetName("Mob" + MobCount.ToString());
        Mobs.Add(mob);
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
        GameObject enemy = Instantiate(PrefabMonster, transform.position, transform.rotation);
        AddMobfaen(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * MoveSpeed;

        foreach (Mobfaen mob in Mobs){
            Debug.Log(mob.GetName() + " // " + PathNode.Length + " // " +  mob.GetNodeCount());

            if (mob.GetCurrentPositionHolder() != PathNode[mob.GetNodeCount()].transform.position){
                mob.transform.position = Vector3.Lerp(mob.transform.position, PathNode[mob.GetNodeCount()].transform.position, Timer*4);
                mob.SetCurrentPositionHolder(mob.transform.position);
            } else {
                if (mob.GetNodeCount() < PathNode.Length){
                    mob.IncNodeCount();
                    //CheckNode(mob);
                } else {
                    Debug.Log("GAME OVER");
                    enabled = false;
                    Destroy(mob);
                }
            }
        }

        //SpawnMonster();
    }
}
