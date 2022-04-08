using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using Normal.Realtime;
using System;


//Put On Staff
public class StaffAbilities : RealtimeComponent<StaffModel>
{
    [SerializeField] Animator giantAnimator;
    float prevSpeed; //to get animation speed before pausing animation with slowing ability.

    [SerializeField] InputActionReference slowingAbilityAction;
    XRGrabInteractable grabInteractable;
    XRBaseInteractor interactor;

    //When component is turned on enable action.
    private void OnEnable()
    {
        slowingAbilityAction.action.Enable();
    }
    private void OnDisable()
    {
        slowingAbilityAction.action.Disable();
    }


    private void Start()
    {
        //set up interactable to listen for button press/hold
        grabInteractable = GetComponent<XRGrabInteractable>();
        slowingAbilityAction.action.performed += AbilityStarted; //when action preformed activate ability
        slowingAbilityAction.action.canceled += AbilityCanceled; //when button released, deactivate ability
    }

    private void AbilityStarted(InputAction.CallbackContext obj) //if button held then activate the ability to slow down giant. Checks for both right hand and left hand so that either hand can hold staff and activate ability
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left"))
        {
            SlowDownGiant(true);
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right"))
        {
            SlowDownGiant(true); 
        }
    }

    private void AbilityCanceled(InputAction.CallbackContext obj) //if button is released then turn off ability allow animation to continue
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left"))
        {
            SlowDownGiant(false); 
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right"))
        {
            SlowDownGiant(false); 
        }
    }

    //Set of code used in last year final to find interactor when grabbing object
    public void GetInteractor()
    {
        interactor = grabInteractable.selectingInteractor;
    }

    public void ReleaseInteractor()
    {
        interactor = null;
    }

    
    public void SlowDownGiant(bool value)
    {
        model.slowGiant = value; //change bool to subscirbe to event and activate or disable ability
    }

    protected override void OnRealtimeModelReplaced(StaffModel previousModel, StaffModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.slowGiantDidChange -= GiantSlowed;
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                model.slowGiant = false;
            }
            currentModel.slowGiantDidChange += GiantSlowed;
        }
    }

    private void GiantSlowed(StaffModel model, bool value)
    {
        if (model.slowGiant) //if model bool is true then get the current animation speed of the isStunned animation and then set the animation speed to 0.
        {
            prevSpeed = giantAnimator.speed;
            giantAnimator.speed = 0;
        }
        else
        {
            giantAnimator.speed = prevSpeed; //if model bool is false set the animation speed to what it was before changing to 0. 
        }
    }
}

