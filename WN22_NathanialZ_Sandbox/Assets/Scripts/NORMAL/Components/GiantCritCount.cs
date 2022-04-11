using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

//Place on Giant Crit spot collider
public class GiantCritCount : RealtimeComponent<GiantCritModel>
{
    [SerializeField] BoxCollider critCollider;
    [SerializeField] Renderer critGlow;
    [SerializeField] string weaponTag;
    [SerializeField] string boolName;

    [SerializeField] AudioSource youWin;
    [SerializeField] float timeBeforeQuit;

    public void CritHit() //add to crit intiger
    {
        model.critCount++;
    }

    protected override void OnRealtimeModelReplaced(GiantCritModel previousModel, GiantCritModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.critCountDidChange -= AddToCount;
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                model.critCount = 0;
            }
            currentModel.critCountDidChange += AddToCount;
        }
    }

    private void AddToCount(GiantCritModel model, int value)
    {
        if (model.critCount == 3) //once crit count gets to 3, quit application
        {
            StartCoroutine(GameWon());
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other) //on trigger enter of Axe, turn off crit glow, turn off collider, then call critHit function to add to model Int
    {
        if (other.gameObject.CompareTag(weaponTag))
        {
            critGlow.material.SetInt(boolName, 0);
            critCollider.enabled = false;
            CritHit();
            Debug.Log("Crit");
        }
    }

    public void ReEnableCrit() //Call this when isStunned is turned off
    {
        if (!critCollider.enabled)
        {
            critCollider.enabled = true;
            critGlow.material.SetInt(boolName, 1);
        }
    }

    IEnumerator GameWon() //Called when game is won. Thanks players for winning the battle and they will now be returned to their worlds. Quit application. 
    {
        youWin.Play();
        yield return new WaitForSeconds(timeBeforeQuit);
        Application.Quit();
    }

    
}
