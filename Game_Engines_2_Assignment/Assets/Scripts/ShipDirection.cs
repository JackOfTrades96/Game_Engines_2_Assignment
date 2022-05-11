using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDirection : MonoBehaviour
{
    public Vector3 destinationPos;
    private List<Vector3> pathPoints = new List<Vector3>();
    private Quaternion desiredRotation;
    private ShipPath path;
    public bool faceDestinationComplete;
    public float radius = 15.0f;
    private Dictionary<string, float> behaviourState = new Dictionary<string, float>();
    public GameObject debugSpheres;



    private void OnEnable()
    {
        pathPoints.Clear();
        behaviourState.Clear();
        faceDestinationComplete = false;

      
        Vector3 originPos = transform.position;

        int numberOfCirclePoints = 8;
        int minimumDegrees = 90;
        float degreeBetweenPoint = 360 / numberOfCirclePoints;

        Vector3 relativePos = destinationPos - transform.position;
        desiredRotation = Quaternion.LookRotation(relativePos, Vector3.up);
       
        Quaternion oppositeRotation = desiredRotation * Quaternion.Euler(0, 180f, 0);


        
        GameObject sphere = Instantiate(debugSpheres);
        sphere.transform.position = transform.position + transform.forward * radius / 2;
        sphere.name = "first";
        Vector3 firstPoint = sphere.transform.position;

      
        sphere = Instantiate(debugSpheres);
        sphere.transform.rotation = oppositeRotation;
        sphere.transform.position = transform.position + sphere.transform.forward * radius;
        sphere.name = "secondLast";
        Vector3 secondLastPoint = sphere.transform.position;

        pathPoints.Add(firstPoint);

        
        for (int i = 1; i < numberOfCirclePoints * 2 - 1; i++)
        {
           
            sphere = Instantiate(debugSpheres);
            sphere.transform.rotation = transform.rotation;
            sphere.transform.position = originPos;
            sphere.name = i.ToString();

           
            float rotDegree = degreeBetweenPoint * i;
            sphere.transform.RotateAround(originPos, Vector3.up, rotDegree);
            Vector3 newPos = sphere.transform.position;
            newPos.y = transform.position.y;
            sphere.transform.position = newPos + sphere.transform.forward * radius;

            pathPoints.Add(sphere.transform.position);

          
            if (rotDegree >= minimumDegrees)
            {
              
                float distBetweenPoints = Vector3.Distance(pathPoints[1], pathPoints[2]);
                float distToSecondLast = Vector3.Distance(sphere.transform.position, secondLastPoint);
                if (distToSecondLast <= distBetweenPoints)
                {
                    break;
                }
            }

        }

        Vector3 lastPoint = originPos;

        pathPoints.Add(secondLastPoint);
        pathPoints.Add(lastPoint);

      
        GameObject pathObj = new GameObject();
        path = pathObj.AddComponent<ShipPath>();
        print(pathPoints.Count);
        path.waypoints = pathPoints;
        path.isLooped = false;
        path.preDefinedWaypoints = true;
        gameObject.GetComponent<Follow>().path = path;
        gameObject.GetComponent<Follow>().enabled = true;
        behaviourState.Add("Boid.maxSpeed", gameObject.GetComponent<ShipController>().maxSpeed);
        gameObject.GetComponent<ShipController>().maxSpeed = 10;


    }


    private void OnDisable()
    {
       
        gameObject.GetComponent<ShipController>().maxSpeed = behaviourState["Boid.maxSpeed"];
        gameObject.GetComponent<Follow>().enabled = false;
    }

    private void Update()
    {
        if (path.current == path.waypoints.Count - 1)
        {
            gameObject.GetComponent<ShipController>().maxSpeed = 5;

            float dist = Vector3.Distance(transform.position, pathPoints[pathPoints.Count - 1]);
            
            if (dist < 1.0f)
            {
                gameObject.GetComponent<ShipController>().maxSpeed = behaviourState["Boid.maxSpeed"];
                gameObject.GetComponent<ShipController>().velocity = new Vector3(0, 0, 0);
                gameObject.GetComponent<Follow>().enabled = false;
                faceDestinationComplete = true;

              
            }
            else if (dist < radius / 1.5f)
            {
                gameObject.GetComponent<ShipController>().maxSpeed = 10;
            }

        }
    }


}
