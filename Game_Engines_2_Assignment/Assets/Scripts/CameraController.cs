using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform LookAt;
    public Transform ToFollow;
    public Vector3 FollowOffset;
    public float movementLerpSpeed = 2f;
    public float rotationLerpSpeed = 2f;

    public Vector3 panningValue = new Vector3(0, 0, 0);

    public Vector3[] cameraOffsets;
    public int currentOffsetOIndex = 0;
    public float magnitudeDecreaseMultiplier = 3f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LateUpdate()
    {
        float magnitudeIncrease = 0;

        if(LookAt && LookAt.GetComponent<Rigidbody>())
        {
            magnitudeIncrease = LookAt.GetComponent<Rigidbody>().velocity.magnitude / magnitudeDecreaseMultiplier;
        }


        if(ToFollow != null)
        {
            Vector3 ToPosition = transform.position + transform.TransformDirection(panningValue);
            transform.position = Vector3.Lerp(transform.position, ToPosition, Time.deltaTime * movementLerpSpeed);
        }


        if(LookAt)
        {
            Vector3 relativePosition = LookAt.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * (rotationLerpSpeed + magnitudeIncrease));
        }

    }


    public void CameraLookAt(Transform gameobject)
    {
        LookAt = gameobject;
    }

    public void CameraFollow(Transform gameobject, int offsetIndex)
    {
        ToFollow = gameobject;
        Vector3 offset = GetOffset(offsetIndex);
        FollowOffset = offset;
    }

    public void CameraFollowAndLook(Transform gameObject, int offsetIndex)
    {
        ToFollow = gameObject;
        Vector3 offset = GetOffset(offsetIndex);
        FollowOffset = offset;

    }

    public void CameraNotFollowing()
    {
        ToFollow = null;
        FollowOffset = Vector3.zero;
    }

    public void StaticCamera(Transform cameraPosition)
    {
        CameraNotFollowing();
        transform.position = cameraPosition.transform.position;
        transform.rotation = cameraPosition.transform.rotation;
    }


    public void CameraOffset(Transform obj, int offsetIndex)
    {
        Vector3 offset = GetOffset(offsetIndex);
        CameraNotFollowing();
        transform.position = obj.transform.TransformPoint(offset);

    }


    public Vector3 GetOffset(int index)
    {
        Vector3 selectedOffset = cameraOffsets[index];
        currentOffsetOIndex = index + 1;

        return selectedOffset;

    }

    public Vector3 GetNextOffset()
    {
        Vector3 selectedOffset = GetOffset(currentOffsetOIndex);
        currentOffsetOIndex++;
        return selectedOffset;
    }
        

}
