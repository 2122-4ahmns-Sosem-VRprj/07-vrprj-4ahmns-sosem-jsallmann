using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static ActionBasedController climbingHand;
    private ContiniousMovement continiousMovement;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continiousMovement = GetComponent<ContiniousMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (climbingHand)
        {
            continiousMovement.enabled = false;
            Climb();
        }
        else
        {
            continiousMovement.enabled = true;
        }
    }

    void Climb()
    {
        XRNode node = XRNode.RightHand;
        if (climbingHand.name == "LeftHand Controller")
        {
            node = XRNode.LeftHand;
        }
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
