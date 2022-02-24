using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    public Hand rightHand;
    public Hand leftHand;
    public GameObject hmd;
    private Vector3 hmdPosition;
    private Boolean leftForward;
    public float accel;
    private float dis;

    public Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
        
        hmdPosition = transform.position;
        //Debug.Log("Head position: " + headPosition.z);
        //Debug.Log("Right hand position: " + rightHand.handZ);
        //Debug.Log($"Cube position: {hmd.transform.position.x}, {hmd.transform.position.y}, {hmd.transform.position.z}");

        // Check right hand position
        if (hmdPosition.z < rightHand.handZ && hmdPosition.z > leftHand.handZ && !leftForward)
        {

            Debug.Log("Right hand is behind head");
            leftForward = true;
            rb.AddForce(transform.forward * accel);
            //hmd.transform.position = Vector3.MoveTowards(hmd.transform.position, hmd.transform.position + Vector3.forward * dis, accel * Time.deltaTime);

        } else if(hmdPosition.z > rightHand.handZ && hmdPosition.z < leftHand.handZ && leftForward)
        {
            leftForward = false;
            Debug.Log("left hand is behind head");
            rb.AddForce(transform.forward * accel);
            //hmd.transform.position = Vector3.MoveTowards(hmd.transform.position, hmd.transform.position + Vector3.forward * dis, accel * Time.deltaTime);
        }

    }
}
