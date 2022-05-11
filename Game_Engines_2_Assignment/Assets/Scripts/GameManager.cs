using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float timeToWaitBeforeStarting = 2;
    public CameraController cameraController;
    public CameraPointManager cameraPointManager;
    public TriggerManager triggerManager;

    public Transform cameraPoint1;
    public Transform cameraPoint2;
    public Transform cameraPoint3;
    public Transform cameraPoint4;
    public Transform cameraPoint5;
    public Transform cameraPoint6;
    public Transform cameraPoint7;




    //Events   
    public UnityEvent[] events;
    [SerializeField]
    public int currentEvent = 0;

    //Ships
    public GameObject Defiant;

    /*
    public GameObject Galaxy1;
    public GameObject Galaxy2;
    public GameObject Galaxy3;
    public GameObject Galaxy4;
    public GameObject Galaxy5;
    public GameObject Galaxy6;
    public GameObject Galaxy7;
    public GameObject Galaxy8;
    public GameObject Galaxy9;

    public GameObject Akira1;
    public GameObject Akira2;
    public GameObject Akira3;
    public GameObject Akira4;
    public GameObject Akira5;
    public GameObject Akira6;
    public GameObject Akira7;

    public GameObject Nebula1;
    public GameObject Nebula2;
    public GameObject Nebula3;
    public GameObject Nebula4;
    public GameObject Nebula5;

    public GameObject Norway1;
    public GameObject Norway2;
    public GameObject Norway3;

    public GameObject Saber1;
    public GameObject Saber2;
    public GameObject Saber3;

    public GameObject SteamRunner1;
    public GameObject SteamRunner2;
    public GameObject SteamRunner3;
    */
    public GameObject FederationFighter1;
    public GameObject FederationFighter2;
    public GameObject FederationFighter3;
    public GameObject FederationFighter4;
    public GameObject FederationFighter5;
    public GameObject FederationFighter6;
    public GameObject FederationFighter7;
    public GameObject FederationFighter8;
    public GameObject FederationFighter9;
    public GameObject FederationFighter10;
    public GameObject FederationFighter11;
    public GameObject FederationFighter12;


    public ShipPath FederationFighterAttackPath1;
    public ShipPath FederationFighterAttackPath2;
    public ShipPath FederationFighterAttackPath3;



    // Start is called before the first frame update
    void Start()
    {

        currentEvent = 0;
        StartCoroutine(NextSequence(timeToWaitBeforeStarting));

        

      
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
        cameraController.SetCamLookAt(cameraPoint1.transform);
        cameraController.SetCamFollow(Defiant.transform, 1);






    }


    public void Sequence_1_WarpSequence_2()
    {
      
        triggerManager.GetNextPoint().gameObject.SetActive(true);
        cameraController.SetCamLookAt(cameraPoint2.transform);
        cameraController.SetCamFollow(Defiant.transform, 2);

    }

    public void Sequence_1_WarpSequence_3()
    {
        triggerManager.GetNextPoint().gameObject.SetActive(true);
        cameraController.SetCamLookAt(cameraPoint3.transform);
        cameraController.SetCamFollow(FederationFighter12.transform, 2);


    }

    public void Sequence_1_WarpSequence_4()
    {
      
        triggerManager.GetNextPoint().gameObject.SetActive(true);
        cameraController.SetCamLookAt(cameraPoint4.transform);
        cameraController.SetCamFollow(FederationFighter11.transform, 2);




    }


    public void AttackFighter_1()
    {
        FederationFighter1.GetComponent<Follow>().path = FederationFighterAttackPath1;
        FederationFighter2.GetComponent<Follow>().path = FederationFighterAttackPath2;
        FederationFighter3.GetComponent<Follow>().path = FederationFighterAttackPath3;


        FederationFighter1.GetComponent<Arrive>().enabled = false;
        FederationFighter2.GetComponent<Arrive>().enabled = false;
        FederationFighter3.GetComponent<Arrive>().enabled = false;

        FederationFighter1.GetComponent<Follow>().enabled = true;
        FederationFighter2.GetComponent<Follow>().enabled = true;
        FederationFighter3.GetComponent<Follow>().enabled = true;

        cameraController.SetCamLookAt(FederationFighter1.transform);
        cameraController.SetCamFollow(FederationFighter1.transform, 3);





    }

    public void AttackFighter_2()
    {
        
            triggerManager.GetNextPoint().gameObject.SetActive(true);

            FederationFighter4.GetComponent<Follow>().path = FederationFighterAttackPath1;
            FederationFighter5.GetComponent<Follow>().path = FederationFighterAttackPath2;
            FederationFighter6.GetComponent<Follow>().path = FederationFighterAttackPath3;

            FederationFighter4.GetComponent<Arrive>().enabled = false;
            FederationFighter5.GetComponent<Arrive>().enabled = false;
            FederationFighter6.GetComponent<Arrive>().enabled = false;

            FederationFighter1.GetComponent<Follow>().enabled = true;
            FederationFighter2.GetComponent<Follow>().enabled = true;
            FederationFighter3.GetComponent<Follow>().enabled = true;

            cameraController.SetCamLookAt(cameraPoint6.transform);
            cameraController.SetCamFollow(FederationFighter4.transform, 3);

    }


    public void AttackFighter_3()
    {
        triggerManager.GetNextPoint().gameObject.SetActive(true);


        FederationFighter7.GetComponent<Follow>().path = FederationFighterAttackPath1;
        FederationFighter8.GetComponent<Follow>().path = FederationFighterAttackPath2;
        FederationFighter9.GetComponent<Follow>().path = FederationFighterAttackPath3;

        FederationFighter7.GetComponent<Arrive>().enabled = false;
        FederationFighter8.GetComponent<Arrive>().enabled = false;
        FederationFighter9.GetComponent<Arrive>().enabled = false;

        FederationFighter7.GetComponent<Follow>().enabled = true;
        FederationFighter8.GetComponent<Follow>().enabled = true;
        FederationFighter9.GetComponent<Follow>().enabled = true;

        cameraController.SetCamLookAt(cameraPoint7.transform);
        cameraController.SetCamFollow(FederationFighter7.transform, 3);
    }





}
