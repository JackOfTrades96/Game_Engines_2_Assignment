using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPath : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();

    public int current = 0;

    public bool isLooped = true;

    public void OnDrawGizmos()
    {
        for (int i = 1; i < waypoints.Count; i++)
        {
            Gizmos.DrawLine(waypoints[i - 1], waypoints[i]);

        }

        if(isLooped)
        {
            Gizmos.DrawLine(waypoints[waypoints.Count - 1], waypoints[0]);
        }
    }

    public Vector3 NextWaypoint()
    {
        return waypoints[current];

    }

    public bool IsLastWaypoint()
    {
        return ! isLooped || (current == waypoints.Count - 1);
    }

    public void AdvanceToNextWaypoint()
    {
        if(! isLooped && (current == waypoints.Count -1 ))
        {
            current++; 
        }

        else
        {
            current = (current + 1) % waypoints.Count;
        }

    }

}
