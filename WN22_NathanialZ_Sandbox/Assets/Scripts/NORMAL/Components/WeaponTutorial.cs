using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

//Put this script on every rune for the weapon tutorial (1 on beserker rune, 1 on archer rune, 1 on mage rune)
public class WeaponTutorial : RealtimeComponent<TutorialModel>
{
    [SerializeField] GameObject gate;
    [SerializeField] int hitCountToPass;
    public void TutorialHit()
    {
        model.tutorialHit++;
    }

    protected override void OnRealtimeModelReplaced(TutorialModel previousModel, TutorialModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.tutorialHitDidChange -= AddToHitCount;
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                model.tutorialHit = 0;
            }
            currentModel.tutorialHitDidChange += AddToHitCount;
        }
    }

    private void AddToHitCount(TutorialModel model, int value)
    {
        if (model.tutorialHit == hitCountToPass)
        {
            gate.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
