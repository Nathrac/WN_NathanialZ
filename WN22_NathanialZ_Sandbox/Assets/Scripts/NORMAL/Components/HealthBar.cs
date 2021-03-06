using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR.Interaction.Toolkit;
using System;

//Put on VR Player Prefab
public class HealthBar : RealtimeComponent<HealthBarModel>
{
    [SerializeField] float maxHealth, dead;
    float mixValue;
    [SerializeField] Renderer halo;// bracelet; //material renderer for both Halo above player and bracelet to show the player their own health
    [SerializeField] string floatProperty; //reference bool names of halo shader

    ActionBasedContinuousMoveProvider conMove; //use to turn off locomotion when dead

    Realtime rt;
    RealtimeAvatarManager aM;

    private void Start()
    {
        conMove = GameObject.Find("XR Rig").GetComponent<ActionBasedContinuousMoveProvider>();
        rt = GameObject.Find("Realtime + VR Player").GetComponent<Realtime>();
        aM = GameObject.Find("Realtime + VR Player").GetComponent<RealtimeAvatarManager>();
    }

    public void AddHealth(float value)//add health to player, if health goes over max health set the health to maxhealth
    {
        model.health += value;
        if (model.health >= maxHealth)
        {
            model.health = maxHealth;
        }
    }

    public void RemoveHealth(float value)//remove health from player, if health goes below health, set health to dead (0)
    {
        model.health -= value;
        if (model.health <= dead)
        {
            model.health = dead;
        }
        Debug.Log("remove");
    }

    protected override void OnRealtimeModelReplaced(HealthBarModel previousModel, HealthBarModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.healthDidChange -= EffectHealth;
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                model.health = maxHealth;
                mixValue = 0;
            }
            currentModel.healthDidChange += EffectHealth;
        }
    }

    private void EffectHealth(HealthBarModel model, float value)//change halo shader colour based on health value. If the player is dead then turn off movement then swap tag. 
    {
        ColorChange();
        Debug.Log(model.health);
        if (model.health == 0)
        {
            conMove.enabled = false;
            tag = "dead";
            for (int i = 0; i < aM.avatars.Count; i++)
            {
                if (aM.avatars[i].gameObject.tag != "dead")
                {
                    return;
                }
                else
                {
                    if (i == aM.avatars.Count - 1)
                    {
                        Debug.Log("all dead");
                    }
                }
            }
        }
      
    }

    private void ColorChange() //change colour of halo and bracelet based on current health state to manipulate float value of shader
    {
        mixValue = model.health / maxHealth;
        halo.material.SetFloat(floatProperty, mixValue);
        //bracelet.SetFloat(floatProperty, mixValue);
    }

}
