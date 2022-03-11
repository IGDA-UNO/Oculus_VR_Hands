using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Aaron Autin, Frank Fontana
public class Hand : MonoBehaviour
{
    public float handZ;
    public float accel;
    public float vel;
    private float lastPos;
    private float lastVel;

    // Start is called before the first frame update
    void Start()
    {
        lastVel = 0;
        accel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = transform.localPosition.z;
        float tempTime = Time.deltaTime;
        vel = (temp - lastPos) / tempTime;
        accel = (vel - lastVel) / tempTime;
        handZ = temp;

        lastVel = vel;
        lastPos = temp;
        //Debug.Log("handz: " + handZ);
    }
}
