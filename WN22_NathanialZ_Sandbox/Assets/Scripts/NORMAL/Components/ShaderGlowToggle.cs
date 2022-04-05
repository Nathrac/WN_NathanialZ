using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class ShaderGlowToggle : RealtimeComponent<ShaderModel>
{
    [SerializeField] Shader glow;
    [SerializeField] string boolName;

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
            //set shader bool named by parameter to true
            //possibly edit weakpoint list in this function. 
        }
        else
        {
            //set shader bool named by parameter to false
        }
    }
}
