using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCombatController : MonoBehaviour
{
    public float health;
    public GameObject enemy;
    public string Tag;
    public float Range = 100f;
    public float maxRetreatDistance = 150f;
    public float retreatDistance = 0;
    
   
    public GameObject phaser;
    public AudioSource phaserAudio;
    public int phaserCooldown = 10;
    private int phaserDelay = 0;

   


    public void Start()
    {
        
      
        
    }

    public void Update()
    {
      if(enemy != null)
        {
            string enemyState = enemy.transform.GetComponent<StateMachine>().currentState.GetType().Name;

            if(enemyState == "DeadState")
            {
                enemy = null;
            }

        }

    }


    public void PhaserFire()
    {
        if(phaserAudio != null)
        {
            phaserAudio.PlayOneShot(phaserAudio.clip);

        }

        phaserDelay += 1;

        if(phaserDelay >= phaserCooldown)
        {
            GameObject phasershot = GameObject.Instantiate(phaser, transform.position + transform.forward * 2, transform.rotation);
            phaserDelay = 0;
        }

    }

   

    public bool EnemyInRange()
    {
        Debug.Log("Range");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tag);

        for(int i = 0; i < enemies.Length; i++)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemies[i].transform.position);
             print(enemies[i].name);
            StateMachine enemyStateMachine = enemies[i].transform.parent.GetComponent<StateMachine>();

            if(enemyStateMachine != null)
            {
                string enemyState = enemyStateMachine.currentState.GetType().Name;

                if (distanceToEnemy < Range && enemyState != "DeadState")
                {
                    enemy = enemies[i].transform.parent.gameObject;
                    return true;
                }
            }
        }
        return false;
    }


   
   

}
