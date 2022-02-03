using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    ActionBasedController controller;
    XRIDefaultInputActions playerInput;
    public bool skratchPressed;
    

    public VrHand hand;


    private void Awake()
    {
        playerInput = new XRIDefaultInputActions();

        
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrip(controller.selectAction.action.ReadValue<float>());
        hand.SetTrigger(controller.activateAction.action.ReadValue<float>());

        playerInput.XRIRightHand.Skratch.performed += ctx => skratchPressed = true;
        playerInput.XRIRightHand.Skratch.canceled += ctx => skratchPressed = false;

        //Debug.Log(skratchPressed);
    }

    private void OnEnable()
    {
        playerInput.XRIRightHand.Enable();
    }

    private void OnDisable()
    {
        playerInput.XRIRightHand.Disable();
    }

}
