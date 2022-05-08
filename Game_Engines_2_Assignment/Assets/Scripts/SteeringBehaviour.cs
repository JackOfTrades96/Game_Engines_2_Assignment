using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(ShipController))]
public abstract class SteeringBehaviour : MonoBehaviour
{
    public float weight = 1.0f;
    public Vector3 force;

    [HideInInspector]
    public ShipController ship;

    public void Awake()
    {
        ship = GetComponent<ShipController>();
    }

    public abstract Vector3 Calculate();
}
