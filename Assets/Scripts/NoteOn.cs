using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteOn : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CanLight")
        {
            audioSource.Play();
            Debug.Log("NoteOn");
        }
    }
}
