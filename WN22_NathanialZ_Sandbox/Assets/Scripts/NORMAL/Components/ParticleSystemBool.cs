using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Normal.Realtime;

public class ParticleSystemBool : RealtimeComponent<ParticleSystemBoolModel>
{
    public ParticleSystem particle;
    

    public void SetParticleBool(bool value)
    {
        model.vfxOn = value;
    }

    protected override void OnRealtimeModelReplaced(ParticleSystemBoolModel previousModel, ParticleSystemBoolModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.vfxOnDidChange -= ToggleParticle;
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                model.vfxOn = true;
            }
            currentModel.vfxOnDidChange += ToggleParticle;
        }

    }

    private void ToggleParticle(ParticleSystemBoolModel model, bool value)
    {
        if (model.vfxOn)
        {
            particle.Play();
        }
        else
        {
            particle.Stop();
        }
    }
}
