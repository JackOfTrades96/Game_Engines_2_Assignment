using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float timeToWaitBeforeStarting = 15;

    public CameraController cameraController;
    public TriggerManager triggerManager;
    public CameraPositionManager cameraPositionManager;

    public String beginingState;

    //Events   
    public UnityEvent[] events;
    [SerializeField]
    public int currentEvent = 0;

    

  
    //Ships
    public GameObject DS9;

    public GameObject Galaxy1;
    public GameObject Galaxy2;
    public GameObject Galaxy3;
    public GameObject Galaxy4;

    public GameObject Akira1;
    public GameObject Akira2;

    public GameObject Nebula1;
    public GameObject Nebula2;

    public GameObject Nova1;
    public GameObject Nova2;

    public GameObject Saber1;
    public GameObject Saber2;

    public GameObject SteamRunner1;
    public GameObject SteamRunner2;

    public GameObject FederationFighter1;
    public GameObject FederationFighter2;
    public GameObject FederationFighter3;
    public GameObject FederationFighter4;
    public GameObject FederationFighter5;
    public GameObject FederationFighter6;
    public GameObject FederationFighter7;
    public GameObject FederationFighter8;
    public GameObject FederationFighter9;

    public ShipPath FigtherAttackPath1;
    public ShipPath FigtherAttackPath2;
    public ShipPath FigtherAttackPath3;


   

    // Start is called before the first frame update
    void Start()
    {
        currentEvent = 0;
        cameraController.currentOffsetOIndex = 0;
        StartCoroutine(NextSequence(timeToWaitBeforeStarting));
        Debug.Log("1");

       

    }

    // Update is called once per frame
    void Update()
    {
     
    }



    IEnumerator NextSequence(float waitBeforeTrigger)
    {
        yield return new WaitForSeconds(waitBeforeTrigger);
        events[currentEvent].Invoke();
        currentEvent++;
      
    }


    public void Sequence_1_WarpSequence_1(float TriggerNextSequenceTime)
    {
        Debug.Log("Warp Sequence");

        triggerManager.GetNextPoint().gameObject.SetActive(true);
        //cameraController.CameraFollow(GameObject.Find("Defiant").transform, 10);
        cameraController.StaticCamera(cameraPositionManager.GetNextPoint());
        cameraController.CameraLookAt(DS9.transform);

    }

    public void Sequence_1_WarpSequence_2( )
    {
        Debug.Log("Warp Sequence");

        triggerManager.GetNextPoint().gameObject.SetActive(true);
        cameraController.StaticCamera(cameraPositionManager.GetNextPoint());
        cameraController.CameraLookAt(Galaxy1.transform);

    }

    public void Sequence_1_WarpSequence_3()
    {
        Debug.Log("Warp Sequence");

        triggerManager.GetNextPoint().gameObject.SetActive(true);
        cameraController.StaticCamera(cameraPositionManager.GetNextPoint());
        cameraController.CameraLookAt(Galaxy2.transform);

    }

    public void Sequence_1_WarpSequence_4()
    {
        Debug.Log("Warp Sequence");

        triggerManager.GetNextPoint().gameObject.SetActive(true);
        cameraController.CameraLookAt(DS9.transform);


    }


    public void AttackFighter_1()
    {
       

        //FederationFighter1.GetComponent<Follow>().path = FigtherAttackPath1;
        //FederationFighter1.GetComponent<Follow>().enabled = true;
        //FederationFighter1.GetComponent<Arrive>().enabled = false;
        cameraController.StaticCamera(cameraPositionManager.GetNextPoint());
        cameraController.CameraLookAt(FederationFighter1.transform);
    }

    public void AttackFighter_2()
    {
        triggerManager.GetNextPoint().gameObject.SetActive(true);

        FederationFighter4.GetComponent<Follow>().path = FigtherAttackPath2;
        FederationFighter5.GetComponent<Follow>().path = FigtherAttackPath2;
        FederationFighter6.GetComponent<Follow>().path = FigtherAttackPath2;

        cameraController.CameraLookAt(FederationFighter4.transform);


    }


    public void AttackFighter_3()
    {
        FederationFighter7.GetComponent<Follow>().path = FigtherAttackPath2;
        FederationFighter8.GetComponent<Follow>().path = FigtherAttackPath2;
        FederationFighter9.GetComponent<Follow>().path = FigtherAttackPath2;

        triggerManager.GetNextPoint().gameObject.SetActive(true);

        cameraController.CameraLookAt(FederationFighter7.transform);
    }

    
}
