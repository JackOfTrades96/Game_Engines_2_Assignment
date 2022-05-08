using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public List<Transform> triggers = new List<Transform>();
    public int current = 0;


    void Start()
    {
        triggers.Clear();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            triggers.Add(transform.GetChild(i));
        }
    }


    public Transform GetCurrentPoint()
    {
        Transform pointToReturn = triggers[current];
        return pointToReturn;//the one before advanced
    }


    public Transform GetNextPoint()
    {
        Transform pointToReturn = triggers[current];
        AdvanceToNext();
        return pointToReturn;//the one before advanced
    }



    public void AdvanceToNext()
    {
        if (current != triggers.Count - 1)
        {
            current++;
        }
    }

    public bool IsLast()
    {
        return current == triggers.Count - 1;
    }


}
