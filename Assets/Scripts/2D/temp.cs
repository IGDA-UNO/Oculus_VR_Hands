using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
       this.transform.localPosition = new Vector3(this.transform.localPosition.x + 1, this.transform.localPosition.y, this.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("temp update? MAYBE hahahah");
        //this.transform.localPosition = new Vector3(this.transform.localPosition.x + 1, this.transform.localPosition.y, this.transform.localPosition.z);
    }
}
