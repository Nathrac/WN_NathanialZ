using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


//Put On Staff
public class StaffRaycastOn : MonoBehaviour
{
    
    bool rayON = false;
    [SerializeField] XRRayInteractor xrRayL;
    [SerializeField] XRRayInteractor xrRayD;

    public void TurnRayOn() //When staff is grabbed then turn on raycast for that player
    {
        if (!rayON)
        {
            xrRayD.enabled = true;
            xrRayL.enabled = true;
            rayON = true;
            Debug.Log("RaycastOn");
        }
    }
}