using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;

public class WeaponOwnershipControl : MonoBehaviour
{
    [SerializeField] RealtimeTransform _rtt;
    [SerializeField] XRGrabInteractable xrGrab;

    public void SetWeaponOwner() //If the weapon has no ownership set in the system, request ownership of the weapon.
    {
        if (!_rtt.isOwnedRemotelyInHierarchy)
        {
            _rtt.RequestOwnership();
        }
        else
        {
            xrGrab.enabled = false; //if weapon is owned by someone else, no one esle can grab the weapon but the owner.
        }
    }
    
}
