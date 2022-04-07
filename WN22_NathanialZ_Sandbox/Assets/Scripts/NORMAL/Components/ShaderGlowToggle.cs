using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class ShaderGlowToggle : RealtimeComponent<ShaderModel>
{
    [SerializeField] Renderer glow; //reference to the giant shader
    [SerializeField] string boolName; //use to change the name of the shader bool parameter in the inspectore per weak point
    [SerializeField] string weaponTag;
    [SerializeField] BoxCollider colide;
    [SerializeField] ColliderManager cM;
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
            glow.material.EnableKeyword(boolName); //if isGlowing is true, set the specified bool to turn on.
        }
        else
        {
            glow.material.DisableKeyword(boolName); //turn off specified bool in the shader to turn off glow of weakpoint
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(weaponTag)) //on collision of custom weapon tag with giant collider set the shader bool off, disable collider, and add to hit counter.
        {
            SetShaderBool(false);
            colide.enabled = false;
            cM.CollideHit();   
        }
    }
}
