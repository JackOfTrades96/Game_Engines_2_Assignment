using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShip : MonoBehaviour
{
    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 force;
    public float speed;
    public float mass = 1;
    public float maxSpeed = 5;
    public bool seekEnabled = true;
    public Transform seekTargetTransform;

    public TestPath testPath;
    public bool pathFollowEnabled = false;


    


    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = (target - transform.position).normalized * maxSpeed;
        return desired - velocity;
    }


    public Vector3 PathFollow()
    {
        Vector3 nextWaypoint = testPath.NextWaypoint();
        float dist = Vector3.Distance(nextWaypoint, transform.position);
        if(dist < 1.0f)
        {
            testPath.AdvanceToNextWaypoint();
        }

        return Seek(nextWaypoint);
    }

    Vector3 Calculate()
    {
        force = Vector3.zero;

        if(seekEnabled)
        {
            force += Seek(seekTargetTransform.position);
        }

        if(pathFollowEnabled)
        {
            force += PathFollow();
        }

        return force;
    }


    void Update()
    {
        force = Calculate();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        speed = velocity.magnitude;

        if(speed > 0)
        {
            transform.forward = velocity;
        }
    }

}
