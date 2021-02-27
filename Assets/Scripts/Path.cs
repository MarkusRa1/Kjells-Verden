using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    Node [] PathNode;
    ArrayList Mobs;
    public GameObject Mobfaen;
    public float MoveSpeed;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPositionHolder;

    int MobCount;

    // Start is called before the first frame update
    void Start()
    {
        MobCount = 0;
        PathNode = GetComponentsInChildren<Node> ();
        Mobs = new ArrayList();
        MoveSpeed = 0.1F;
    }

    public void AddMobfaen(GameObject mobfaen) {
        MobCount++;
        Mobfaen mob = mobfaen.GetComponent<Mobfaen>();
        mob.SetCurrentPositionHolder(PathNode[0].transform.position);
        mob.SetName("Mob" + MobCount.ToString());
        Mobs.Add(mob);
    }

    // Reset timer, increase node count for mob, and set new position to new node
    void CheckNode(Mobfaen mob){
        Timer = 0;
        mob.IncNodeCount();
        Debug.Log("Mob name: " + mob.GetName() + " at node: " + PathNode[mob.GetNodeCount()] + " with node count: " + mob.GetNodeCount());
        mob.SetCurrentPositionHolder(PathNode[mob.GetNodeCount()].transform.position);
    }

    // Update is called once per frame. Iterate through mobs and move them to the new node if possible
    void Update()
    {
        Timer += Time.deltaTime * MoveSpeed;

        foreach (Mobfaen mob in Mobs){
            Debug.Log("LENGDE:" + Mobs.Count);
       //     Debug.Log(mob.GetName() + " // " + PathNode.Length + " // " +  mob.GetNodeCount());

            if (mob.transform.position != PathNode[mob.GetNodeCount()].transform.position){
                mob.transform.position = Vector3.Lerp(mob.transform.position, mob.GetCurrentPositionHolder(), Timer*4);
            } else {

                if (mob.GetNodeCount() < PathNode.Length){
                    CheckNode(mob);
                } else {
                    Debug.Log("GAME OVER");
                    enabled = false;
                }
            }
        }
    }
}
