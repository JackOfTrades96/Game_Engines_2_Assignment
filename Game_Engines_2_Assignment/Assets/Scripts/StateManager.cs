using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class StateManager : MonoBehaviour
{
    public String beginingState;
    public String LifeStatusState;
    // Start is called before the first frame update
    void Start()
    {
        if (beginingState != null)
        {
            Type stateClass = Type.GetType(beginingState);
            GetComponent<StateMachine>().ChangeState((State)Activator.CreateInstance(stateClass));
        }

        if (LifeStatusState != null)
        {
            Type stateClass = Type.GetType(LifeStatusState);
            GetComponent<StateMachine>().SetGlobalState((State)Activator.CreateInstance(stateClass));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
