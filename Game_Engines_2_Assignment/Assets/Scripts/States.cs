using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Alive : State
{
    public override void Enter()
    {

    }

    public override void Think()
    {
        ShipCombatController shipCombatController = owner.GetComponent<ShipCombatController>();

        if (shipCombatController.health <= 0)
        {
            Dead dead = new Dead();
            owner.ChangeState(dead);
            owner.SetGlobalState(dead);
            return;

        }

        if(shipCombatController.enemy == null)
        {
            if(shipCombatController.EnemyInRange())
            {
                owner.ChangeState(new AttackState());
                return;
            }
        }

        

    }

    public override void Exit()
    {

    }


}


public class Dead : State
{
    public override void Enter()
    {
        owner.GetComponent<Explosion>().enabled = true;
        owner.GetComponent<BoxCollider>().enabled = false;

        SteeringBehaviour[] steeringBehaviours = owner.GetComponent<ShipController>().GetComponents<SteeringBehaviour>();
        foreach(SteeringBehaviour steeringBehaviour in steeringBehaviours)
        {
            steeringBehaviour.enabled = false;
        }

        owner.GetComponent<StateMachine>().enabled = false;
        owner.GetComponent<ShipController>().enabled = false;
    }

    public override void Think()
    {
       
    }

    public override void Exit()
    {

    }


}



class IdleState : State
{
    public override void Enter()
    {

    }

    public override void Think()
    {
        // If not in a squad
        if (owner.transform.parent == null || owner.transform.parent.transform.tag != "ShipSquad")
        {
            // Select all squad leaders
            GameObject[] squadLeaders = GameObject.FindGameObjectsWithTag("SquadLeader");
            for (int i = 0; i < squadLeaders.Length; i++)
            {
                GameObject squadLeader = squadLeaders[i];

                // Check if squad leader belongs to the same affilitation (in other words, is not enemy squad leader)
                string ownerAffiliation = owner.transform.Find("Tag").tag;
                string leaderAffiliation = squadLeader.transform.Find("Tag").tag;
                if (ownerAffiliation != leaderAffiliation)
                {
                    continue;
                }


                float distToLeader = Vector3.Distance(owner.transform.position, squadLeader.transform.position);

                // If squad leader within range check if there are troops needed
                if (distToLeader < 300.0f)
                {
                    Transform squadObject = squadLeader.transform.parent;
                    ShipSquad squad = squadObject.GetComponent<ShipSquad>();

                    // Join squad if there is space
                    bool joined = squad.joinSquad(owner.gameObject);
                    if (joined)
                    {
                        owner.ChangeState(new FollowerState());
                    }
                }
            }
        }
        else if (owner.transform.parent.transform.tag == "Squad")
        {
            if (owner.transform.tag == "SquadLeader")
            {
                owner.ChangeState(new ExitAsteroidField());
            }
            else
            {
                owner.ChangeState(new FollowerState());
            }
        }
    }

    public override void Exit()
    {

    }
}




public class AttackState : State
{
    public override void Enter()
    {
        owner.GetComponent<ShipController>().maxSpeed = 45.0f;
        owner.GetComponent<Seek>().targetGameObject = owner.GetComponent<ShipCombatController>().enemy;
        owner.GetComponent<Seek>().enabled = true;
        owner.GetComponent<ObstacleAvoidance>().enabled = true;     
        owner.GetComponent<ObstacleAvoidance>().weight = 1;
       
    }

    public override void Think()
    {
        

        Vector3 toEnemy = owner.GetComponent<ShipCombatController>().enemy.transform.position - owner.transform.position;

        if (Vector3.Angle(owner.transform.forward, toEnemy) < 90 && toEnemy.magnitude < 2000.0f)
        {
            owner.GetComponent<ShipCombatController>().PhaserFire();
        }

        float distanceToEnemy = Vector3.Distance(owner.GetComponent<ShipCombatController>().enemy.transform.position, owner.transform.position);

        if(distanceToEnemy < 250.0f)
        {
            owner.ChangeState(new RetreatState());
        }

        else if (distanceToEnemy < 1000.0f)
        {
            owner.GetComponent<Seek>().enabled = false;
            owner.GetComponent<Pursue>().target = owner.GetComponent<ShipCombatController>().enemy.GetComponent<ShipController>();
            owner.GetComponent<Pursue>().enabled = true;
        }

    }

    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
        owner.GetComponent<Pursue>().enabled = false;
    }
}
  
