using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class WeaponTutorial : RealtimeComponent<TutorialModel>
{
    [SerializeField] BoxCollider runeCollider;
    [SerializeField] GameObject gate;
    [SerializeField] AudioSource soundFX;
    [SerializeField] string weaponTag;
    [SerializeField] string runeBool;
    [SerializeField] Renderer runeGlow;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(weaponTag))
        {
            TutorialHit();
            runeGlow.material.EnableKeyword(runeBool);
            runeCollider.enabled = false;
            soundFX.Play();
        }
    }
}
