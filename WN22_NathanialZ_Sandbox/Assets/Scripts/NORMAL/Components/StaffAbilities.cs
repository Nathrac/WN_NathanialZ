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
    //slowing
    [SerializeField] Animator giantAnimator;
    float prevSpeed; //to get animation speed before pausing animation with slowing ability.
    
    //Healing components
    bool canHeal = false;
    [SerializeField] Transform startpoint;
    [SerializeField] float raycastLenght;
    [SerializeField] float healValue;
    

    [SerializeField] InputActionReference slowingAbilityAction;
    [SerializeField] InputActionReference healingAbility;
    XRGrabInteractable grabInteractable;
    XRBaseInteractor interactor;

    //When component is turned on enable action.
    private void OnEnable()
    {
        slowingAbilityAction.action.Enable();
        healingAbility.action.Enable();
    }
    private void OnDisable()
    {
        slowingAbilityAction.action.Disable();
        healingAbility.action.Disable();
    }


    private void Start()
    {
        //set up interactable to listen for button press/hold
        grabInteractable = GetComponent<XRGrabInteractable>();
        slowingAbilityAction.action.performed += AbilityStarted; //when action preformed activate ability
        slowingAbilityAction.action.canceled += AbilityCanceled; //when button released, deactivate ability


        healingAbility.action.performed += HealingStarted;
        healingAbility.action.canceled += HealingStopped;
    }

    private void HealingStopped(InputAction.CallbackContext obj)
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left"))
        {
            canHeal = false;
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right"))
        {
            canHeal = false;
        }
    }

    private void HealingStarted(InputAction.CallbackContext obj)
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left"))
        {
            canHeal = true;
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right"))
        {
            canHeal = true;
        }
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

    private void FixedUpdate() //set fixed timestep to 0.0138
    {
        RaycastHit hit;

        if (Physics.Raycast(startpoint.position, transform.TransformDirection(Vector3.forward), out hit, raycastLenght, LayerMask.GetMask("Player")) && canHeal)
        {
            HealthBar hb = hit.collider.gameObject.GetComponent<HealthBar>();
            hb.AddHealth(healValue);
        }

    }
}

