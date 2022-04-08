using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

//Put this script on every rune for the weapon tutorial (1 on beserker rune, 1 on archer rune, 1 on mage rune)
public class WeaponTutorial : RealtimeComponent<TutorialModel>
{
    [SerializeField] BoxCollider runeCollider;
    [SerializeField] GameObject gate;
    [SerializeField] AudioSource soundFX;
    [SerializeField] string weaponTag;
    [SerializeField] string runeBool;
    [SerializeField] Material runeGlow;

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
        if (model.tutorialHit == 3)
        {
            gate.SetActive(false);
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(weaponTag)) //if the other collider has the specified weapon tag to make each rune for each player
        {
            TutorialHit(); //add 1 to the tutorial int parameter
            runeGlow.DisableKeyword(runeBool); //disable rune glow to show it's been hit
            runeCollider.enabled = false; //disable rune collider so it cant be hit multiple times
            soundFX.Play();
        }
    }
}
