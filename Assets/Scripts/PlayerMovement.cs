using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Hand hand;
    private Vector3 headPosition;
    private float accel;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        headPosition = transform.position;
        Debug.Log("head position: " + headPosition.z);

        //accel = (headPosition.z - hand.handZ);
        bool forward = headPosition.z > hand.handZ;
        if (forward)
        {
            Debug.Log("Forward");
            //headPosition.z += accel;
        }
        else
            Debug.Log("Backward");
    }
}
