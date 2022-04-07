using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class HealthBar : RealtimeComponent<HealthBarModel>
{
    [SerializeField] int maxHealth, critHealth, dead;
    [SerializeField] Renderer halo;

    [SerializeField] string maxH, midH, critH; //reference bool names of halo shader
    [SerializeField] ActionBasedContinuousMoveProvider conMove;

    [SerializeField] Realtime rt;

    List<GameObject> playerList = new List<GameObject>();

    public void AddHealth(int value)//add health to player, if health goes over max health set the health to maxhealth
    {
        model.health += value;
        if (model.health >= maxHealth)
        {
            model.health = maxHealth;
        }
    }

    public void RemoveHealth(int value)//remove health from player, if health goes below health, set health to dead (0)
    {
        model.health -= value;
        if (model.health <= dead)
        {
            model.health = dead;
        }
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
            }
            currentModel.healthDidChange += EffectHealth;
        }
    }

    private void EffectHealth(HealthBarModel model, int value)//change halo shader colour based on health value. If max, turn on maxHealth colour turn off the rest, similar process for in between max and critical and below critical.
    {
        if (model.health == maxHealth)
        {
            halo.material.EnableKeyword(maxH);
            halo.material.DisableKeyword(midH);
            halo.material.DisableKeyword(critH);
        }
        else if (model.health >= critHealth && model.health < maxHealth)
        {
            halo.material.DisableKeyword(maxH);
            halo.material.EnableKeyword(midH);
            halo.material.DisableKeyword(critH);
        }
        else if (model.health < critHealth)
        {
            halo.material.DisableKeyword(maxH);
            halo.material.DisableKeyword(midH);
            halo.material.EnableKeyword(critH);
        }
        else if (model.health == dead)//if player is dead, turn off movement and change player tag.
        {
            conMove.enabled = false;
            tag = "dead";
        }
    }

    private void Start()
    {
        realtime.didConnectToRoom += DidConnect;
    }

    private void DidConnect(Realtime realtime)
    {
        AddPlayer((uint)(rt.clientID));
        
    }

    private void AddPlayer(uint playerID)
    {
        PlayerDataModel newModel = new PlayerDataModel();
        newModel.isDead = false;
        model.players.Add(playerID, newModel);
    }

    private bool GetDeathState(uint playerID)
    {
        return model.players[playerID].isDead;
    }

    private void SetDeathState(uint playerID)
    {
        model.players[playerID].isDead = true;
    }
}
