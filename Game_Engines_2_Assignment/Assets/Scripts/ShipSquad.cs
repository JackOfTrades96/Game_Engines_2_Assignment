using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exception = System.Exception;

public class ShipSquad : MonoBehaviour
{
   
    public int maxMembers = 0;
    public int numSquadMembers = 0;
    public GameObject leader;
    public float ShipDistance;

    private List<Vector3> squadPositions = new List<Vector3>();
    private List<Vector3> squadOffsets = new List<Vector3>();
    public List<GameObject> squadMembers = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (maxMembers != 0)
        {
            GenerateSquadPositions();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (squadMembers.Count > 0)
        {
            for (int i = squadMembers.Count - 1; i > -1; i--)
            {
                GameObject member = squadMembers[i];
                string memberState = member.transform.GetComponent<StateMachine>().currentState.GetType().Name;

                if (memberState == "Dead" && member.transform.tag != "SquadLeader")
                {
                    squadMembers.RemoveAt(i);
                    numSquadMembers -= 1;
                }
            }
        }

        
        if (leader != null)
        {
            string leaderStatus = leader.GetComponent<StateMachine>().currentState.GetType().Name;

            if (leaderStatus == "Dead")
            {
                foreach (Transform unit in transform)
                {
                    if (unit.GetComponent<StateMachine>().currentState.GetType().Name != "Dead")
                    {
                        squadMembers.Remove(unit.gameObject);
                        leader = unit.gameObject;
                        leader.tag = "SquadLeader";
                        break;
                    }
                }
            }
        }

    }


    void GenerateSquadPositions()
    {
            

            for (int i = 0; i < maxMembers; i++)
            {
              
                float side = (i % 2);
                if (side == 0)
                {
                    side = 1;
                }
                else
                {
                    side = -1;
                }

                float appliedShipDistance = ShipDistance + (Mathf.Ceil((i + 1.0f) / 2.0f) - 1) * ShipDistance;

              
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = "squad_pos_" + i.ToString();
                sphere.transform.GetComponent<SphereCollider>().enabled = false;
                sphere.transform.GetComponent<MeshRenderer>().enabled = false;
                sphere.transform.position = leader.transform.position + leader.transform.forward * (appliedShipDistance * -1);
                sphere.transform.position = sphere.transform.position + leader.transform.right * (appliedShipDistance * side);
                squadPositions.Add(sphere.transform.position);

               
                Vector3 offset = sphere.transform.position - leader.transform.position;
                offset = Quaternion.Inverse(leader.transform.rotation) * offset;
                squadOffsets.Add(offset);
            }

            leader.tag = "SquadLeader";
        
    }


    public Vector3 getSquadPosition(GameObject follower)
    {
        int index = squadMembers.IndexOf(follower);
        return squadPositions[index];
    }


    public Vector3 getSquadOffset(GameObject follower)
    {
        int index = squadMembers.IndexOf(follower);
     
            Vector3 offset = squadOffsets[index];
            return offset;

      
    }


    public bool joinSquad(GameObject follower)
    {
        if (numSquadMembers < maxMembers)
        {
            numSquadMembers += 1;
            follower.transform.parent = transform;
            squadMembers.Add(follower);

            return true;
        }
        return false;
    }
}
