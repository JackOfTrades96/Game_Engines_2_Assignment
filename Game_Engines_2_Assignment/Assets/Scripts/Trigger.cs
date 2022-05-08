using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public String nameOfTriggerObj;

    public GameManager gameManager;
    public int nextEvent;


    private void Start()
    {
        if (gameManager == null)
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.transform.name == nameOfTriggerObj)
        {
            Debug.Log("Hit");
            gameManager.events[nextEvent].Invoke();
            gameManager.currentEvent = nextEvent+1;
            this.transform.gameObject.SetActive(false);

        }
    }

}
