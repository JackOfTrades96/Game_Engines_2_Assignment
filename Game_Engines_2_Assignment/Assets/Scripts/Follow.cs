using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Follow : SteeringBehaviour
{
    public ShipPath path;

    Vector3 nextWaypoint;

    public float waypointDistance = 5;

    public int next = 0;
    public bool looped = false;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, nextWaypoint);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector3 NextWaypoint()
    {
        return path.waypoints[next];
    }


    public void AdvanceToNext()
    {
        if (looped)
        {
            next = (next + 1) % path.waypoints.Count;
        }
        else
        {
            if (next != path.waypoints.Count - 1)
            {
                next++;
            }
        }
    }


    public bool IsLast()
    {
        return next == path.waypoints.Count - 1;
    }

    public override Vector3 Calculate()
    {
        nextWaypoint = NextWaypoint();
        if (Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
        {
            AdvanceToNext();
        }

        if (!looped && IsLast())
        {
            return ship.ArriveForce(nextWaypoint);
        }
        else
        {
            return ship.SeekForce(nextWaypoint);
        }
    }



}
