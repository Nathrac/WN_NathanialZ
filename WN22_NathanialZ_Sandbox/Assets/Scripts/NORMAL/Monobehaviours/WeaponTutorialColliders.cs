using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTutorialColliders : MonoBehaviour
{
    [SerializeField] BoxCollider runeCollider;
    
    [SerializeField] AudioSource soundFX;
    [SerializeField] string weaponTag;
    [SerializeField] string runeBool;
    [SerializeField] Renderer runeGlow;

    [SerializeField] WeaponTutorial wTC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(weaponTag)) //if the other collider has the specified weapon tag to make each rune for each player
        {
            runeCollider.enabled = false; //disable rune collider so it cant be hit multiple times

            wTC.TutorialHit(); //add 1 to the tutorial int parameter
            
            runeGlow.material.SetFloat(runeBool, 0f); //disable rune glow to show it's been hit
          
            soundFX.Play();
        }
    }
}
