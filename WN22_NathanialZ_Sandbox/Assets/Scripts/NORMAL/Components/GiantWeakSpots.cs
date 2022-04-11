using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

//Put on every weak point collider on the giant
public class GiantWeakSpots : RealtimeComponent<ShaderModel>
{
    [SerializeField] Material glow; //reference to the giant shader
    [SerializeField] string boolName; //use to change the name of the shader bool parameter in the inspectore per weak point
    [SerializeField] string weaponTag; 
    [SerializeField] BoxCollider colide; //The collider of the empty this script is on
    [SerializeField] ColliderManager cM; //Game Manager for the giant weakpoint sequence
    [SerializeField] AudioSource sfx;

   

    public void SetShaderBool(bool value)
    {
        model.isGlowing = value;
    }

    protected override void OnRealtimeModelReplaced(ShaderModel previousModel, ShaderModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.isGlowingDidChange -= ToggleShader;
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                model.isGlowing = true;
            }
            currentModel.isGlowingDidChange += ToggleShader;
        }
    }

    private void ToggleShader(ShaderModel model, bool value)
    {
        if (model.isGlowing)
        {
            glow.EnableKeyword(boolName); //if isGlowing is true, set the specified bool to turn on.
        }
        else
        {
            glow.DisableKeyword(boolName); //turn off specified bool in the shader to turn off glow of weakpoint
        }
    }


    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(weaponTag))
        {
            SetShaderBool(false);
            colide.enabled = false;
            cM.CollideHit();
            Debug.Log("trigger");
        }
    }

}
