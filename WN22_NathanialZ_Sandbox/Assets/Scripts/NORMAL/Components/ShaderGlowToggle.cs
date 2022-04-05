using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class ShaderGlowToggle : RealtimeComponent<ShaderModel>
{
    [SerializeField] Renderer glow;
    [SerializeField] string boolName;
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
            glow.material.EnableKeyword(boolName);
        }
        else
        {
            glow.material.DisableKeyword(boolName);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(weaponTag))
        {
            SetShaderBool(false);
            cM.CollideHit();
            //if (script.hit == 3) { for loop to activate colliderArray, set hit = 0, sgt.SetShaderBool(true), 
            //script.hit ++;
            //colide.enabled = false;

        }
    }
}
