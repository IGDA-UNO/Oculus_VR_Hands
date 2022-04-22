using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Ben Samuel, Norman Bennett, Aaron Autin, David Pace, Frank Fontana
public class Player : MonoBehaviour
{
    public Hand rightHand;
    public Hand leftHand;
    public GameObject hmd;
    private Vector3 hmdPosition;

    public Rigidbody rb;

    private bool leftForward;
    public float accel;
    private float dis;

    private bool isMoving;
    private bool isAlive;
    public bool isWinner;

    public float movementSensitivity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        isAlive = true;
        isWinner = false;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
 
    }


    public void UpdatePlayer()
    {

        if (!isWinner && isAlive)
        {
            Move();
        }
        else
        {
            isMoving = false;
        }


        if (transform.localPosition.z >= (GameObject.Find("Goal").transform.position.z - 10.0f) && !isWinner){
            isWinner = true;
            Debug.Log(this.name + " WON!!!!!!!!!!!!!");
        }
        //Debug.Log("Player velocity: " + rb.velocity.z);
    }

    void Move()
    {
        dis = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);

        hmdPosition = transform.position;
        //Debug.Log("Head position: " + headPosition.z);
        //Debug.Log("Right hand position: " + rightHand.handZ);
        //Debug.Log($"Cube position: {hmd.transform.position.x}, {hmd.transform.position.y}, {hmd.transform.position.z}");


        //Debug.Log($"Right hand velocity: {rightHand.vel} | Right hand accel: {rightHand.accel}");
        //Debug.Log($"Left hand velocity: {leftHand.vel} | Left hand accel: {leftHand.accel}");
        if (rightHand.accel >= movementSensitivity && leftHand.accel <= -movementSensitivity)
        {
            Debug.Log("Right Hand Forward Left Hand Backward");
            hmd.transform.position = Vector3.MoveTowards(hmd.transform.position, hmd.transform.position + Camera.main.transform.forward * 1.5f * rightHand.accel , accel * 2.0f * Time.deltaTime);
            
            isMoving = true;
        }
        else if (rightHand.accel <= -movementSensitivity && leftHand.accel >= movementSensitivity)
        {
            Debug.Log("Right Hand Backward Left Hand Forward");
            hmd.transform.position = Vector3.MoveTowards(hmd.transform.position, hmd.transform.position + Camera.main.transform.forward * 1.5f * leftHand.accel, accel * 2.0f * Time.deltaTime);
            
            isMoving = true;
        }   
        else
        {
            Debug.Log("Not Moving");
            isMoving = false;
        }
           
        /*
        // Check hand positions
        if (hmdPosition.z < rightHand.handZ && hmdPosition.z > leftHand.handZ && !leftForward)
            {

                //Debug.Log("Right hand is behind head");
                leftForward = true;
                //hmd.transform.position = Vector3.MoveTowards(hmd.transform.position, hmd.transform.position + Vector3.forward * dis * 2, accel * Time.deltaTime);
                Vector3 addedForce = transform.forward * accel * Time.deltaTime;
                //Debug.Log(addedForce);
                rb.AddForce(addedForce);
                isMoving = true;

            }
            else if (hmdPosition.z > rightHand.handZ && hmdPosition.z < leftHand.handZ && leftForward)
            {
                leftForward = false;
                //Debug.Log("left hand is behind head");
                //hmd.transform.position = Vector3.MoveTowards(hmd.transform.position, hmd.transform.position + Vector3.forward * dis * 2, accel * Time.deltaTime);
                Vector3 addedForce = transform.forward * accel * Time.deltaTime;
                //Debug.Log(addedForce);
                rb.AddForce(addedForce);
                isMoving = true;
            }
            else
            {
                isMoving = false;
            */
    }

    public bool getIsMoving(){
        return isMoving;
    }

    public void killOff(){
        isAlive = false;
        isMoving = false;
    }
}
