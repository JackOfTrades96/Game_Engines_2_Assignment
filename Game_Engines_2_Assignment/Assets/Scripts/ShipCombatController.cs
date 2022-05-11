using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCombatController : MonoBehaviour
{
    public GameObject self;
    public float health;
    public GameObject enemy;
    public string Tag;
    public float Range = 100f;
    public float maxRetreatDistance = 150f;
    public float retreatDistance = 0;
    public Transform FirePoint;
    public Transform FirePoint2;
    public Transform FirePoint3;
    public Transform FirePoint4;
    public float angle;
    public GameObject phaser;
    public AudioSource phaserAudio;
    public int phaserCooldown = 10;
    private int phaserDelay = 0;

  


    public void Start()
    {

      
      
        
    }

    public bool EnemyInRange()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tag);

        for (int i = 0; i < enemies.Length; i++)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemies[i].transform.position);

            StateMachine enemyStateMachine = enemies[i].transform.parent.GetComponent<StateMachine>();

            if (enemyStateMachine != null)
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



    public void Update()
    {
     

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Phaser")
        {
            string phaser = other.gameObject.transform.Find("Tag").tag;

            if (phaser + "" ==Tag)
            {

            }

                Debug.Log("Hit");

            if (health > 0)
            {
                health--;
            }
            Destroy(other.gameObject);

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

            if(gameObject == GameObject.FindGameObjectWithTag("Fighter"))
            {
                GameObject phasershot = GameObject.Instantiate(phaser, FirePoint.transform.position, transform.rotation);
            }
          

            if(gameObject == GameObject.FindGameObjectWithTag("Ship"))
            {
                GameObject phasershot1  = GameObject.Instantiate(phaser, FirePoint.transform.position, transform.rotation);
                GameObject phasershot2 = GameObject.Instantiate(phaser, FirePoint2.transform.position, transform.rotation);
                GameObject phasershot3 = GameObject.Instantiate(phaser, FirePoint3.transform.position, transform.rotation);
                GameObject phasershot4 = GameObject.Instantiate(phaser, FirePoint4.transform.position, transform.rotation);
            }
            phaserDelay = 0;
        }

    }

   

   



    

}
