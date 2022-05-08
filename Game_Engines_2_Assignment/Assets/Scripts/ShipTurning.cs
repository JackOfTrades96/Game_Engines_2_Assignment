using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTurning : SteeringBehaviour
{
    public GameObject target;
    public int turnSide;
    public float turnSpeed = 0.7f;
    public Quaternion desiredRotation;
    public float marginOfErrorDegrees = 20;
    public Vector3 initPos;
    public bool complete;


    public void OnEnable()
    {
        initPos = transform.position;
        
        desiredRotation = transform.localRotation * Quaternion.Euler(0, 180f, 0);

        target = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        target.transform.GetComponent<SphereCollider>().enabled = false;
        target.transform.GetComponent<MeshRenderer>().enabled = false;
        target.transform.position = transform.forward * 100.0f;

        complete = false;
    }



    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, target.transform.position);
           
        }
    }



    public override Vector3 Calculate()
    {
        return ship.SeekForce(target.transform.position);
    }





}
