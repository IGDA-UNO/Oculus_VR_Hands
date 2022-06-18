using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkXRPlayer : MonoBehaviour
{
    public Transform head;
    public Transform body;
    public Transform leftHand;
    public Transform rightHand;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    private PhotonView photonView;

    [Header("XR Rig is deprecated. XR Origin is being used.")]
    private Transform headRig;
    private Transform bodyRig;
    private Transform leftHandRig;
    private Transform rightHandRig;
    //private Transform bodyRig;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        //bodyRig = rig.transform;
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        bodyRig = rig.transform.Find("Camera Offset/Body Controller");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");

        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            /*
            MapPosition(head, headRig, bodyRig);
            MapPosition(leftHand, leftHandRig, bodyRig);
            MapPosition(rightHand, rightHandRig, bodyRig);
            */
            MapPosition(head, headRig);
            MapPosition(body, bodyRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
        }
    }

    /*
    void MapPosition(Transform target, Transform rigTransform, Transform rigScale)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
        target.localScale = rigScale.localScale;
    }
    */
    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }
}