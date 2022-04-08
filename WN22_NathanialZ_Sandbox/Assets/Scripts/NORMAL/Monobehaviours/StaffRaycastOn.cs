using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;

//Put On Staff
public class StaffRaycastOn : MonoBehaviour
{
    [SerializeField] RealtimeTransform rt;
    [SerializeField] XRRayInteractor xrRayL;
    [SerializeField] XRRayInteractor xrRayD;

    public void TurnRayOn() //When staff is grabbed then turn on raycast for that player
    {
        if (rt.isOwnedLocallyInHierarchy)
        {
            xrRayD.enabled = true;
            xrRayL.enabled = true;
        }
    }
}
