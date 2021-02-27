using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobfaen : MonoBehaviour
{
    // Start is called before the first frame update

    int NodeCount;
    string name;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;

    void Start()
    {
        NodeCount = 0;
    }

    public int GetNodeCount(){
        return NodeCount;
    }

    public void IncNodeCount(){
        NodeCount++;
    }

    public void SetName(string givenName){
        name = givenName;
    }

    public string GetName(){
        return name;
    }

    public Vector3 GetCurrentPositionHolder(){
        return CurrentPositionHolder;
    }

    public void SetCurrentPositionHolder(Vector3 NewPositionHolder){
        CurrentPositionHolder = NewPositionHolder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
