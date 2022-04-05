using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;

public class WeaponOwnershipControl : MonoBehaviour
{
    [SerializeField] RealtimeTransform _rtt;
    [SerializeField] XRGrabInteractable xrGrab;

    public void SetWeaponOwner()
    {
        if (!_rtt.isOwnedRemotelyInHierarchy)
        {
            _rtt.RequestOwnership();
        }
        else
        {
            xrGrab.enabled = false;
        }
    }
    
}
