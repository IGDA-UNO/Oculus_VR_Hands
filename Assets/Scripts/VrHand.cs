using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class VrHand : MonoBehaviour
{
    public float speed;

    public HandController handController;

    Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;

    private string animGripParam = "Grip";
    private string animTriggerParam = "Trigger";
    private string animSkratchParam = "Skratch";


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    

    void AnimateHand()
    {
      
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animGripParam, gripCurrent);
        }

        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animTriggerParam, triggerCurrent);
        }

        if (handController.skratchPressed)
        {
            animator.SetBool(animSkratchParam, true);
        }
        else 
        {
            animator.SetBool(animSkratchParam, false);
        }
         
    }
}