public class DefendState : State
{
    public override void Enter()
    {
        owner.GetComponent<ShipController>().maxSpeed = 0.0f;
       
        owner.GetComponent<Seek>().enabled = false;
        owner.GetComponent<Pursue>().enabled = false;

        owner.GetComponent<ObstacleAvoidance>().enabled = true;
        owner.GetComponent<ObstacleAvoidance>().weight = 1;
    }

    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<ShipCombatController>().enemy.transform.position - owner.transform.position;
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 90 && toEnemy.magnitude < 4000.0f)
        {
            owner.GetComponent<ShipCombatController>().PhaserFire();
        }

        float distanceToEnemy = Vector3.Distance(owner.GetComponent<ShipCombatController>().enemy.transform.position, owner.transform.position);

        if (distanceToEnemy < 250.0f)
        {
            owner.ChangeState(new RetreatState());
        }

       


    }





    public override void Exit()
    {

    }

}

public class RetreatState : State
{
    public override void Enter()
    {
        owner.GetComponent<ShipController>().maxSpeed = 45.0f;
        owner.GetComponent<Flee>().targetGameObject = owner.GetComponent<ShipCombatController>().enemy;
        owner.GetComponent<Flee>().enabled = true;

        float retreatDistance = Random.Range(100.0f, owner.GetComponent<ShipCombatController>().maxRetreatDistance);
        owner.GetComponent<ShipCombatController>().retreatDistance = retreatDistance;


    }

    public override void Think()
    {
        if(owner.GetComponent<ShipCombatController>().enemy)
        {
            float distanceToEnemy = Vector3.Distance(owner.GetComponent<ShipCombatController>().enemy.transform.position, owner.transform.position);
            if(distanceToEnemy > owner.GetComponent<ShipCombatController>().retreatDistance)
            {
                owner.GetComponent<Flee>().enabled = false;
                owner.GetComponent<ShipTurning>().enabled = true;
            }

            if(owner.GetComponent<ShipTurning>().enabled == true && owner.GetComponent<ShipTurning>().complete == true)
            {
                owner.GetComponent<ShipTurning>().enabled = false;
                owner.ChangeState(new AttackState());
            }

           
        }

       
    }

    public override void Exit()
    {
        owner.GetComponent<ShipTurning>().enabled = false;
        owner.GetComponent<Flee>().enabled = false;
    }
}

 class SquadFollow : State
{
    public override void Enter()
    {
        OffsetPursue offsetPursue = owner.GetComponent<OffsetPursue>();
        ShipSquad shipSquad = owner.transform.parent.transform.GetComponent<ShipSquad>();
        owner.GetComponent<ObstacleAvoidance>().enabled = true;
        owner.GetComponent<OffsetPursue>().enabled = true;
       
       
        

    }

    public override void Think()
    {
        OffsetPursue offsetPursue = owner.GetComponent<OffsetPursue>();
        ShipSquad shipSquad = owner.transform.parent.transform.GetComponent<ShipSquad>();
        Vector3 offset = shipSquad.getSquadOffset(owner.gameObject);

        offsetPursue.leader = shipSquad.leader.GetComponent<ShipController>();
        offsetPursue.offset = offset;
    }

    public override void Exit()
    {
        owner.GetComponent<OffsetPursue>().enabled = false;
    }
}

class PatrolState : State
{
    public override void Enter()
    {
        owner.GetComponent<Follow>().enabled = true;
    }

    public override void Think()
    {

    }

    public override void Exit()
    {
        owner.GetComponent<Follow>().enabled = false;
    }
}


public class WarpState : State
{


    public override void Enter()
    {
        owner.GetComponent<Arrive>().enabled = true;

    }

    
}