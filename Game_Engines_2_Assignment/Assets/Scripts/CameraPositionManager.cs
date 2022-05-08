using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionManager : MonoBehaviour
{
    public List<Transform> cameraPositions = new List<Transform>();
    public int current = 0;



    void Start()
    {
        cameraPositions.Clear();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            cameraPositions.Add(transform.GetChild(i));
        }
    }

    public Transform GetCurrentPoint()
    {
        Transform pointToReturn = cameraPositions[current];
        return pointToReturn;//the one before advanced
    }


    public Transform GetNextPoint()
    {
        Transform pointToReturn = cameraPositions[current];
        AdvanceToNext();
        return pointToReturn;//the one before advanced
    }


    public void AdvanceToNext()
    {
        if (current != cameraPositions.Count - 1)
        {
            current++;
        }
    }

    public bool IsLast()
    {
        return current == cameraPositions.Count - 1;
    }
}
